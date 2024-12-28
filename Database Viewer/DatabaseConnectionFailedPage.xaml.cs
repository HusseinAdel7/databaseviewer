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
    /// Interaction logic for DatabaseConnectionFailedPage.xaml
    /// </summary>
    public partial class DatabaseConnectionFailedPage : Window
    {
        public bool OkButtonClicked { get; private set; }
        public DatabaseConnectionFailedPage()
        {
            InitializeComponent();
        }

        private void Okbtn(object sender, RoutedEventArgs e)
        {
            OkButtonClicked = true;
            this.Close();
        }
    }
}
