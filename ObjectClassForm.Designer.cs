namespace SpatialDataManagement.空间数据管理
{
    partial class ObjectClassForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtNewObjectClassName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGDBName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFieldAliasName = new System.Windows.Forms.TextBox();
            this.cbxFieldName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObjectClassAliaName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxObjectClass = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNewObjectClassName
            // 
            this.txtNewObjectClassName.Location = new System.Drawing.Point(132, 40);
            this.txtNewObjectClassName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewObjectClassName.Name = "txtNewObjectClassName";
            this.txtNewObjectClassName.Size = new System.Drawing.Size(321, 25);
            this.txtNewObjectClassName.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "对象类名称：";
            // 
            // txtGDBName
            // 
            this.txtGDBName.Location = new System.Drawing.Point(127, 26);
            this.txtGDBName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGDBName.Name = "txtGDBName";
            this.txtGDBName.Size = new System.Drawing.Size(368, 25);
            this.txtGDBName.TabIndex = 17;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(241, 408);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(121, 29);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(517, 24);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(59, 29);
            this.btnOpen.TabIndex = 15;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 144);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "修改字段别名：";
            // 
            // txtFieldAliasName
            // 
            this.txtFieldAliasName.Location = new System.Drawing.Point(152, 140);
            this.txtFieldAliasName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFieldAliasName.Name = "txtFieldAliasName";
            this.txtFieldAliasName.Size = new System.Drawing.Size(300, 25);
            this.txtFieldAliasName.TabIndex = 11;
            // 
            // cbxFieldName
            // 
            this.cbxFieldName.FormattingEnabled = true;
            this.cbxFieldName.Location = new System.Drawing.Point(152, 99);
            this.cbxFieldName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFieldName.Name = "cbxFieldName";
            this.cbxFieldName.Size = new System.Drawing.Size(300, 23);
            this.cbxFieldName.TabIndex = 9;
            this.cbxFieldName.SelectedIndexChanged += new System.EventHandler(this.cbxFieldName_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 109);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "对象类字段：";
            // 
            // txtObjectClassAliaName
            // 
            this.txtObjectClassAliaName.Location = new System.Drawing.Point(152, 62);
            this.txtObjectClassAliaName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtObjectClassAliaName.Name = "txtObjectClassAliaName";
            this.txtObjectClassAliaName.Size = new System.Drawing.Size(300, 25);
            this.txtObjectClassAliaName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "修改对象类别名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "对象类：";
            // 
            // cbxObjectClass
            // 
            this.cbxObjectClass.FormattingEnabled = true;
            this.cbxObjectClass.Location = new System.Drawing.Point(152, 25);
            this.cbxObjectClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxObjectClass.Name = "cbxObjectClass";
            this.cbxObjectClass.Size = new System.Drawing.Size(300, 23);
            this.cbxObjectClass.TabIndex = 0;
            this.cbxObjectClass.SelectedIndexChanged += new System.EventHandler(this.cbxObjectClass_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "连接数据库：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNewObjectClassName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(19, 291);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(488, 82);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新建对象类";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFieldAliasName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbxFieldName);
            this.groupBox2.Controls.Add(this.cbxObjectClass);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtObjectClassAliaName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(19, 89);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(488, 174);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改对象类属性";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(407, 408);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ObjectClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(579, 451);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGDBName);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label9);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ObjectClassForm";
            this.Text = "ObjectClass对象";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ObjectClassForm_FormClosed);
            this.Load += new System.EventHandler(this.ObjectClassForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtNewObjectClassName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGDBName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxObjectClass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObjectClassAliaName;
        private System.Windows.Forms.ComboBox cbxFieldName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFieldAliasName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
    }
}