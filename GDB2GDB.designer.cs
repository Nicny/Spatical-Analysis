namespace CoordinateTransformation
{
    partial class GDB2GDB
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvSourceGDB = new System.Windows.Forms.TreeView();
            this.trvTargetGDB = new System.Windows.Forms.TreeView();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSelectSourceDB = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectTargetDB = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.chkHasZ = new System.Windows.Forms.CheckBox();
            this.chkHasM = new System.Windows.Forms.CheckBox();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.btnExportInfo = new System.Windows.Forms.Button();
            this.btnClearInfo = new System.Windows.Forms.Button();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnClearSourceDatabase = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.grpInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvSourceGDB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.trvTargetGDB);
            this.splitContainer1.Size = new System.Drawing.Size(665, 324);
            this.splitContainer1.SplitterDistance = 314;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // trvSourceGDB
            // 
            this.trvSourceGDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvSourceGDB.Location = new System.Drawing.Point(0, 0);
            this.trvSourceGDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trvSourceGDB.Name = "trvSourceGDB";
            this.trvSourceGDB.Size = new System.Drawing.Size(314, 324);
            this.trvSourceGDB.TabIndex = 0;
            // 
            // trvTargetGDB
            // 
            this.trvTargetGDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTargetGDB.Location = new System.Drawing.Point(0, 0);
            this.trvTargetGDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trvTargetGDB.Name = "trvTargetGDB";
            this.trvTargetGDB.Size = new System.Drawing.Size(346, 324);
            this.trvTargetGDB.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(341, 520);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 29);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "拷贝";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSelectSourceDB
            // 
            this.btnSelectSourceDB.Location = new System.Drawing.Point(28, 520);
            this.btnSelectSourceDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectSourceDB.Name = "btnSelectSourceDB";
            this.btnSelectSourceDB.Size = new System.Drawing.Size(116, 29);
            this.btnSelectSourceDB.TabIndex = 4;
            this.btnSelectSourceDB.Text = "选择源数据库";
            this.btnSelectSourceDB.UseVisualStyleBackColor = true;
            this.btnSelectSourceDB.Click += new System.EventHandler(this.btnSelectSourceDB_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "File GeoDatabase|*.gdb";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select A GeoDatabase";
            // 
            // btnSelectTargetDB
            // 
            this.btnSelectTargetDB.Location = new System.Drawing.Point(175, 520);
            this.btnSelectTargetDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectTargetDB.Name = "btnSelectTargetDB";
            this.btnSelectTargetDB.Size = new System.Drawing.Size(136, 29);
            this.btnSelectTargetDB.TabIndex = 4;
            this.btnSelectTargetDB.Text = "选择目标数据库";
            this.btnSelectTargetDB.UseVisualStyleBackColor = true;
            this.btnSelectTargetDB.Click += new System.EventHandler(this.btnSelectTargetDB_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.splitContainer1);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.chkHasZ);
            this.flowLayoutPanel1.Controls.Add(this.chkHasM);
            this.flowLayoutPanel1.Controls.Add(this.grpInformation);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 11);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(697, 490);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 332);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "　　    　　　　　　　　　　目标数据库有关设置：";
            // 
            // chkHasZ
            // 
            this.chkHasZ.AutoSize = true;
            this.chkHasZ.Location = new System.Drawing.Point(381, 336);
            this.chkHasZ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkHasZ.Name = "chkHasZ";
            this.chkHasZ.Size = new System.Drawing.Size(112, 19);
            this.chkHasZ.TabIndex = 97;
            this.chkHasZ.Text = "是否需要Z值";
            this.chkHasZ.UseVisualStyleBackColor = true;
            this.chkHasZ.CheckedChanged += new System.EventHandler(this.chkHasZ_CheckedChanged);
            // 
            // chkHasM
            // 
            this.chkHasM.AutoSize = true;
            this.chkHasM.Location = new System.Drawing.Point(501, 336);
            this.chkHasM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkHasM.Name = "chkHasM";
            this.chkHasM.Size = new System.Drawing.Size(112, 19);
            this.chkHasM.TabIndex = 98;
            this.chkHasM.Text = "是否需要M值";
            this.chkHasM.UseVisualStyleBackColor = true;
            this.chkHasM.CheckedChanged += new System.EventHandler(this.chkHasM_CheckedChanged);
            // 
            // grpInformation
            // 
            this.grpInformation.BackColor = System.Drawing.SystemColors.Control;
            this.grpInformation.Controls.Add(this.btnExportInfo);
            this.grpInformation.Controls.Add(this.btnClearInfo);
            this.grpInformation.Controls.Add(this.txtMessages);
            this.grpInformation.Location = new System.Drawing.Point(4, 363);
            this.grpInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpInformation.Size = new System.Drawing.Size(665, 200);
            this.grpInformation.TabIndex = 95;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "操作信息";
            // 
            // btnExportInfo
            // 
            this.btnExportInfo.Location = new System.Drawing.Point(535, 120);
            this.btnExportInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportInfo.Name = "btnExportInfo";
            this.btnExportInfo.Size = new System.Drawing.Size(117, 29);
            this.btnExportInfo.TabIndex = 2;
            this.btnExportInfo.Text = "导出操作信息";
            this.btnExportInfo.UseVisualStyleBackColor = true;
            this.btnExportInfo.Click += new System.EventHandler(this.btnExportInfo_Click);
            // 
            // btnClearInfo
            // 
            this.btnClearInfo.Location = new System.Drawing.Point(535, 64);
            this.btnClearInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearInfo.Name = "btnClearInfo";
            this.btnClearInfo.Size = new System.Drawing.Size(117, 29);
            this.btnClearInfo.TabIndex = 1;
            this.btnClearInfo.Text = "清除操作信息";
            this.btnClearInfo.UseVisualStyleBackColor = true;
            this.btnClearInfo.Click += new System.EventHandler(this.btnClearInfo_Click);
            // 
            // txtMessages
            // 
            this.txtMessages.BackColor = System.Drawing.Color.Snow;
            this.txtMessages.Location = new System.Drawing.Point(4, 21);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(513, 174);
            this.txtMessages.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(472, 520);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 29);
            this.btnCancel.TabIndex = 85;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClearSourceDatabase
            // 
            this.btnClearSourceDatabase.Location = new System.Drawing.Point(583, 520);
            this.btnClearSourceDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearSourceDatabase.Name = "btnClearSourceDatabase";
            this.btnClearSourceDatabase.Size = new System.Drawing.Size(123, 29);
            this.btnClearSourceDatabase.TabIndex = 86;
            this.btnClearSourceDatabase.Text = "清空源数据库";
            this.btnClearSourceDatabase.UseVisualStyleBackColor = true;
            this.btnClearSourceDatabase.Click += new System.EventHandler(this.btnClearSourceDatabase_Click);
            // 
            // GDB2GDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(731, 564);
            this.Controls.Add(this.btnClearSourceDatabase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnSelectTargetDB);
            this.Controls.Add(this.btnSelectSourceDB);
            this.Controls.Add(this.btnCopy);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "GDB2GDB";
            this.Text = "Geodatabase数据库拷贝";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GDB2GDB_FormClosing);
            this.Load += new System.EventHandler(this.GDB2GDB_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvSourceGDB;
        private System.Windows.Forms.TreeView trvTargetGDB;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSelectSourceDB;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectTargetDB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox grpInformation;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHasZ;
        private System.Windows.Forms.CheckBox chkHasM;
        private System.Windows.Forms.Button btnExportInfo;
        private System.Windows.Forms.Button btnClearInfo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnClearSourceDatabase;
    }
}