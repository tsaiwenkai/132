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
            if (comboBox1.Text == "")
            {
                MessageBox.Show("請選擇城市");
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                    {
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"Insert into MyCity(CityName,Picture) Values (@City,@Picture)";
                        command.Connection = conn;

                        string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                        for (int i = 0; i < file.Length; i++)
                        {
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



                            conn.Open();

                            command.ExecuteNonQuery();

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }  
        }

        private void FlowLayoutPanel3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void CreadComBoBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct CityName from MyCity", conn);
                    SqlDataReader dataReader = command.ExecuteReader();
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
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct CityName from MyCity", conn);
                    SqlDataReader dataReader = command.ExecuteReader();
                    flowLayoutPanel2.Controls.Clear();
                    while (dataReader.Read())
                    {
                        LinkLabel Llabel = new LinkLabel();
                        Llabel.Text = $"{dataReader[0]}";
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
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    
                    SqlCommand command = new SqlCommand($"select * from MyCity where CityName= '{lab.Text}'", conn);
                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void Pic_Click(object sender, EventArgs e)
        {
            Form ownedForm = sender as Form;
            //BackgroundImage 
            ownedForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.NorthwindConnectionString))
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "Insert into MyCity(CityName,Picture) values(@CityName,@Picture)";
                    comm.Connection = conn;
                    conn.Open();

                    List<string> filteredFiles;
                    FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();

                    DialogResult result = FolderBrowser.ShowDialog();
                    filteredFiles = Directory.GetFiles(FolderBrowser.SelectedPath, "*.*").Where(file => file.ToLower().EndsWith("jpg")).ToList();
                    for (int i = 0; i < filteredFiles.Count; i++)
                    {
                        comm.Parameters.Clear();
                        PictureBox pic = new PictureBox();
                        pic.Image = Image.FromFile(filteredFiles[i]);
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Width = 300;
                        pic.Height = 200;
                        pic.BorderStyle = BorderStyle.FixedSingle;
                        flowLayoutPanel3.Controls.Add(pic);

                        MemoryStream ms = new MemoryStream();
                        pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] bytes = ms.GetBuffer();
                        comm.Parameters.Add("@CityName", SqlDbType.Int).Value = this.comboBox1.SelectedIndex;
                        comm.Parameters.Add("@Picture", SqlDbType.Image).Value = bytes;

                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
