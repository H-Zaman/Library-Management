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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
namespace Library_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
            this.Close();
        }

        private void pass_login_password_GotFocus(object sender, RoutedEventArgs e)
        {
            pass_login_password.Password = "";
        }

        private void txt_login_user_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_login_user.Text = "";
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            sqlcon.Open();
            string commandstring = "select user_id,password from library";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            SqlDataReader read = sqlcmd.ExecuteReader();
            int i = 0;
            if(txt_login_user.Text=="admin" && pass_login_password.Password == "admin")
            {
                i = 1;
                admin_panel ap = new admin_panel();
                ap.Show();
                this.Close();
            }
            while (read.Read())
            {
                if (read[0].ToString() == txt_login_user.Text && read[1].ToString() == pass_login_password.Password)
                {
                    i = 1;
                    user_panel up = new user_panel();
                    my_books mb = new my_books();
                    string ab;
                    ab = txt_login_user.Text;
                    up.up_loggd_user.Text = ab;
                    up.Show();
                    this.Close();
                }


            }
            if (i == 0)
            {
                MessageBox.Show("Incorrect data","Error");
            }

            sqlcon.Close();
        }

        private void req_button_Click(object sender, RoutedEventArgs e)
        {
            req_frame.NavigationService.Navigate(new req_student());
        }
    }
}
