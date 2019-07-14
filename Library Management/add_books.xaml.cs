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
    /// Interaction logic for add_books.xaml
    /// </summary>
    public partial class add_books : Page
    {
        public add_books()
        {
            InitializeComponent();
        }

        private void add_book_button_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("insert into books(name,writer,quantity) values(@a,@b,@c)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = add_book_name.Text;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = add_book_writer.Text;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = add_book_quantity.Text;

            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Book Added Successfully!");
            sqlcon.Close();
        }
    }
}
