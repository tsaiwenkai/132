using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class Dataset : Form
    {
        public Dataset()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            productsTableAdapter1.Fill(dataSet11.Products);
            categoriesTableAdapter1.Fill(dataSet11.Categories);
            customersTableAdapter1.Fill(dataSet11.Customers);

            dataGridView4.DataSource = dataSet11.Products;
            dataGridView5.DataSource = dataSet11.Categories;
            dataGridView6.DataSource = dataSet11.Customers;
            //-----------------------------------------------------------
            listBox2.Items.Clear();
            for(int i=0;i<= dataSet11.Tables.Count - 1; i++)
            {
                DataTable table = dataSet11.Tables[i];
                listBox2.Items.Add(table.TableName);
                string s = "";
                for(int column = 0; column <= table.Columns.Count - 1; column++)
                {
                    s +=$"{table.Columns[column].ColumnName,-30}";
                }
                listBox2.Items.Add(s);
                listBox2.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------");


                for (int row = 0; row < table.Rows.Count - 1; row++)
                {
                    string x = "";
                    for (int j = 0; j <= table.Columns.Count - 1; j++)
                    {
                        x += $"{table.Rows[row][j],-30}";
                    }
                    listBox2.Items.Add(x);
                }


                listBox2.Items.Add("=============================================================================");
            }
        }
    }
}
