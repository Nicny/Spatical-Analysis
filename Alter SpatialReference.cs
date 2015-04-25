using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;

namespace SpatialDataManagement.空间数据管理
{
    public partial class Alter_SpatialReference : Form
    {   
        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMap m_map = null;

        string layerName = null;
        public Alter_SpatialReference(object hook )
        {
            if (hook == null)
                return;

            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;

            InitializeComponent();
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;
        }

        #region "GetLayers"
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";// IFeatureLayer
            //uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";  // IGeoFeatureLayer
            //uid.Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}";  // IDataLayer
            if (m_map.LayerCount != 0)
            {
                IEnumLayer layers = m_map.get_Layers(uid, true);
                return layers;
            }
            return null;
        }
        #endregion
        #region "GetFeatureLayer"
        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            if (GetLayers() == null) return null;
            IEnumLayer layers = GetLayers();
            layers.Reset();

            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }
            return null;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            IFeatureLayer pFL = GetFeatureLayer(layerName);

            IFeatureClass pFeatureClass = pFL.FeatureClass;

            IGeoDataset pGeoDataset = pFeatureClass as IGeoDataset;
            IGeoDatasetSchemaEdit pGeoDatasetSE = pGeoDataset as IGeoDatasetSchemaEdit;

            if (pGeoDatasetSE.CanAlterSpatialReference == true)
            {
               ISpatialReferenceFactory2 pSpatRefFact = new SpatialReferenceEnvironmentClass();
                IGeographicCoordinateSystem   pGeoSys = pSpatRefFact.CreateGeographicCoordinateSystem(4214);//esriSRGeoCSType .esriSRGeoCS_Beijing1954
                pGeoDatasetSE.AlterSpatialReference(pGeoSys);
                MessageBox.Show("已改变当前图层的空间参考！");
                m_activeView.Refresh();   
            }
            else MessageBox.Show("当前图层的空间参考不能被改变!");
        }

        private void Alter_SpatialReference_Load(object sender, EventArgs e)
        {
            addLayer();
        }

        private void addLayer()
        {
            if (GetLayers() == null) return;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    IFeatureLayer featureLayer = layer as IFeatureLayer;
                    cbxLayer.Items.Add(layer.Name);
                    layer = layers.Next();
                }
            }
            cbxLayer.SelectedIndex = 0;
        }

        private void cbxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            layerName = cbxLayer.SelectedItem.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Alter_SpatialReference_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
 
        }     

    }
}
