namespace SpatialDataManagement
{
    partial class AttributesContextMenu
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.闪烁该要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放到该要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平移到该要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放到当前图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放到所有选择要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清楚所有选择要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除所有选择要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 337);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(430, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel1.Text = "总记录数：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(418, 327);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.闪烁该要素ToolStripMenuItem,
            this.缩放到该要素ToolStripMenuItem,
            this.平移到该要素ToolStripMenuItem,
            this.toolStripSeparator1,
            this.缩放到当前图层ToolStripMenuItem,
            this.toolStripSeparator2,
            this.缩放到所有选择要素ToolStripMenuItem,
            this.清楚所有选择要素ToolStripMenuItem,
            this.删除所有选择要素ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 170);
            // 
            // 闪烁该要素ToolStripMenuItem
            // 
            this.闪烁该要素ToolStripMenuItem.Name = "闪烁该要素ToolStripMenuItem";
            this.闪烁该要素ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.闪烁该要素ToolStripMenuItem.Text = "闪烁该要素";
            this.闪烁该要素ToolStripMenuItem.Click += new System.EventHandler(this.闪烁该要素ToolStripMenuItem_Click);
            // 
            // 缩放到该要素ToolStripMenuItem
            // 
            this.缩放到该要素ToolStripMenuItem.Name = "缩放到该要素ToolStripMenuItem";
            this.缩放到该要素ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.缩放到该要素ToolStripMenuItem.Text = "缩放到该要素";
            this.缩放到该要素ToolStripMenuItem.Click += new System.EventHandler(this.缩放到该要素ToolStripMenuItem_Click);
            // 
            // 平移到该要素ToolStripMenuItem
            // 
            this.平移到该要素ToolStripMenuItem.Name = "平移到该要素ToolStripMenuItem";
            this.平移到该要素ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.平移到该要素ToolStripMenuItem.Text = "平移到该要素";
            this.平移到该要素ToolStripMenuItem.Click += new System.EventHandler(this.平移到该要素ToolStripMenuItem_Click);
            // 
            // 缩放到当前图层ToolStripMenuItem
            // 
            this.缩放到当前图层ToolStripMenuItem.Name = "缩放到当前图层ToolStripMenuItem";
            this.缩放到当前图层ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.缩放到当前图层ToolStripMenuItem.Text = "缩放到当前图层";
            this.缩放到当前图层ToolStripMenuItem.Click += new System.EventHandler(this.缩放到当前图层ToolStripMenuItem_Click);
            // 
            // 缩放到所有选择要素ToolStripMenuItem
            // 
            this.缩放到所有选择要素ToolStripMenuItem.Name = "缩放到所有选择要素ToolStripMenuItem";
            this.缩放到所有选择要素ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.缩放到所有选择要素ToolStripMenuItem.Text = "缩放到所有选择要素";
            this.缩放到所有选择要素ToolStripMenuItem.Click += new System.EventHandler(this.缩放到所有选择要素ToolStripMenuItem_Click);
            // 
            // 清楚所有选择要素ToolStripMenuItem
            // 
            this.清楚所有选择要素ToolStripMenuItem.Name = "清楚所有选择要素ToolStripMenuItem";
            this.清楚所有选择要素ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.清楚所有选择要素ToolStripMenuItem.Text = "清楚所有选择要素";
            this.清楚所有选择要素ToolStripMenuItem.Click += new System.EventHandler(this.清楚所有选择要素ToolStripMenuItem_Click);
            // 
            // 删除所有选择要素ToolStripMenuItem
            // 
            this.删除所有选择要素ToolStripMenuItem.Name = "删除所有选择要素ToolStripMenuItem";
            this.删除所有选择要素ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.删除所有选择要素ToolStripMenuItem.Text = "删除所有选择要素";
            this.删除所有选择要素ToolStripMenuItem.Click += new System.EventHandler(this.删除所有选择要素ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // AttributesContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 359);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AttributesContextMenu";
            this.Text = "LayerAttributes";
            this.Load += new System.EventHandler(this.AttributesContextMenu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 闪烁该要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩放到该要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平移到该要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 缩放到当前图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 缩放到所有选择要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清楚所有选择要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除所有选择要素ToolStripMenuItem;
    }
}