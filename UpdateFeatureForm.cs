using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;

namespace SpatialDataManagement.空间数据管理
{
    public partial class UpdateFeatureForm : Form
    {
        IFeature pfeature;
        IFeatureClass pfeatureClass;

        public UpdateFeatureForm(IFeature feature)
        {
            InitializeComponent();
            pfeature = feature;
            pfeatureClass = pfeature.Class as IFeatureClass;
        }
        public DataGridView getdataview
        {
            get
            {
                return dataGridView1;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int fieldindex = pfeatureClass.Fields.FindField(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                pfeature.set_Value(fieldindex, dataGridView1.CurrentCell.Value.ToString());
                pfeature.Store();
                MessageBox.Show("完成更新");
            }
            catch
            {
                MessageBox.Show("请先保存并停止编辑！");
            }
        }

        private void UpdateFeatureForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

     
    }
}
