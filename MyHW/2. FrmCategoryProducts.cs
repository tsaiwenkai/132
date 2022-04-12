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
    public partial class FrmCategoryProducts : Form
    {
        public FrmCategoryProducts()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select CategoryName from Categories", conn);
            DataTable da = new DataTable();
            dataAdapter.Fill(da);
            comboBox1.DataSource = da;
            comboBox1.DisplayMember = "CategoryName";
            conn.Close();
            //comboBox1.Items.Add(dataReader["CategoryName"]);
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // this.comboBox1.Text          
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");

            conn.Open();

            SqlCommand command = new SqlCommand
                ("select * from [dbo].[Categories] c" +
                " join [dbo].[Products]  p" +
                " on c.[CategoryID]=p.[CategoryID] "+
                "where [CategoryName]=" +"'" +comboBox1.Text+"'"
                , conn);

            SqlDataReader dataReader = command.ExecuteReader();
            //-------------------------------------------------------------------------------------------
            listBox1.Items.Clear();
            while (dataReader.Read())
            {
               
                string s = $"{dataReader["ProductName"]} - {dataReader["UnitPrice"]} ";
                listBox1.Items.Add(s);
                //dataGridView1.DataSource = da.Tables[0];
            }

            conn.Close();


        }
    }
}
