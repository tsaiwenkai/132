﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyHW
{
    public partial class FrmMyAlbum_V1 : Form
    {
        public FrmMyAlbum_V1()
        {
            InitializeComponent();

            cityNameTableAdapter1.Fill(dataSet31.CityName);
            

            for (int i = 0; i < dataSet31.CityName.Rows.Count; i++)
            {
                LinkLabel x = new LinkLabel();
                x.Text = $"{dataSet31.CityName[i]["CityName"]}";
                x.Left = 5;
                x.Top = 30*i;

                x.Click += X_Click;
                panel1.Controls.Add(x);

                 
            }
            
        }

        private void X_Click(object sender, EventArgs e)
        {
            LinkLabel x = sender as LinkLabel;
            pictureTableAdapter1.FillCityname(dataSet31.Picture,x.Text);
            dataGridView1.DataSource = dataSet31.Picture;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}