using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ColumnsPage.xaml
    /// </summary>
    public partial class ColumnsPage : Window
    {
        public static string[] tablesnames = GetColumnNames(ConnectionStringPage.connectionString, DatabaseTablesPage.tableNameContent);
        public ColumnsPage()
        {
            InitializeComponent();

            CreateRowsAndColumnsInSpecificWrapPanel();
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



        public static string[] GetColumnNames(string connectionString, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}';";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create a dynamic list to store column names
                        var columnNames = new List<string>();

                        // Read column names from the SqlDataReader and add them to the list
                        while (reader.Read())
                        {
                            string columnName = reader.GetString(0);
                            columnNames.Add(columnName);
                        }

                        // Convert the list to an array before returning
                        return columnNames.ToArray();
                    }
                }
            }
        }




        private void CreateRowsAndColumnsInSpecificWrapPanel()
        {
         string[] tablesnamess = GetColumnNames(ConnectionStringPage.connectionString, DatabaseTablesPage.tableNameContent);

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
                        };

                        rowPanel.Children.Add(button);
                    }
                }
                buttonPanel.Children.Add(rowPanel);
            }
        }




        private void TableContent_Click(object sender, RoutedEventArgs e)
        {

            UpdateTablesContentPage updateTablesContentPage = new UpdateTablesContentPage();
            updateTablesContentPage.Show();
            this.Hide();

        }
        private void Backbtn(object sender, RoutedEventArgs e)
        {
            tablesnames = null;
            DatabaseTablesPage databaseTablesPage = new DatabaseTablesPage();
            databaseTablesPage.Show();
            this.Hide();
        }


    }
}
