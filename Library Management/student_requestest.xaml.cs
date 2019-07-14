using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for student_requestest.xaml
    /// </summary>
    public partial class student_requestest : Page
    {
        public student_requestest()
        {
            InitializeComponent();
            table_view();
        }
        void table_view()
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            string sqlquery = "Select req_u_name as [Student Name],req_u_id as [Student ID],req_institution as Institution,password as Password from req_stu";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter data_adapter = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable("req_stu");
            data_adapter.Fill(dt);
            req_table.ItemsSource = dt.DefaultView;
            data_adapter.Update(dt);
            sqlcon.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string con = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand("insert into library(user_name,user_id,institution,password) values(@a,@b,@c,@d)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = stureq_name.Text;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = stureq_id.Text;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = stureq_ins.Text;
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = stureq_pass.Text;
            
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                string commandstring = "delete from req_stu where req_u_id= @x";
                SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
                sqlcmd.Parameters.Add("@x", SqlDbType.VarChar).Value = stureq_id.Text;
                int rowss = sqlcmd.ExecuteNonQuery();
                table_view();
                if (rowss > 0)
                    MessageBox.Show("Student Added Successfully!");
            }
            sqlcon.Close();
        }


        private void req_table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView row_selected = dg.SelectedItem as DataRowView;

            if (row_selected != null)
            {
               stureq_name.Text = row_selected["Student Name"].ToString();
               stureq_id.Text = row_selected["Student ID"].ToString();
               stureq_ins.Text = row_selected["Institution"].ToString();
               stureq_pass.Text = row_selected["Password"].ToString();
            }
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            string commandstring = "delete from req_stu where req_u_id= @x";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            sqlcmd.Parameters.Add("@x", SqlDbType.VarChar).Value = stureq_id.Text;
            sqlcon.Open();
            int rows = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            table_view();
            if (rows > 0)
                MessageBox.Show("Information Has Deleted.");
        }
    }
}
