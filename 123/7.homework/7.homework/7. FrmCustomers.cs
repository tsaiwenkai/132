using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using _7.homework.Properties;

namespace MyHW
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();

            InputCombobox();
        }

        private void InputCombobox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MyNorthwind))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct Country from Customers", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["Country"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
        //TODO HW

        //1. All Country
       

        //================================
         //2. ContextMenuStrip2
         //選擇性作業
        //Groups
        //USA (100) 
        //UK (20)

        //this.listview1.visible = false;
        //ListViewItem lvi = this.listView1.Items.Add(dataReader[0].ToString());

        //if (this.listView1.Groups["USA"] == null)
        //{                       {
        //    ListViewGroup group = this.listView1.Groups.Add("USA", "USA"); //Add(string key, string headerText);
        //    group.Tag = 0;
        //    lvi.Group = group; 
        //}
        //else
        //{
        //    ListViewGroup group = this.listView1.Groups["USA"]; 
        //    lvi.Group = group;
        //}

        //this.listView1.Groups["USA"].Tag = 
        //this.listView1.Groups["USA"].Header = 
                                 
