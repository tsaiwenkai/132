using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
            productsTableAdapter1.Fill(dataSet11.Products);
            bindingSource1.DataSource = dataSet11.Products;
            dataGridView1.DataSource = bindingSource1;
            //bindingNavigator1.BindingSource = bindingSource1;
            lblResult.Text = $"結果: {dataSet11.Products.Count}筆";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(textBox1.Text);
                int y = int.Parse(textBox2.Text);

                productsTableAdapter1.Fillbetween(dataSet11.Products, x, y);
                bindingSource1.DataSource = dataSet11.Products;
                dataGridView1.DataSource = bindingSource1;
                lblResult.Text = $"結果: {x}元~{y}元 總共有{dataSet11.Products.Count}筆";
                //bindingNavigator1.BindingSource = bindingSource1;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            if (name != "")
            {
                productsTableAdapter1.Filllikename(dataSet11.Products, "%" + name + "%");
                bindingSource1.DataSource = dataSet11.Products;
                dataGridView1.DataSource = bindingSource1;
                lblResult.Text = $"結果: 名子內包含{name}的總共有{dataSet11.Products.Count}筆";
                //bindingNavigator1.BindingSource = bindingSource1;
            }
            else
            {
                MessageBox.Show("請輸入字元");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bindingSource1.Position += 1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            label2.Text = $"{bindingSource1.Position + 1}/{dataSet11.Products.Count}";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bindingSource1.Position -= 1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = dataSet11.Products.Count-1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
        }
    }   
}
