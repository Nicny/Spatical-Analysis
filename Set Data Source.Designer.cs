namespace SpatialDataManagement.空间数据管理
{
    partial class Set_Data_Source
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxLayer = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbxfeaturedataset = new System.Windows.Forms.ComboBox();
            this.cbxfeatureclass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxFeatureClassAlone = new System.Windows.Forms.ComboBox();
            this.radFeatureDataset = new System.Windows.Forms.RadioButton();
            this.radFeatureClass = new System.Windows.Forms.RadioButton();
            this.btncolse = new System.Windows.Forms.Button();
            this.txtGDBName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "OPEN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "选择更换图层：";
            // 
            // cbxLayer
            // 
            this.cbxLayer.FormattingEnabled = true;
            this.cbxLayer.Location = new System.Drawing.Point(180, 290);
            this.cbxLayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxLayer.Name = "cbxLayer";
            this.cbxLayer.Size = new System.Drawing.Size(249, 23);
            this.cbxLayer.TabIndex = 12;
            this.cbxLayer.SelectedIndexChanged += new System.EventHandler(this.cbxLayer_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(171, 336);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 29);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbxfeaturedataset
            // 
            this.cbxfeaturedataset.FormattingEnabled = true;
            this.cbxfeaturedataset.Location = new System.Drawing.Point(164, 104);
            this.cbxfeaturedataset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxfeaturedataset.Name = "cbxfeaturedataset";
            this.cbxfeaturedataset.Size = new System.Drawing.Size(248, 23);
            this.cbxfeaturedataset.TabIndex = 14;
            this.cbxfeaturedataset.SelectedIndexChanged += new System.EventHandler(this.cbxfeaturedataset_SelectedIndexChanged);
            // 
            // cbxfeatureclass
            // 
            this.cbxfeatureclass.FormattingEnabled = true;
            this.cbxfeatureclass.Location = new System.Drawing.Point(164, 149);
            this.cbxfeatureclass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxfeatureclass.Name = "cbxfeatureclass";
            this.cbxfeatureclass.Size = new System.Drawing.Size(248, 23);
            this.cbxfeatureclass.TabIndex = 15;
            this.cbxfeatureclass.SelectedIndexChanged += new System.EventHandler(this.cbxfeatureclass_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "选择要素数据集：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "选择要素类：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxFeatureClassAlone);
            this.groupBox1.Controls.Add(this.radFeatureDataset);
            this.groupBox1.Controls.Add(this.radFeatureClass);
            this.groupBox1.Controls.Add(this.cbxfeaturedataset);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxfeatureclass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(436, 184);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择数据";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "选择要素类：";
            // 
            // cbxFeatureClassAlone
            // 
            this.cbxFeatureClassAlone.FormattingEnabled = true;
            this.cbxFeatureClassAlone.Location = new System.Drawing.Point(163, 55);
            this.cbxFeatureClassAlone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFeatureClassAlone.Name = "cbxFeatureClassAlone";
            this.cbxFeatureClassAlone.Size = new System.Drawing.Size(249, 23);
            this.cbxFeatureClassAlone.TabIndex = 21;
            this.cbxFeatureClassAlone.SelectedIndexChanged += new System.EventHandler(this.cbxFeatureClassAlone_SelectedIndexChanged);
            // 
            // radFeatureDataset
            // 
            this.radFeatureDataset.AutoSize = true;
            this.radFeatureDataset.Location = new System.Drawing.Point(16, 81);
            this.radFeatureDataset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radFeatureDataset.Name = "radFeatureDataset";
            this.radFeatureDataset.Size = new System.Drawing.Size(137, 24);
            this.radFeatureDataset.TabIndex = 20;
            this.radFeatureDataset.TabStop = true;
            this.radFeatureDataset.Text = "要素数据集";
            this.radFeatureDataset.UseVisualStyleBackColor = true;
            this.radFeatureDataset.CheckedChanged += new System.EventHandler(this.radFeatureDataset_CheckedChanged);
            // 
            // radFeatureClass
            // 
            this.radFeatureClass.AutoSize = true;
            this.radFeatureClass.Location = new System.Drawing.Point(16, 28);
            this.radFeatureClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radFeatureClass.Name = "radFeatureClass";
            this.radFeatureClass.Size = new System.Drawing.Size(137, 24);
            this.radFeatureClass.TabIndex = 19;
            this.radFeatureClass.TabStop = true;
            this.radFeatureClass.Text = "独立要素类";
            this.radFeatureClass.UseVisualStyleBackColor = true;
            this.radFeatureClass.CheckedChanged += new System.EventHandler(this.radFeatureClass_CheckedChanged);
            // 
            // btncolse
            // 
            this.btncolse.Location = new System.Drawing.Point(308, 336);
            this.btncolse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btncolse.Name = "btncolse";
            this.btncolse.Size = new System.Drawing.Size(100, 29);
            this.btncolse.TabIndex = 19;
            this.btncolse.Text = "关闭";
            this.btncolse.UseVisualStyleBackColor = true;
            // 
            // txtGDBName
            // 
            this.txtGDBName.Location = new System.Drawing.Point(124, 32);
            this.txtGDBName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGDBName.Name = "txtGDBName";
            this.txtGDBName.Size = new System.Drawing.Size(268, 25);
            this.txtGDBName.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "连接数据库：";
            // 
            // Set_Data_Source
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(477, 382);
            this.Controls.Add(this.txtGDBName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btncolse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbxLayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Set_Data_Source";
            this.Text = "Set_Data_Source";
            this.Load += new System.EventHandler(this.Set_Data_Source_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxLayer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxfeaturedataset;
        private System.Windows.Forms.ComboBox cbxfeatureclass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btncolse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxFeatureClassAlone;
        private System.Windows.Forms.RadioButton radFeatureDataset;
        private System.Windows.Forms.RadioButton radFeatureClass;
        private System.Windows.Forms.TextBox txtGDBName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}