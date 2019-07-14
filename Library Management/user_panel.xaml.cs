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
using System.Data;
using System.Data.SqlClient;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for user_panel.xaml
    /// </summary>
    public partial class user_panel : Window
    {
        public static string xx;
        public user_panel()
        {
            InitializeComponent();
        }

        private void myBookClick(object sender, RoutedEventArgs e)
        {
            xx = up_loggd_user.Text;
            u_frame.NavigationService.Navigate(new my_books());
        }

        private void LibraryClick(object sender, RoutedEventArgs e)
        {
            u_frame.NavigationService.Navigate(new user_book_view());
        }

        private void logfkingout(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
