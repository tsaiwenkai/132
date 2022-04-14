using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyHomeWork
{
    public partial class FrmAdventureWorks : Form
    {
        public FrmAdventureWorks()
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True");
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "select distinct datepart(yyyy,[ModifiedDate]) as 'year' " +
                " FROM Production.ProductPhoto" +
                " group by datepart(yyyy,[ModifiedDate])"
                , conn);
            DataTable da = new DataTable();
            dataAdapter.Fill(da);


            comboBox1.DataSource = da;
            comboBox1.DisplayMember = "year";
            //-------------------------------------------------------------------------------------
            productPhotoTableAdapter1.Fill(dataSet21.ProductPhoto);
            dataGridView1.DataSource = dataSet21.ProductPhoto;
            bindingSource1.DataSource = dataSet21.ProductPhoto;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        //void dateyear()
        //{
        //    comboBox1.DataSource = dataSet21.ProductPhoto;
        //    comboBox1.DisplayMember = "ModifiedDate";
        //    dataGridView1.DataSource =
        //}

        private void button15_Click(object sender, EventArgs e)
        {
            bindingSource1.Position += 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bindingSource1.Position -= 1;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bindingSource1.Position =dataSet21.ProductPhoto.Count-1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            label4.Text = $"{bindingSource1.Position + 1}/{dataSet21.ProductPhoto.Count}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime x = dateTimePicker1.Value;
            DateTime y = dateTimePicker2.Value;
            productPhotoTableAdapter1.Filldate(dataSet21.ProductPhoto, x, y);
        }
        bool O = true;
        private void button2_Click(object sender, EventArgs e)
        {         
            if (O == true)
            {
                dataGridView1.Sort(dataGridView1.Columns["ProductPhotoID"], ListSortDirection.Descending);

            }
            else
            {
                dataGridView1.Sort(dataGridView1.Columns["ProductPhotoID"], ListSortDirection.Ascending);

            }
            O = !O;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yyyy = comboBox1.Text;
            productPhotoTableAdapter1.Filldateyear(dataSet21.ProductPhoto, yyyy);

        }
    }
}
