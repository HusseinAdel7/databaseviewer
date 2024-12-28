using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Database_Viewer
{
    /// <summary>
    /// Interaction logic for DatabaseInfoPage.xaml
    /// </summary>
    public partial class DatabaseInfoPage : Window
    {
        public DatabaseInfoPage()
        {
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

        private void Backbtn(object sender, RoutedEventArgs e)
        {
            
            Inforamtion information = new Inforamtion("");
            information.Show();
            information.Hide();


            

            SqlConnection connection = new SqlConnection(ConnectionStringPage.connectionString);
                try
                {
                    connection.Open();
                    Inforamtion inforamtion = new Inforamtion(ConnectionStringPage.connectionString);
                    if (connection.State == ConnectionState.Open)
                    {
                        // Count Schemas
                        string querySchemas = "SELECT COUNT(*) AS 'Total Schemas' FROM sys.schemas;";
                        using (SqlCommand commandSchemas = new SqlCommand(querySchemas, connection))
                        {
                            int totalSchemas = (int)commandSchemas.ExecuteScalar();
                            inforamtion.Schemasnum.Content = $"{totalSchemas}";
                        }

                        // Count Tables
                        string queryTables = "SELECT COUNT(*) AS 'Total Tables' FROM sys.tables;";
                        using (SqlCommand commandTables = new SqlCommand(queryTables, connection))
                        {
                            int totalTables = (int)commandTables.ExecuteScalar();
                            inforamtion.Tablesnum.Content = $"{totalTables}";
                        }

                        // Count Views
                        string queryViews = "SELECT COUNT(*) AS 'Total Views' FROM sys.views;";
                        using (SqlCommand commandViews = new SqlCommand(queryViews, connection))
                        {
                            int totalViews = (int)commandViews.ExecuteScalar();
                            inforamtion.Viewsnum.Content = $"{totalViews}";
                        }

                        // Count Procedures
                        string queryProcedures = "SELECT COUNT(*) AS 'Total Procedures' FROM sys.procedures;";
                        using (SqlCommand commandProcedures = new SqlCommand(queryProcedures, connection))
                        {
                            int totalProcedures = (int)commandProcedures.ExecuteScalar();
                            inforamtion.Proceduresnum.Content = $"{totalProcedures}";
                        }

                        // Count Functions
                        string queryFunctions = "SELECT COUNT(*) AS 'Total Functions' FROM sys.objects WHERE type IN ('FN', 'IF', 'TF');";
                        using (SqlCommand commandFunctions = new SqlCommand(queryFunctions, connection))
                        {
                            int totalFunctions = (int)commandFunctions.ExecuteScalar();
                            inforamtion.Functionsnum.Content = $"{totalFunctions}";
                        }

                        // Count Triggers
                        string queryTriggers = "SELECT COUNT(*) AS 'Total Triggers' FROM sys.triggers;";
                        using (SqlCommand commandTriggers = new SqlCommand(queryTriggers, connection))
                        {
                            int totalTriggers = (int)commandTriggers.ExecuteScalar();
                            inforamtion.Triggersum.Content = $"{totalTriggers}";
                        }

                        // Count Indexes
                        string queryIndexes = "SELECT COUNT(*) AS 'Total Indexes' FROM sys.indexes;";
                        using (SqlCommand commandIndexes = new SqlCommand(queryIndexes, connection))
                        {
                            int totalIndexes = (int)commandIndexes.ExecuteScalar();
                            inforamtion.Indexesnum.Content = $"{totalIndexes}";
                        }

                        // Count Rules
                        string queryRules = "SELECT COUNT(*) AS 'Total Rules' FROM sys.objects WHERE type = 'R';";
                        using (SqlCommand commandRules = new SqlCommand(queryRules, connection))
                        {
                            int totalRules = (int)commandRules.ExecuteScalar();
                            inforamtion.Rulesnum.Content = $"{totalRules}";
                        }

                    }
                    else
                    {
                        Console.WriteLine("Failed to open the connection.");
                    }
                    inforamtion.Show();
                    this.Hide();
                }
                catch
                {
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

    }
}
