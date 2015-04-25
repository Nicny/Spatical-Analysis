using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace SpatialDataManagement.空间数据管理
{
    public partial class CreateFeatureForm : Form
    {
        IFeature pfeature;
        IFeatureClass pfc;

        public CreateFeatureForm(IFeature feature)
        {
            InitializeComponent();
            pfeature = feature;
        }

        private void CreateFeatureForm_Load(object sender, EventArgs e)
        {
            pfc = pfeature.Class as IFeatureClass;
            if (pfc.ShapeType == esriGeometryType.esriGeometryPoint)
            { this.Text = "创建点要素"; }

            if (pfc.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                this.Text = "创建面要素";
            }
            if (pfc.ShapeType == esriGeometryType.esriGeometryPolyline)

            { this.Text = "创建线要素"; }
            dataGridView1.Rows.Add(pfc.Fields.FieldCount);
            for (int i = 0; i < pfc.Fields.FieldCount; i++)
            {
                dataGridView1[0, i].Value = pfc.Fields.get_Field(i).Name;
                int count = pfc.Fields.FindField(pfc.Fields.get_Field(i).Name.ToString());
                dataGridView1[1, i].Value = pfeature.get_Value(count).ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pfeature.Delete();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int fieldindex = pfc.Fields.FindField(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                pfeature.set_Value(fieldindex, dataGridView1.CurrentCell.Value.ToString());
                pfeature.Store();
                MessageBox.Show("创建成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
