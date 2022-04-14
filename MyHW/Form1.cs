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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cityDB);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'cityDB.View' 資料表。您可以視需要進行移動或移除。
            this.viewTableAdapter.Fill(this.cityDB.View);
            // TODO: 這行程式碼會將資料載入 'cityDB.City' 資料表。您可以視需要進行移動或移除。
            this.cityTableAdapter.Fill(this.cityDB.City);

        }
    }
}
