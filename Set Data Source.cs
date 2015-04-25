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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;

namespace SpatialDataManagement.空间数据管理
{
    public partial class Set_Data_Source : Form
    {
        IHookHelper m_hookhelper;
        IMapControl3 m_mapcontrol;
        IMap m_map;
        IActiveView m_activeView;

        IWorkspace workspace=null ;
        string standAlonefeatureClassName = "";
        string featureDatasetName = "";
        string featureClassName = "";
        string layerName = "";
        public Set_Data_Source(object hook)
        {
            if (hook == null)
                return;

            if (m_hookhelper == null)
                m_hookhelper = new HookHelperClass();
            m_hookhelper.Hook = hook;
            InitializeComponent();
            m_mapcontrol = m_hookhelper.Hook as IMapControl3;
            m_map = m_mapcontrol.Map;
            m_activeView = m_mapcontrol.ActiveView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory");  //("esriDataSourcesGDB.AccessWorkspaceFactory");
            //IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance(factoryType);
            //workspace = workspaceFactory.OpenFromFile("C:\\arcgis\\ArcTutor\\Network Analyst\\Tutorial\\SanFrancisco.gdb", 0);//("C:\\Program Files\\ArcGIS\\DeveloperKit10.0\\Samples\\data\\Yellowstone\\veg.gdb", 0);
            IWorkspaceFactory workspaceFactory;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                workspaceFactory = new FileGDBWorkspaceFactoryClass();
                workspace = workspaceFactory.OpenFromFile(folderBrowserDialog1.SelectedPath, 0);
                txtGDBName.Text = System.IO.Path.GetFileName(folderBrowserDialog1.SelectedPath);
            }

            GetFeatureClass();
        }
        
        //获取独立要素类
        private void Getfeatureclass()
        {
            IFeatureWorkspace featureworkspace = (IFeatureWorkspace)workspace;
            IEnumDataset enumDataset;
            enumDataset = workspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
            IDataset pfeatureclass;
            enumDataset .Reset ();
            pfeatureclass = enumDataset.Next();
            if (pfeatureclass == null)
            {
                MessageBox.Show("there is no stand_alone featureclass in this database!");
            }
            while (pfeatureclass != null)
            {
                cbxfeatureclass.Items.Add(pfeatureclass.Name.ToString());
                pfeatureclass = enumDataset.Next();
            }
            cbxfeatureclass.SelectedIndex = 0;
        }
        //获取要素数据集
        private void GetFeatureDataset()
        {
            if (workspace == null) return;
            IFeatureWorkspace featureworkspace = (IFeatureWorkspace)workspace;
            IEnumDataset enumDataset;
            enumDataset = workspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            IDataset pfeaturedataset;
            enumDataset.Reset();
            pfeaturedataset = enumDataset.Next();
            if (pfeaturedataset == null)
            {
                MessageBox.Show("there is no dataset in this database!");
                return;
            }
            while (pfeaturedataset != null)
            {
                cbxfeaturedataset.Items.Add(pfeaturedataset.Name.ToString());
                pfeaturedataset = enumDataset.Next();
            }

            cbxfeaturedataset.SelectedIndex = 0;

 
           
        }
        //获取要素数据集中的要素类
        private void GetFeatureClass()
        {
            cbxfeatureclass.Items.Clear();
            if (workspace == null) return;
            IFeatureWorkspace featureworkspace = (IFeatureWorkspace)workspace;
            if (featureDatasetName == "") return;
            IFeatureDataset featureDataset = featureworkspace.OpenFeatureDataset(featureDatasetName);

            IEnumDataset enumdataset = featureDataset.Subsets;
            IDataset dataset;
            enumdataset.Reset();
            dataset = enumdataset.Next();
            if (dataset == null) return;
            
            while (dataset != null)
            {
                cbxfeatureclass.Items.Add(dataset.Name.ToString());
                dataset = enumdataset.Next();
            }
            cbxfeatureclass.SelectedIndex = 0;
        }
        
