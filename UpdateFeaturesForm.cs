using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;

namespace SpatialDataManagement.空间数据管理
{
    public partial class UpdateFeaturesForm : Form
    {
        IHookHelper pHookHelper = null;
        IMapControl3 pMapControl;
        IMap pMap;
        IActiveView pActiveView;

        string FieldsName = null;
        const string m_dataSetName = "m_layerDataSet";
        const string m_dataSourceName = "GeoDataSource";
        DataSet m_layerDataSet = new DataSet(m_dataSetName);
        IFeature pfeature = null;
        string strlayerName;
        int columnFid = 0;
        int rowIndex=-1;
        int fieldIndex;

        public UpdateFeaturesForm(IHookHelper hookhelper)
        {
            InitializeComponent();
            pHookHelper = hookhelper;
            pMapControl = pHookHelper.Hook as IMapControl3;
            pMap = pMapControl.Map;
            pActiveView = pMapControl.ActiveView;

        }

        private void UpdateFeaturesForm_Load(object sender, EventArgs e)
        {
            Addlayers();
        }

        private void Addlayers()
        {
            if (GetLayers() == null) return;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    cbxFeaturelayer.Items.Add(layer.Name);
                }
                layer = layers.Next();
            }
            cbxFeaturelayer.SelectedIndex = 0;
        }

        #region "GetLayers"
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";// IFeatureLayer
            //uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";  // IGeoFeatureLayer
            //uid.Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}";  // IDataLayer
            if (pMap.LayerCount != 0)
            {
                IEnumLayer layers = pMap.get_Layers(uid, true);
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

        private void cbxFeaturelayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            strlayerName = cbxFeaturelayer.SelectedItem.ToString();
            IFeatureLayer featureLayer = GetFeatureLayer(strlayerName);
            if (featureLayer == null) return;
            ConstructDataSet(featureLayer);
            dataGridView1.DataSource = m_layerDataSet;
            dataGridView1.DataMember = featureLayer.Name;
        }

        private void ConstructDataSet(IFeatureLayer pFeaLyr)
        {
            ILayerFields pFeatureLayerFields;
            pFeatureLayerFields = pFeaLyr as ILayerFields;
            IFeatureClass pFeatureClass = pFeaLyr.FeatureClass;
            if (m_layerDataSet.Tables[pFeaLyr.Name] == null)
            {
                DataTable pTable = new DataTable(pFeaLyr.Name);
                DataColumn pTableCol;
                for (int i = 0; i <= pFeatureLayerFields.FieldCount - 1; i++)
                {
                    pTableCol = new DataColumn(pFeatureLayerFields.get_Field(i).AliasName);
                    pTable.Columns.Add(pTableCol);
                    pTableCol = null;
                }
             
                    IFeatureCursor features = pFeaLyr.Search(null, false);
                    IFeature feature = features.NextFeature();
                    while (feature != null)
                    {
                        DataRow pTableRow = pTable.NewRow();
                        for (int i = 0; i <= pFeatureLayerFields.FieldCount - 1; i++)
                        {
                            //pTableRow[i] = feature.get_Value(i);
                            if (pFeatureLayerFields.FindField(pFeatureClass.ShapeFieldName) == i)
                            {
                                pTableRow[i] = pFeatureClass.ShapeType;
                            }
                            else
                            {
                                pTableRow[i] = feature.get_Value(i);
                            }
                        }
                        pTable.Rows.Add(pTableRow);
                        feature = features.NextFeature();
                    }
                    m_layerDataSet.Tables.Add(pTable);
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (rowIndex == null ) return;
            //int featureID = Convert.ToInt32(dataGridView1[columnFid, rowIndex].Value);

            //IFeatureLayer pfeatureLayer = GetFeatureLayer(strlayerName);

            //IFeatureClass pfeatureClass = pfeatureLayer.FeatureClass;
            //IFeature pfeature = pfeatureClass.GetFeature(featureID);

            //int fieldIndex = pfeatureClass.FindField(FieldsName);

            //object type = pfeatureClass.FindField(FieldsName).GetType();
            if (pfeature == null) return;
            if (txtValue.ToString() == "") return;
            pfeature.set_Value(fieldIndex, txtValue.ToString());
            pfeature.Store();
            //更新显示
            IFeatureLayer pfeaturelayer = GetFeatureLayer(cbxFeaturelayer.SelectedItem.ToString());
            ConstructDataSet(pfeaturelayer);
            dataGridView1.DataSource = m_layerDataSet;
            dataGridView1.DataMember = pfeaturelayer.Name;
            MessageBox.Show("更新完毕！");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            FieldsName = dataGridView1.Columns[columnIndex].Name; 
                //dataGridView1[columnIndex, 0].Value.ToString();
          rowIndex = dataGridView1.CurrentRow.Index;
           // int columnFid=0;
            for(int i=0;i<dataGridView1.ColumnCount ;i++)
            {
                if(dataGridView1[i,0].Value .ToString() =="ObjectID")
                {
                    columnFid =i;
                    break ;
                }
            }

            if (rowIndex == -1) return;
            int featureID = Convert.ToInt32(dataGridView1[columnFid, rowIndex].Value);
            IFeatureLayer pfeatureLayer = GetFeatureLayer(strlayerName);
            IFeatureClass pfeatureClass = pfeatureLayer.FeatureClass;
            pfeature = pfeatureClass.GetFeature(featureID);
             fieldIndex = pfeatureClass.FindField(FieldsName);
            object type = pfeatureClass.FindField(FieldsName).GetType();
           
           

        

          

        }

    }
}
     