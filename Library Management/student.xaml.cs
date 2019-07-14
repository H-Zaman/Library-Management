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
    /// Interaction logic for student.xaml
    /// </summary>
    public partial class student : Page
    {
        public student()
        {
            InitializeComponent();
            table_view();
        }
        
        void table_view()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string sqlquery = "Select user_name as [Student Name],user_id as [Student ID],institution as Institution,password as Password,borrow as [Books Borrowed] from library";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable("library");
            data_adapter.Fill(dt);
            student_table.ItemsSource = dt.DefaultView;
            data_adapter.Update(dt);
            sqlcon.Close();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "update library set user_name=@a,institution=@b,password=@c,borrow=@d  where user_id='" +txt_stu_id.Text+ "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@a", SqlDbType.VarChar).Value = txt_stu_name.Text;
            sqlcmd.Parameters.Add("@b", SqlDbType.VarChar).Value = txt_stu_ins.Text;
            sqlcmd.Parameters.Add("@c", SqlDbType.VarChar).Value = txt_stu_pass.Text;
            sqlcmd.Parameters.Add("@d", SqlDbType.VarChar).Value = txt_stu_borrow.Text;

            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            table_view();
            if (rows == 1)
                MessageBox.Show("Information Has Updated.");
        }

        private void student_table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
                txt_stu_name.Text = row_selected["Student Name"].ToString();
                txt_stu_id.Text = row_selected["Student ID"].ToString();
                txt_stu_ins.Text = row_selected["Institution"].ToString();
                txt_stu_pass.Text = row_selected["Password"].ToString();
                txt_stu_borrow.Text = row_selected["Books Borrowed"].ToString();
            }
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "delete from library where user_id= @x";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@x", SqlDbType.VarChar).Value =txt_stu_id.Text;
            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
           table_view();
            if (rows > 0)
                MessageBox.Show("Information Has Deleted.");
        }
    }
}
