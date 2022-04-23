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

namespace MyHW
{
    public partial class threeview : Form
    {
        public threeview()
        {
            InitializeComponent();
            Creadtreeview();
        }

        private void Creadtreeview()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select country, city, customerID from Customers ";
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    HashSet<string> hs1 = new HashSet<string>();
                    HashSet<string> hs2 = new HashSet<string>();
                    TreeNode tree1 = new TreeNode();
                    TreeNode tree2 = new TreeNode();


                    while (reader.Read())
                    {
                        string colm1 = reader["Country"].ToString();
                        string colm2 = reader["City"].ToString();

                        if (hs1.Add(colm1))
                        {
                            tree1 = treeView1.Nodes.Add(colm1);
                            tree1.Name = colm1;

                            tree2 = new TreeNode(colm2);
                            tree2.Name = colm2;
                            hs2.Add(colm2);

                            tree1.Nodes.Add(tree2);
                        }
                        else if (hs2.Add(colm2))
                        {

                            tree2 = new TreeNode(colm2);
                            tree2.Name = colm2;
                            hs2.Add(colm2);

                            tree1.Nodes.Add(tree2);
                        }
                        
                    }             
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode n = e.Node;


            if (n.Parent == null)
            {
                customersTableAdapter1.FillByCountry(dataSet51.Customers, n.Name);
                dataGridView1.DataSource = dataSet51.Customers;
            }
            else if (n.Parent.Parent == null)
            {
                customersTableAdapter1.FillByCity(dataSet51.Customers, n.Name);
                dataGridView1.DataSource = dataSet51.Customers;
            }
            
        }
    }
}
