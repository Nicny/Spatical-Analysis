namespace SpatialDataManagement.空间数据管理
{
    partial class CreateFeatureClassForm
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
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFeatureclassname = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.cbxFeatureDataset = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGDBName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 249);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 29);
            this.button3.TabIndex = 13;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "连接数据库：";
            // 
            // txtFeatureclassname
            // 
            this.txtFeatureclassname.Location = new System.Drawing.Point(149, 148);
            this.txtFeatureclassname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFeatureclassname.Name = "txtFeatureclassname";
            this.txtFeatureclassname.Size = new System.Drawing.Size(261, 25);
            this.txtFeatureclassname.TabIndex = 11;
            this.txtFeatureclassname.TextChanged += new System.EventHandler(this.txtFeatureclassname_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(420, 28);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 29);
            this.button2.TabIndex = 10;
            this.button2.Text = "OPEN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Location = new System.Drawing.Point(165, 181);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "检查是否已存在同名要素类";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 151);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "输入要素类名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "选择要素数据集：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(312, 249);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 29);
            this.button4.TabIndex = 15;
            this.button4.Text = "关闭";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbxFeatureDataset
            // 
            this.cbxFeatureDataset.FormattingEnabled = true;
            this.cbxFeatureDataset.Location = new System.Drawing.Point(149, 91);
            this.cbxFeatureDataset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFeatureDataset.Name = "cbxFeatureDataset";
            this.cbxFeatureDataset.Size = new System.Drawing.Size(261, 23);
            this.cbxFeatureDataset.TabIndex = 16;
            this.cbxFeatureDataset.SelectedIndexChanged += new System.EventHandler(this.cbxFeatureDataset_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "可选";
            // 
            // txtGDBName
            // 
            this.txtGDBName.Location = new System.Drawing.Point(141, 30);
            this.txtGDBName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGDBName.Name = "txtGDBName";
            this.txtGDBName.Size = new System.Drawing.Size(268, 25);
            this.txtGDBName.TabIndex = 18;
            // 
            // CreateFeatureClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(489, 291);
            this.Controls.Add(this.txtGDBName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxFeatureDataset);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFeatureclassname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CreateFeatureClassForm";
            this.Text = "创建要素类 ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateFeatureClassForm_FormClosed);
            this.Load += new System.EventHandler(this.CreateFeatureClassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFeatureclassname;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox cbxFeatureDataset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGDBName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}