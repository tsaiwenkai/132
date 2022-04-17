using MyHW;
using MyHW.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class FrmLogon : Form
    {
        public FrmLogon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    string U = UsernameTextBox.Text;
                    string P = PasswordTextBox.Text;
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = $"Insert into MyMember (UserName,Password) Values (@UserName,@Password)";
                    comm.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = U;
                    comm.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = U;
                    comm.Connection = conn;
                    conn.Open();
                    comm.ExecuteNonQuery();
                    MessageBox.Show("CreadMember Sucessfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    string U = UsernameTextBox.Text;
                    string P = PasswordTextBox.Text;

                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from MyMember where UserName=@UserName and PassWord=@Password";
                    command.Connection = conn;
                    command.Parameters.Add("UserName", SqlDbType.NVarChar, 16).Value = U;
                    command.Parameters.Add("PassWord", SqlDbType.NVarChar, 40).Value = P;
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        FrmCustomers Fc = new FrmCustomers();
                        Fc.Show();
                    }
                    else
                    {
                        MessageBox.Show("登入失敗");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
