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
    /// Interaction logic for books_view.xaml
    /// </summary>
    public partial class books_view : Page
    {
        public books_view()
        {
            InitializeComponent();
            table_books_func();
        }
        
        void table_books_func()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string sqlquery = "Select name as [Book Name],writer as [Written By],quantity as [Books Available] from books";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable("books");
            data_adapter.Fill(dt);
            table_books.ItemsSource = dt.DefaultView;
            data_adapter.Update(dt);
            sqlcon.Close();
        }

        private void table_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                txt_book_name.Text = row_selected["Book Name"].ToString();
                txt_book_writer.Text = row_selected["Written By"].ToString();
                txt_book_quantity.Text = row_selected["Books Available"].ToString();
            }
        }

        private void book_update_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "update books set writer=@b,quantity=@c  where name='" +txt_book_name.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = txt_book_name.Text;
            sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = txt_book_writer.Text;
            sqlcmd.Parameters.Add("@c", SqlDbType.VarChar).Value = txt_book_quantity.Text;

            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            table_books_func();
            if (rows == 1)
                MessageBox.Show("Information Has Updated.");
        }

        private void book_delete_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "delete from books where name= @x";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@x", SqlDbType.VarChar).Value = txt_book_name.Text;
            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            table_books_func();
            if (rows > 0)
                MessageBox.Show("Information Has Deleted.");
        }
    }
}
