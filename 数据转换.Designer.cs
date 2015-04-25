namespace SpatialDataManagement.空间数据管理
{
    partial class ConvertShapefileToFeatClass
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenShapefile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSourcefeatureclass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsourceworkspace = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxTargetdataset = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenFilegdb = new System.Windows.Forms.Button();
            this.txtTargetworkspace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "连接源数据库：";
            // 
            // btnOpenShapefile
            // 
            this.btnOpenShapefile.Location = new System.Drawing.Point(485, 26);
            this.btnOpenShapefile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenShapefile.Name = "btnOpenShapefile";
            this.btnOpenShapefile.Size = new System.Drawing.Size(51, 29);
            this.btnOpenShapefile.TabIndex = 1;
            this.btnOpenShapefile.Text = "OPEN";
            this.btnOpenShapefile.UseVisualStyleBackColor = true;
            this.btnOpenShapefile.Click += new System.EventHandler(this.btnOpenShapefile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSourcefeatureclass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtsourceworkspace);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenShapefile);
            this.groupBox1.Location = new System.Drawing.Point(39, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(544, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shapefile";
            // 
            // txtSourcefeatureclass
            // 
            this.txtSourcefeatureclass.Location = new System.Drawing.Point(156, 78);
            this.txtSourcefeatureclass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSourcefeatureclass.Name = "txtSourcefeatureclass";
            this.txtSourcefeatureclass.Size = new System.Drawing.Size(296, 25);
            this.txtSourcefeatureclass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Shapefile数据：";
            // 
            // txtsourceworkspace
            // 
            this.txtsourceworkspace.Location = new System.Drawing.Point(125, 29);
            this.txtsourceworkspace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtsourceworkspace.Name = "txtsourceworkspace";
            this.txtsourceworkspace.Size = new System.Drawing.Size(327, 25);
            this.txtsourceworkspace.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxTargetdataset);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnOpenFilegdb);
            this.groupBox3.Controls.Add(this.txtTargetworkspace);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(39, 179);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(544, 131);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filegeodatabase";
            // 
            // cbxTargetdataset
            // 
            this.cbxTargetdataset.FormattingEnabled = true;
            this.cbxTargetdataset.Location = new System.Drawing.Point(183, 88);
            this.cbxTargetdataset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTargetdataset.Name = "cbxTargetdataset";
            this.cbxTargetdataset.Size = new System.Drawing.Size(269, 23);
            this.cbxTargetdataset.TabIndex = 11;
            this.cbxTargetdataset.SelectedIndexChanged += new System.EventHandler(this.cbxTargetdataset_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "选择目标要素数据集：";
            // 
            // btnOpenFilegdb
            // 
            this.btnOpenFilegdb.Location = new System.Drawing.Point(487, 34);
            this.btnOpenFilegdb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenFilegdb.Name = "btnOpenFilegdb";
            this.btnOpenFilegdb.Size = new System.Drawing.Size(51, 29);
            this.btnOpenFilegdb.TabIndex = 9;
            this.btnOpenFilegdb.Text = "OPEN";
            this.btnOpenFilegdb.UseVisualStyleBackColor = true;
            this.btnOpenFilegdb.Click += new System.EventHandler(this.btnOpenFilegdb_Click);
            // 
            // txtTargetworkspace
            // 
            this.txtTargetworkspace.Location = new System.Drawing.Point(119, 36);
            this.txtTargetworkspace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTargetworkspace.Name = "txtTargetworkspace";
            this.txtTargetworkspace.Size = new System.Drawing.Size(333, 25);
            this.txtTargetworkspace.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "目标数据库：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(301, 334);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(335, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sample: Convert Shapefile To FeatureClass";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 348);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConvertShapefileToFeatClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(611, 396);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConvertShapefileToFeatClass";
            this.Text = "数据转换";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConvertShapefileToFeatClass_FormClosed);
            this.Load += new System.EventHandler(this.ConvertShapefileToFeatClass_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenShapefile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtsourceworkspace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenFilegdb;
        private System.Windows.Forms.TextBox txtTargetworkspace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSourcefeatureclass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTargetdataset;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}