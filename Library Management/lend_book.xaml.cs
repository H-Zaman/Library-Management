using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for lend_book.xaml
    /// </summary>
    public partial class lend_book : Page
    {
        public lend_book()
        {
            InitializeComponent();

            stu_view();
            book_view();
            
        }
        void stu_view()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string sqlquery = "Select user_id as [Student ID] from library";

            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable("library");

            data_adapter.Fill(dt);
            grid_lend_stu.ItemsSource = dt.DefaultView;
            data_adapter.Update(dt);
            sqlcon.Close();
        }
        void book_view()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string sqlquery2 = "Select name as [Book Name],writer as Writer from books";

            SqlCommand sqlcmd2 = new SqlCommand(sqlquery2, sqlcon);
            SqlDataAdapter data_adapter2 = new SqlDataAdapter(sqlcmd2);
            DataTable dt2 = new DataTable("books");

            data_adapter2.Fill(dt2);
            grid_lend_books.ItemsSource = dt2.DefaultView;
            data_adapter2.Update(dt2);

            sqlcon.Close();
        }

        private void grid_lend_stu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                lend_stuName.Text = row_selected["Student ID"].ToString();
            }
        }

        private void grid_lend_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                lend_bookName.Text = row_selected["Book Name"].ToString();
                lend_bookWriter.Text = row_selected["Writer"].ToString();
            }
        }

        private void button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            stu_table_update();
            book_table_update();
            book_away();
            MessageBox.Show("Book Given.","Notification");
        }
        void stu_table_update()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string commandstring = "UPDATE library set borrow=borrow+1 WHERE user_id='" + lend_stuName.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        void book_table_update()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string commandstring = "UPDATE books set quantity=quantity-1 WHERE name='" + lend_bookName.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        void book_away()
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("insert into books_away(stu_id,b_name,b_writer) values(@a,@b,@c)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = lend_stuName.Text;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = lend_bookName.Text;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = lend_bookWriter.Text;

            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
               
            sqlcon.Close();
        }
    }
    }