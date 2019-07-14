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

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for admin_panel.xaml
    /// </summary>
    public partial class admin_panel : Window
    {
        public admin_panel()
        {
            InitializeComponent();
        }

        private void student_page(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new student());
        }
        private void logout_click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new search());
        }

        private void add_student_page(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new add_student());
        }

        private void view_books(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new books_view());
        }

        private void add_book(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new add_books());
        }

        private void student_req(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new student_requestest());
        }

        private void help(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new help_page());
        }

        private void abt_us(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new abt_us());
        }

        private void lendBook(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new lend_book());
        }

        private void bookAway(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new admin_book_away());            
        }
    }
}
