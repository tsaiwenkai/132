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
using MyHW.Properties;

namespace MyHW
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
            this.listView1.View = View.Details;
            InputCombobox();
            CreadListview();
        }

        private void CreadListview()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();// ("select * from Customers where CountryName=", conn);
                    command.CommandText = $"select * from Customers ";
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable da = reader.GetSchemaTable();
                    listView1.Columns.Clear();
                    for(int i = 0; i < da.Rows.Count; i++)
                    {
                        listView1.Columns.Add(da.Rows[i][0].ToString());
                    }
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void InputCombobox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct Country from Customers", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    comboBox1.Items.Add("All");
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["Country"]);
                    }
                   
                    comboBox1.SelectedItem ="All";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreadListview();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();// ("select * from Customers where Country='comboBox1.Text' ", conn);                  
                    command.CommandText = $" select * from Customers where Country='{comboBox1.Text}' ";
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem Lvi = new ListViewItem();
                        
                        Lvi = listView1.Items.Add(reader[0].ToString());
                        if (this.listView1.Groups[reader["Country"].ToString()] == null)
                        {
                            ListViewGroup group = this.listView1.Groups.Add(reader["Country"].ToString(), reader["Country"].ToString());
                            Lvi.Group = group;
                            
                        }
                        else
                        {
                            ListViewGroup group = this.listView1.Groups[reader["Country"].ToString()];
                            //group.Tag = 0;
                            Lvi.Group = group;
                        }

                        //listView1.Groups[reader["Country"].ToString()].Tag = 0;
                       


                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            if (reader.IsDBNull(i))
                            {
                                Lvi.SubItems.Add("null");
                            }
                            else
                            {
                                Lvi.SubItems.Add(reader[i].ToString());
                            }
                        }

                    }


                    for(int i = 0; i < listView1.Groups.Count; i++)
                    {
                        this.listView1.Groups[i].Header = $"{listView1.Groups[i].Name}({listView1.Groups[i].Count})";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (comboBox1.Text == "All")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();// ("select * from Customers where Country='comboBox1.Text' ", conn);                  
                        command.CommandText = $" select * from Customers";
                        command.Connection = conn;
                        SqlDataReader reader = command.ExecuteReader();
                        listView1.Items.Clear();
                        while (reader.Read())
                        {                     
                            ListViewItem Lvi = listView1.Items.Add(reader[0].ToString());
                            if (this.listView1.Groups[reader["Country"].ToString()] == null)
                            {
                                ListViewGroup group = this.listView1.Groups.Add(reader["Country"].ToString(), reader["Country"].ToString());
                                Lvi.Group = group;
                            }
                            else
                            {
                                ListViewGroup group = this.listView1.Groups[reader["Country"].ToString()];
                                Lvi.Group = group;
                            }

                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                if (reader.IsDBNull(i))
                                {
                                    Lvi.SubItems.Add("null");
                                }
                                else
                                {
                                    Lvi.SubItems.Add(reader[i].ToString());
                                }
                            }                        
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void customerIDAscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreadListview();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();// ("select * from Customers where Country='comboBox1.Text' ", conn);
                    command.CommandText = $" select * from Customers where Country='{comboBox1.Text}' order by CustomerID";
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem Lvi = listView1.Items.Add(reader[0].ToString());
                        if (this.listView1.Groups[reader["Country"].ToString()] == null)
                        {
                            ListViewGroup group = this.listView1.Groups.Add(reader["Country"].ToString(), reader["Country"].ToString());
                            Lvi.Group = group;
                        }
                        else
                        {
                            ListViewGroup group = this.listView1.Groups[reader["Country"].ToString()];
                            Lvi.Group = group;
                        }
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            if (reader.IsDBNull(i))
                            {
                                Lvi.SubItems.Add("null");
                            }
                            else
                            {
                                Lvi.SubItems.Add(reader[i].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (comboBox1.Text == "All")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();// ("select * from Customers where Country='comboBox1.Text' ", conn);                  
                        command.CommandText = $" select * from Customers  order by CustomerID";
                        command.Connection = conn;
                        SqlDataReader reader = command.ExecuteReader();
                        listView1.Items.Clear();
                        while (reader.Read())
                        {
                            ListViewItem Lvi = listView1.Items.Add(reader[0].ToString());
                            if (this.listView1.Groups[reader["Country"].ToString()] == null)
                            {
                                ListViewGroup group = this.listView1.Groups.Add(reader["Country"].ToString(), reader["Country"].ToString());
                                Lvi.Group = group;
                            }
                            else
                            {
                                ListViewGroup group = this.listView1.Groups[reader["Country"].ToString()];
                                Lvi.Group = group;
                            }
                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                if (reader.IsDBNull(i))
                                {
                                    Lvi.SubItems.Add("null");
                                }
                                else
                                {
                                    Lvi.SubItems.Add(reader[i].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        private void customerIDDescToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreadListview();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();// ("select * from Customers where Country='comboBox1.Text' ", conn);
                    command.CommandText = $" select * from Customers where Country='{comboBox1.Text}' order by CustomerID desc";
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem Lvi = listView1.Items.Add(reader[0].ToString());
                        if (this.listView1.Groups[reader["Country"].ToString()] == null)
                        {
                            ListViewGroup group = this.listView1.Groups.Add(reader["Country"].ToString(), reader["Country"].ToString());
                            Lvi.Group = group;
                        }
                        else
                        {
                            ListViewGroup group = this.listView1.Groups[reader["Country"].ToString()];
                            Lvi.Group = group;
                        }
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            if (reader.IsDBNull(i))
                            {
                                Lvi.SubItems.Add("null");
                            }
                            else
                            {
                                Lvi.SubItems.Add(reader[i].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (comboBox1.Text == "All")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();// ("select * from Customers where Country='comboBox1.Text' ", conn);                  
                        command.CommandText = $" select * from Customers  order by CustomerID desc";
                        command.Connection = conn;
                        SqlDataReader reader = command.ExecuteReader();
                        listView1.Items.Clear();
                        while (reader.Read())
                        {
                            ListViewItem Lvi = listView1.Items.Add(reader[0].ToString());
                            if (this.listView1.Groups[reader["Country"].ToString()] == null)
                            {
                                ListViewGroup group = this.listView1.Groups.Add(reader["Country"].ToString(), reader["Country"].ToString());
                                Lvi.Group = group;
                            }
                            else
                            {
                                ListViewGroup group = this.listView1.Groups[reader["Country"].ToString()];
                                Lvi.Group = group;
                            }
                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                if (reader.IsDBNull(i))
                                {
                                    Lvi.SubItems.Add("null");
                                }
                                else
                                {
                                    Lvi.SubItems.Add(reader[i].ToString());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void countryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();// ("select * from Customers where CountryName=", conn);
                    command.CommandText = $"select count([Country]) as Count ,[Country] from Customers  group by[Country]";
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable da = reader.GetSchemaTable();
                    listView1.Columns.Clear();
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        listView1.Columns.Add(da.Rows[i][0].ToString());
                    }
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();// ("select * from Customers where Country='comboBox1.Text' ", conn);
                    command.CommandText = $" select count([Country]) ,[Country] from Customers where Country='{comboBox1.Text}' group by[Country] ";
                    command.Connection = conn;
                    SqlDataReader reader = command.ExecuteReader();
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem Lvi = listView1.Items.Add(reader[0].ToString());
                        for (int i = 1; i < reader.FieldCount; i++)
                        {
                            if (reader.IsDBNull(i))
                            {
                                Lvi.SubItems.Add("null");
                            }
                            else
                            {
                                Lvi.SubItems.Add(reader[i].ToString());
                            }
                        }
                        //換顏色
                        if (Lvi.Index % 2 == 0)
                        {
                            Lvi.BackColor = Color.DarkGray;
                        }
                        else
                        {
                            Lvi.BackColor = Color.Crimson;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (comboBox1.Text == "All")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();// ("select * from Customers where Country='comboBox1.Text' ", conn);                  
                        command.CommandText = $"  select count([Country]) ,[Country] from Customers  group by[Country] ";
                        command.Connection = conn;
                        SqlDataReader reader = command.ExecuteReader();
                        listView1.Items.Clear();
                        while (reader.Read())
                        {
                            ListViewItem Lvi = listView1.Items.Add(reader[0].ToString());
                            for (int i = 1; i < reader.FieldCount; i++)
                            {
                                if (reader.IsDBNull(i))
                                {
                                    Lvi.SubItems.Add("null");
                                }
                                else
                                {
                                    Lvi.SubItems.Add(reader[i].ToString());
                                }
                            }
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
                                 