        private void Set_Data_Source_Load(object sender, EventArgs e)
        {
            addLayer();
            radFeatureClass.Checked = true;
        }

        private void addLayer()
        {
            if (m_mapcontrol.LayerCount == 0) return;
            ILayer player;
            for (int i = 0; i < m_mapcontrol.LayerCount; i++)
            {
                if (m_mapcontrol.get_Layer(i) is IFeatureLayer)
                {
                    player = m_mapcontrol.get_Layer(i);
                    cbxLayer.Items.Add(player.Name.ToString());
                }
            }           
        }
        private IFeatureLayer Getfeaturelayer(string layername)
        {
            IFeatureLayer featurelayer=null ;
            ILayer player=null ;
            for (int i = 0; i < m_mapcontrol.LayerCount; i++)
            {
                if (m_mapcontrol.get_Layer(i).Name.ToString() == layername)
                {
                    player = m_mapcontrol.get_Layer(i);
                    break;
                }
            }
            if(player ==null )return null ;
            featurelayer =player as IFeatureLayer ;
            return featurelayer ;
        }
              
        private void cbxfeaturedataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            featureDatasetName = cbxfeaturedataset.SelectedItem.ToString();
            GetFeatureClass();
        }

        private void cbxfeatureclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            featureClassName = cbxfeatureclass.SelectedItem.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IFeatureLayer featurelayer = Getfeaturelayer(layerName );
            string strFeatureClassName ;
            if (standAlonefeatureClassName == "") strFeatureClassName = featureClassName;
            else strFeatureClassName = standAlonefeatureClassName;

            SetDataSource(strFeatureClassName, featureDatasetName,featurelayer );
        }

        private void cbxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            layerName = cbxLayer.SelectedItem.ToString();
        }

        public void SetDataSource(String strFeatureClassName, String strFeatureDatasetName,IFeatureLayer featurelayer)
        {
            if (strFeatureClassName == "") return;
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;
            IFeatureClass newFeatureClass = null;
            IFeatureDataset featureDataset = null;
            IFeatureClassContainer featureClassContainer = null;
            if (strFeatureDatasetName != "")
            {
                featureDataset = featureWorkspace.OpenFeatureDataset(strFeatureDatasetName);
                featureClassContainer = (IFeatureClassContainer)featureDataset;
                newFeatureClass = featureClassContainer.get_ClassByName(strFeatureClassName);
            }
            else
            {
                newFeatureClass = featureWorkspace.OpenFeatureClass(strFeatureClassName);
            }

            // Cast from IMap to IMapAdmin2
            IMapAdmin2 mapAdmin2 = (ESRI.ArcGIS.Carto.IMapAdmin2)m_map;

            IFeatureClass oldFeatureClass = featurelayer.FeatureClass;
            // Change FeatureClass of layer
            featurelayer.FeatureClass = newFeatureClass;
            mapAdmin2.FireChangeFeatureClass(oldFeatureClass, newFeatureClass);

            // Redraw the map
            m_activeView.Refresh();

            // Update and Refresh TOC
            if (featureDataset != null)
            {
                IFeatureDataset newFeatureDataset = (IFeatureDataset)featureClassContainer;
                featurelayer.Name = newFeatureDataset.Name + " " + newFeatureClass.AliasName;
            }
            else featurelayer.Name = newFeatureClass.AliasName;

           // //IContentsView contentsView = mxDocument.CurrentContentsView;
           // //contentsView.Refresh(null);
           //// axTOCControl1.Update();
        }

        private void cbxFeatureClassAlone_SelectedIndexChanged(object sender, EventArgs e)
        {
            standAlonefeatureClassName = cbxFeatureClassAlone.SelectedItem.ToString();
        }

        private void radFeatureDataset_CheckedChanged(object sender, EventArgs e)
        {
            GetFeatureDataset();
        }

        private void radFeatureClass_CheckedChanged(object sender, EventArgs e)
        {
           // GetFeatureClass();
        }
    }
}
