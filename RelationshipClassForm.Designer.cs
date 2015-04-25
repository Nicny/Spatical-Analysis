namespace SpatialDataManagement.空间数据管理
{
    partial class RelationshipClassForm
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
            this.txtrelationshipclassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbxOriginClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDestinationClass = new System.Windows.Forms.ComboBox();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.cbxCardinality = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LabOriginClass = new System.Windows.Forms.Label();
            this.LblDestClass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtrelationshipclassName
            // 
            this.txtrelationshipclassName.Location = new System.Drawing.Point(191, 71);
            this.txtrelationshipclassName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtrelationshipclassName.Name = "txtrelationshipclassName";
            this.txtrelationshipclassName.Size = new System.Drawing.Size(228, 25);
            this.txtrelationshipclassName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "关系类名称：";
            // 
            // cbxOriginClass
            // 
            this.cbxOriginClass.FormattingEnabled = true;
            this.cbxOriginClass.Location = new System.Drawing.Point(191, 108);
            this.cbxOriginClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxOriginClass.Name = "cbxOriginClass";
            this.cbxOriginClass.Size = new System.Drawing.Size(228, 23);
            this.cbxOriginClass.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "选择起始表或要素类：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "选择关系类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "选择目标表或要素类：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 232);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "选择基数：";
            // 
            // cbxDestinationClass
            // 
            this.cbxDestinationClass.FormattingEnabled = true;
            this.cbxDestinationClass.Location = new System.Drawing.Point(191, 150);
            this.cbxDestinationClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxDestinationClass.Name = "cbxDestinationClass";
            this.cbxDestinationClass.Size = new System.Drawing.Size(228, 23);
            this.cbxDestinationClass.TabIndex = 12;
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "Simple",
            "Composite "});
            this.cbxType.Location = new System.Drawing.Point(191, 184);
            this.cbxType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(228, 23);
            this.cbxType.TabIndex = 13;
            // 
            // cbxCardinality
            // 
            this.cbxCardinality.FormattingEnabled = true;
            this.cbxCardinality.Items.AddRange(new object[] {
            "一对一",
            "一对多",
            "多对多"});
            this.cbxCardinality.Location = new System.Drawing.Point(191, 222);
            this.cbxCardinality.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxCardinality.Name = "cbxCardinality";
            this.cbxCardinality.Size = new System.Drawing.Size(228, 23);
            this.cbxCardinality.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(311, 45);
            this.label6.TabIndex = 15;
            this.label6.Text = "This topic uses the geodatabase file, \r\nGDBForRelationSample.gdb, which is \r\ninst" +
                "alled in the Data_Sample.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 270);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(310, 27);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 29);
            this.button2.TabIndex = 17;
            this.button2.Text = "连接数据库";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LabOriginClass
            // 
            this.LabOriginClass.AutoSize = true;
            this.LabOriginClass.Location = new System.Drawing.Point(419, 111);
            this.LabOriginClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabOriginClass.Name = "LabOriginClass";
            this.LabOriginClass.Size = new System.Drawing.Size(0, 15);
            this.LabOriginClass.TabIndex = 18;
            // 
            // LblDestClass
            // 
            this.LblDestClass.AutoSize = true;
            this.LblDestClass.Location = new System.Drawing.Point(419, 160);
            this.LblDestClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDestClass.Name = "LblDestClass";
            this.LblDestClass.Size = new System.Drawing.Size(0, 15);
            this.LblDestClass.TabIndex = 19;
            // 
            // RelationshipClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(446, 314);
            this.Controls.Add(this.LblDestClass);
            this.Controls.Add(this.LabOriginClass);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxCardinality);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.cbxDestinationClass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxOriginClass);
            this.Controls.Add(this.txtrelationshipclassName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RelationshipClassForm";
            this.Text = "创建关系类";
            this.Load += new System.EventHandler(this.RelationshipClassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtrelationshipclassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cbxOriginClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDestinationClass;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.ComboBox cbxCardinality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label LabOriginClass;
        private System.Windows.Forms.Label LblDestClass;
    }
}