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
    /// Interaction logic for add_student.xaml
    /// </summary>
    public partial class add_student : Page
    {
        public add_student()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=SHUVRO\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("insert into library(user_name,user_id,institution,password,borrow) values(@a,@b,@c,@d,@e)", sqlcon);

            cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = add_name.Text;
            cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = add_id.Text;
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = add_ins.Text;
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = add_pass.Text;
            cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = add_book.Text;

            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Student Added Successfully!");
            sqlcon.Close();
        }
    }
}
