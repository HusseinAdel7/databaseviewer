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
    /// Interaction logic for UpdateTablesContentPage.xaml
    /// </summary>
    public partial class UpdateTablesContentPage : Window
    {
        public UpdateTablesContentPage()
        {
            InitializeComponent();
            FillDataGrid(ConnectionStringPage.connectionString, DatabaseTablesPage.tableNameContent);
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

        private void FillDataGrid(string connectionString, string tableName)
        {
            string query = $"SELECT * FROM {tableName}";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    TableContentColumns.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void Backbtn(object sender, RoutedEventArgs e)
        {
            ColumnsPage columnsPage = new ColumnsPage();
            columnsPage.Show();
            this.Hide();
        }
    }
}
