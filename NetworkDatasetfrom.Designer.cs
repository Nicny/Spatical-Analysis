namespace SpatialDataManagement.空间数据管理
{
    partial class NetworkDatasetfrom
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
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.cbxNetworkdataset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxFeatureDataset = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGDBName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 66);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "OPEN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(447, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "This topic uses the geodatabase file, SanFrancisco.gdb,\r\n which is installed in t" +
                "he data folder.";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(375, 270);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 29);
            this.button4.TabIndex = 10;
            this.button4.Text = "关闭";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbxNetworkdataset
            // 
            this.cbxNetworkdataset.FormattingEnabled = true;
            this.cbxNetworkdataset.Location = new System.Drawing.Point(165, 101);
            this.cbxNetworkdataset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNetworkdataset.Name = "cbxNetworkdataset";
            this.cbxNetworkdataset.Size = new System.Drawing.Size(212, 23);
            this.cbxNetworkdataset.TabIndex = 3;
            this.cbxNetworkdataset.SelectedIndexChanged += new System.EventHandler(this.cbxNetworkdataset_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "获取网络数据集：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "获取要素数据集：";
            // 
            // cbxFeatureDataset
            // 
            this.cbxFeatureDataset.FormattingEnabled = true;
            this.cbxFeatureDataset.Location = new System.Drawing.Point(165, 36);
            this.cbxFeatureDataset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFeatureDataset.Name = "cbxFeatureDataset";
            this.cbxFeatureDataset.Size = new System.Drawing.Size(212, 23);
            this.cbxFeatureDataset.TabIndex = 6;
            this.cbxFeatureDataset.SelectedIndexChanged += new System.EventHandler(this.cbxFeatureDataset_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 270);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "加载该网络数据集";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxFeatureDataset);
            this.groupBox1.Controls.Add(this.cbxNetworkdataset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(41, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(427, 156);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "获取数据集";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "连接数据库：";
            // 
            // txtGDBName
            // 
            this.txtGDBName.Location = new System.Drawing.Point(155, 72);
            this.txtGDBName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGDBName.Name = "txtGDBName";
            this.txtGDBName.Size = new System.Drawing.Size(244, 25);
            this.txtGDBName.TabIndex = 14;
            // 
            // NetworkDatasetfrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(503, 315);
            this.Controls.Add(this.txtGDBName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NetworkDatasetfrom";
            this.Text = "Open Network Dataset";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NetworkDatasetfrom_FormClosed);
            this.Load += new System.EventHandler(this.NetworkDatasetfrom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbxNetworkdataset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxFeatureDataset;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGDBName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}