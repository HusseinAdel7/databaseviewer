using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Database_Viewer
{
    /// <summary>
    /// Interaction logic for Inforamtion.xaml
    /// </summary>
    public partial class Inforamtion : Window
    {
        string dbConnectionString;
        public Label Prodecuresnum { get; set; }

        public Inforamtion(string connection)
        {
            dbConnectionString = connection;
            InitializeComponent();
        }


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window currentWindow = Window.GetWindow(this);

            if (currentWindow != null)
            {
                currentWindow.WindowState = WindowState.Minimized;
            }
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void connec()
        {
            SqlConnection connection = new SqlConnection(dbConnectionString);
            try
            {
                connection.Open();
                DatabaseInfoPage dbInfoPage = new DatabaseInfoPage();
                if (connection.State == ConnectionState.Open)
                {

                    string Dbname;

                    string query1 = "SELECT DB_NAME() AS 'DatabaseName';";
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        string databaseName = (string)command.ExecuteScalar();
                        Dbname = databaseName;
                        dbInfoPage.DbName.Text = $"{databaseName}";
                    }


                    string query2 = "SELECT SUM(size * 8 / 1024) AS DatabaseSizeMB FROM sys.master_files WHERE type = 0 AND database_id = DB_ID();";
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int databaseSize = Convert.ToInt32(result);
                            dbInfoPage.DbSize.Text = $"{databaseSize} MB";
                        }
                        else
                        {
                            dbInfoPage.DbSize.Text = "N/A";
                        }
                    }


                    string query3 = "SELECT create_date FROM sys.databases WHERE name = DB_NAME()";
                    using (SqlCommand command = new SqlCommand(query3, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            DateTime creationTime = Convert.ToDateTime(result);
                            dbInfoPage.DbCreationDate.Text = creationTime.ToString("d/M/yyy || hh:mm tt");
                        }
                        else
                        {
                            dbInfoPage.DbCreationDate.Text = "N/A";
                        }
                    }


                    string query4 = @" SELECT MAX(modify_date) FROM sys.tables  WHERE type = 'U'"; // 'U' for user-defined tables
                    using (SqlCommand command = new SqlCommand(query4, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            DateTime lastModifiedDate = Convert.ToDateTime(result);
                            dbInfoPage.DbLastModifiedDate.Text = lastModifiedDate.ToString("d/M/yyy || hh:mm tt");
                        }
                        else
                        {
                            dbInfoPage.DbLastModifiedDate.Text = "N/A";
                        }
                    }




                    string query5 = "SELECT suser_sname(owner_sid) AS OwnerName FROM sys.databases WHERE name = DB_NAME()";
                    using (SqlCommand command = new SqlCommand(query5, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string? ownerName = result.ToString();

                            dbInfoPage.DbOwner.Text = ownerName;
                        }
                        else
                        {
                            dbInfoPage.DbOwner.Text = "N/A";
                        }
                    }


                    string query6 = "SELECT COUNT(*) FROM sys.database_principals WHERE type_desc = 'SQL_USER'";
                    using (SqlCommand command = new SqlCommand(query6, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int numberOfUsers = Convert.ToInt32(result);
                            dbInfoPage.DbUsers.Text = $"{numberOfUsers}";
                        }
                        else
                        {
                            dbInfoPage.DbUsers.Text = "N/A";
                        }
                    }


                    string query7 = "SELECT collation_name FROM sys.databases WHERE name = DB_NAME()";
                    using (SqlCommand command = new SqlCommand(query7, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string? collation = result.ToString();
                            dbInfoPage.DbCollaction.Text = collation;
                        }
                        else
                        {
                            dbInfoPage.DbCollaction.Text = "N/A";
                        }
                    }


                    string query8 = "SELECT compatibility_level FROM sys.databases WHERE name = DB_NAME()";
                    using (SqlCommand command = new SqlCommand(query8, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            int compatibilityLevel = Convert.ToInt32(result);
                            dbInfoPage.DbCompatibilityLevel.Text = $"{compatibilityLevel}";
                        }
                        else
                        {
                            dbInfoPage.DbCompatibilityLevel.Text = "N/A";
                        }
                    }


                    string query10 = @$"
                                        SELECT 
                                        SUM(CASE WHEN type_desc = 'ROWS' THEN 1 ELSE 0 END) AS 'MDFFiles', 
                                        SUM(CASE WHEN type_desc = 'LOG' THEN 1 ELSE 0 END) AS 'LDFFiles', 
                                        SUM(CASE WHEN type_desc = 'FILESTREAM' THEN 1 ELSE 0 END) AS 'FilestreamFiles', 
                                        SUM(CASE WHEN type_desc = 'ROWS' OR type_desc = 'LOG' OR type_desc = 'FILESTREAM' THEN 0 ELSE 1 END) AS 'NDFFiles', 
                                        SUM(CASE WHEN type_desc = 'ROWS' OR type_desc = 'LOG' OR type_desc = 'FILESTREAM' THEN 1 ELSE 0 END) AS 'GroupFiles' 
                                    FROM sys.master_files 
                                    WHERE database_id = DB_ID('{Dbname}');";
                    connection.Close();
                    using (SqlCommand command = new SqlCommand(query10, connection))
                    {

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int mdfFiles = Convert.ToInt32(reader["MDFFiles"]);
                            int ldfFiles = Convert.ToInt32(reader["LDFFiles"]);
                            int filestreamFiles = Convert.ToInt32(reader["FilestreamFiles"]);
                            int ndfFiles = Convert.ToInt32(reader["NDFFiles"]);
                            int groupFiles = Convert.ToInt32(reader["GroupFiles"]);

                            dbInfoPage.DbNoofFilesSystem.Text = $"{filestreamFiles}";
                            dbInfoPage.DbMdf.Text = $"{mdfFiles}";
                            dbInfoPage.DbNdf.Text = $"{ndfFiles}";
                            dbInfoPage.DbNoofLdf.Text = $"{ldfFiles}";
                            dbInfoPage.DbFileGroups.Text = $"{groupFiles}";

                        }
                        else
                        {

                            dbInfoPage.DbMdf.Text = "N/A";
                            dbInfoPage.DbNdf.Text = "N/A";
                        }
                    }


                    string query = "SELECT @@SERVERNAME AS ServerName";
                    connection.Close();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string? serverName = result.ToString();
                            dbInfoPage.DbServerName.Text = $"{serverName}";
                        }
                        else
                        {
                            dbInfoPage.DbServerName.Text = "N/A";
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Failed to open the connection.");
                }
                dbInfoPage.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.IsEnabled = false;
                DatabaseConnectionFailedPage databaseConnectionFailedPage = new DatabaseConnectionFailedPage();
                databaseConnectionFailedPage.ShowDialog();
                if (databaseConnectionFailedPage.OkButtonClicked)
                {
                    this.IsEnabled = true;
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }
        private void Tablesinfo(object sender, RoutedEventArgs e)
        {

            DatabaseTablesPage databaseTablesPage = new DatabaseTablesPage();
            databaseTablesPage.Show();
            this.Hide();

        }
        private void OtherDbInfo(object sender, RoutedEventArgs e)
        {

            connec();
           
        }

    }
}
