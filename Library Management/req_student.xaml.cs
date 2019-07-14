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
    /// Interaction logic for req_student.xaml
    /// </summary>
    public partial class req_student : Page
    {
        public req_student()
        {
            InitializeComponent();
        }

        private void req_u_name_GotFocus(object sender, RoutedEventArgs e)
        {
            req_u_name.Text = "";
        }

        private void req_stu_id_GotFocus(object sender, RoutedEventArgs e)
        {
            req_stu_id.Text = "";
        }

        private void req_ins_GotFocus(object sender, RoutedEventArgs e)
        {
            req_ins.Text = "";
        }

        private void req_pass_GotFocus(object sender, RoutedEventArgs e)
        {
            req_pass.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("insert into req_stu(req_u_name,req_u_id,req_institution,password) values(@a,@b,@c,@d)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = req_u_name.Text;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = req_stu_id.Text;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = req_ins.Text;
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = req_pass.Text;

            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Request Sent Successfully!");
            sqlcon.Close();
        }

        private void req_exit_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
