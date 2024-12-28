using Microsoft.Data.SqlClient;
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

namespace Database_Viewer
{
    /// <summary>
    /// Interaction logic for DatabaseTablesPage.xaml
    /// </summary>
    public partial class DatabaseTablesPage : Window
    {
        public static string? tableNameContent;
        public static string[] tablesnames = GetTableNames(ConnectionStringPage.connectionString);
        public DatabaseTablesPage()
        {
            InitializeComponent();
            CreateRowsAndColumnsInSpecificWrapPanel();
        }

        public static string[] GetTableNames(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create a dynamic list to store table names
                        var tableNames = new System.Collections.Generic.List<string>();

                        // Read table names from the SqlDataReader and add them to the list
                        while (reader.Read())
                        {
                            string tableName = reader.GetString(0);
                            tableNames.Add(tableName);
                        }

                        // Convert the list to an array before returning
                        return tableNames.ToArray();
                    }
                }
            }
        }



        private void CreateRowsAndColumnsInSpecificWrapPanel()
        {
          string[] tablesnamess = GetTableNames(ConnectionStringPage.connectionString);

        int columnsPerRow = tablesnamess.Length / 2;

            for (int i = 0; i < (tablesnamess.Length / 2) + 1; i++)
            {
                WrapPanel rowPanel = new WrapPanel();
                rowPanel.Orientation = Orientation.Horizontal;

                for (int j = 0; j < columnsPerRow; j++)
                {
                    int index = i * columnsPerRow + j;
                    if (index < tablesnamess.Length)
                    {
                        Button button = new Button
                        {
                            Content = tablesnamess[index],
                            Style = (Style)FindResource("HoverButtonStyle"),
                        };
                        button.Click += (sender, e) =>
                        {
                            Button clickedButton = (Button)sender;
                            tableNameContent = clickedButton.Content.ToString();

                            // Create an instance of the new form
                            ColumnsPage columnsPage = new ColumnsPage();

                            columnsPage.Show();
                            this.Close();
                        };

                        rowPanel.Children.Add(button);
                    }
                }
                buttonPanel.Children.Add(rowPanel);
            }
        }




        #region Buttons In The Header Of The Page (Move , Minimize , Close) The App

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

        #endregion


        private void Backbtn(object sender, RoutedEventArgs e)
        {
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
