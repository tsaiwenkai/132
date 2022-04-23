using MyHomeWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MyHW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmHomeWork fw = new FrmHomeWork();
            fw.TopLevel = false;
            fw.Visible = true;
            splitContainer2.Panel2.Controls.Add(fw);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmCategoryProducts fcp = new FrmCategoryProducts();
            fcp.TopLevel = false;
            fcp.Visible = true;
            splitContainer2.Panel2.Controls.Add(fcp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmProducts fp = new FrmProducts();
            fp.TopLevel = false;
            fp.Visible = true;
            splitContainer2.Panel2.Controls.Add(fp);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            Dataset D = new Dataset();
            D.TopLevel = false;
            D.Visible = true;
            splitContainer2.Panel2.Controls.Add(D);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmAdventureWorks FAW = new FrmAdventureWorks();
            FAW.TopLevel = false;
            FAW.Visible = true;
            splitContainer2.Panel2.Controls.Add(FAW);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmMyAlbum_V1 FMA = new FrmMyAlbum_V1();
            FMA.TopLevel = false;
            FMA.Visible = true;
            splitContainer2.Panel2.Controls.Add(FMA);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            FrmCustomers FG = new FrmCustomers();
            FG.TopLevel = false;
            FG.Visible = true;
            splitContainer2.Panel2.Controls.Add(FG);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();
            threeview th = new threeview();
            th.TopLevel = false;
            th.Visible = true;
            splitContainer2.Panel2.Controls.Add(th);
        }
    }
}
