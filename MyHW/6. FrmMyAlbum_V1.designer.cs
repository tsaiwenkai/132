
namespace MyHW
{
    partial class FrmMyAlbum_V1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet41 = new MyHW.DataSet4();
            this.cityNameTableAdapter1 = new MyHW.DataSet4TableAdapters.CityNameTableAdapter();
            this.pictureTableAdapter1 = new MyHW.DataSet4TableAdapters.PictureTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet41)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(23, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 293);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(334, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(379, 293);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataSet41
            // 
            this.dataSet41.DataSetName = "DataSet4";
            this.dataSet41.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cityNameTableAdapter1
            // 
            this.cityNameTableAdapter1.ClearBeforeFill = true;
            // 
            // pictureTableAdapter1
            // 
            this.pictureTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmMyAlbum_V1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMyAlbum_V1";
            this.Text = "FrmMyAlbum_V1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet41)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet4 dataSet41;
        private DataSet4TableAdapters.CityNameTableAdapter cityNameTableAdapter1;
        private DataSet4TableAdapters.PictureTableAdapter pictureTableAdapter1;
    }
}