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
    /// Interaction logic for admin_book_away.xaml
    /// </summary>
    public partial class admin_book_away : Page
    {
        public static string studentId;
        public static string bookName;
        public static string bookWriter;

        public admin_book_away()
        {
            InitializeComponent();
            table_view();

        }
        void table_view()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string sqlquery = "Select stu_id as [Student ID],b_name as [Book Name],b_writer as [Book Writer] from books_away";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable("books_away");
            data_adapter.Fill(dt);
            grid_admin_book_away.ItemsSource = dt.DefaultView;
            data_adapter.Update(dt);
            sqlcon.Close();
        }

        private void btn_retrunBook_Click(object sender, RoutedEventArgs e)
        {
            stu_table_update();
            book_table_update();
            book_away();
        }

        private void grid_admin_book_away_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                studentId = row_selected["Student ID"].ToString();
                bookName = row_selected["Book Name"].ToString();
                bookWriter = row_selected["Book Writer"].ToString();
            }
        }
        void stu_table_update()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string commandstring = "UPDATE library set borrow=borrow-1 WHERE user_id='" +studentId + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        void book_table_update()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string commandstring = "UPDATE books set quantity=quantity+1 WHERE name='" + bookName + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        void book_away()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string commandstring = "DELETE from books_away WHERE stu_id=@x";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@x", SqlDbType.VarChar).Value = studentId;

            int rowss = sqlcmd.ExecuteNonQuery();
            table_view();
            if (rowss > 0)
                MessageBox.Show("Book Returned Successfully!");
        }
    }
}
