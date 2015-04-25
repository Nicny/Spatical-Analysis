using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;

namespace SpatialDataManagement.空间数据管理
{
    public partial class ConnectGBDForm : Form
    {
        public ConnectGBDForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWorkspace workspace;
            IWorkspaceFactory workspaceFactory;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathname = folderBrowserDialog1.SelectedPath;
                workspaceFactory = new FileGDBWorkspaceFactoryClass();
                workspace = workspaceFactory.OpenFromFile(pathname, 0);
                textBox1.Text = System.IO.Path.GetFileName(pathname);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IWorkspace workspace;
            IWorkspaceFactory workspaceFactory;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Personal Geodatabase (*.mdb)|*.mdb";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string pathname = openFileDialog1.FileName;
                workspaceFactory = new AccessWorkspaceFactoryClass();
                workspace = workspaceFactory.OpenFromFile(pathname, 0);
                textBox2.Text = System.IO.Path.GetFileName(pathname);
            }
        }

        private void ConnectGBDForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
