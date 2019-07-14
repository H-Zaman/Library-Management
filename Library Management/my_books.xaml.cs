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
    /// Interaction logic for my_books.xaml
    /// </summary>
    public partial class my_books : Page
    {
        public my_books()
        {
            InitializeComponent();
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string sqlquery = "Select b_name as [Book Name],b_writer as [Writer] from books_away WHERE stu_id='"+user_panel.xx+"' ";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
            
            SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable("books_away");
            data_adapter.Fill(dt);
            my_books_grid.ItemsSource = dt.DefaultView;
            data_adapter.Update(dt);
            sqlcon.Close();
        }
    }
}
