using MyHW.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmMyAlbum_V1 : Form
    {
        public FrmMyAlbum_V1()
        {
            InitializeComponent();
            CreatLinkLabel();
            CreadComBoBox();
            //--------------------------
            flowLayoutPanel3.AllowDrop = true;
            flowLayoutPanel3.DragEnter += FlowLayoutPanel3_DragEnter;
            flowLayoutPanel3.DragDrop += FlowLayoutPanel3_DragDrop;
        }

        private void FlowLayoutPanel3_DragDrop(object sender, DragEventArgs e)
        {
            flowLayoutPanel3.Controls.Clear();
            if (comboBox1.Text == "")
            {
                MessageBox.Show("請選擇城市");
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.Mydata))
                    {
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"Insert into MyCity(CityName,Picture) Values (@City,@Picture)";
                        command.Connection = conn;
                        conn.Open();
                        string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                        for (int i = 0; i < file.Length; i++)
                        {
                            command.Parameters.Clear();
                            PictureBox pic = new PictureBox();
                            pic.Image = Image.FromFile(file[i]);
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Width = 120;
                            pic.Height = 120;
                            flowLayoutPanel3.Controls.Add(pic);

                            System.IO.MemoryStream da = new System.IO.MemoryStream();
                            pic.Image.Save(da, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] bytes = da.GetBuffer();
                            //--------------------------------------

                            command.Parameters.Add("@City", SqlDbType.Text).Value = this.comboBox1.Text;

                            command.Parameters.Add("@Picture", SqlDbType.Image).Value = bytes;  //bytes變數為圖片2進制格式為陣列


                            command.ExecuteNonQuery();

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                CreadComBoBox();
            }
            this.myCityTableAdapter.Fill(this.dataSet3.MyCity);
        }

        private void FlowLayoutPanel3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void CreadComBoBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.Mydata))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct CityName from MyCity", conn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    comboBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        comboBox1.Items.Add(dataReader[0]);
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CreatLinkLabel()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.Mydata))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct CityName from MyCity", conn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    flowLayoutPanel2.Controls.Clear();
                    while (dataReader.Read())
                    {
                        LinkLabel Llabel = new LinkLabel();
                        Llabel.Text = $"{dataReader[0]}";
                        Llabel.AutoSize = false;
                        Llabel.Left = 5;
                        Llabel.Top += 30;

                        Llabel.Click += Llabel_Click;
                        flowLayoutPanel2.Controls.Add(Llabel);
                    }              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Llabel_Click(object sender, EventArgs e)
        {
            LinkLabel lab = sender as LinkLabel;
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.Mydata))
                {

                    SqlCommand command = new SqlCommand($"select * from MyCity where CityName= '{lab.Text}'", conn);
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    flowLayoutPanel1.Controls.Clear();
                    if (dataReader.Read().ToString() == null)
                    {
                        ClearNull();
                    }
                    else
                    {
                        while (dataReader.Read())
                        {
                            byte[] bytes = (byte[])dataReader["Picture"];
                            MemoryStream da = new MemoryStream(bytes);

                            PictureBox pic = new PictureBox();
                            pic.Image = Image.FromStream(da);
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Width = 300;
                            pic.Height = 200;


                            pic.Click += Pic_Click;
                            flowLayoutPanel1.Controls.Add(pic);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            Form ownedForm = new Form();
            ownedForm.BackgroundImageLayout = ImageLayout.Stretch;
            ownedForm.BackgroundImage=((PictureBox)sender).Image;
            ownedForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.Mydata))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"Insert into MyCity(CityName) Values (@City)";
                    command.Connection = conn;
                    conn.Open();

                    command.Parameters.Clear();

                    command.Parameters.Add("@City", SqlDbType.Text).Value = this.textBox1.Text;

                    command.ExecuteNonQuery();


                }
                textBox1.Clear();
                CreadComBoBox();
                CreatLinkLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.Mydata))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"delete from MyCity where picture is null";
                    command.Connection = conn;
                    conn.Open();
                 
                     command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void myCityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.myCityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet3);

        }

        private void FrmMyAlbum_V1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'dataSet3.MyCity' 資料表。您可以視需要進行移動或移除。
            this.myCityTableAdapter.Fill(this.dataSet3.MyCity);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.Mydata))
                {

                    SqlCommand command = new SqlCommand($"select * from MyCity where CityName= '{comboBox1.Text}'", conn);
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    flowLayoutPanel3.Controls.Clear();
                    if (dataReader.Read().ToString() == null)
                    {
                        ClearNull();
                    }
                    while (dataReader.Read())
                    {
                        byte[] bytes = (byte[])dataReader["Picture"];
                        MemoryStream da = new MemoryStream(bytes);

                        PictureBox pic = new PictureBox();
                        pic.Image = Image.FromStream(da);
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Width = 300;
                        pic.Height = 200;

                        flowLayoutPanel3.Controls.Add(pic);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ClearNull()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.Mydata))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"delete from MyCity where picture is null";
                    command.Connection = conn;
                    conn.Open();

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
