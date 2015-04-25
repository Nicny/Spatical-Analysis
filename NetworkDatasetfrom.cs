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
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesGDB;

namespace SpatialDataManagement.空间数据管理
{
    public partial class NetworkDatasetfrom : Form
    {
        IHookHelper m_hookhelper=null ;
        IMapControl3 m_mapcontrol;

        IWorkspace pWorkspace = null;
        String networkDatasetName;
        String featureDatasetName;

        IEnumDataset enumNetworkDataset=null ;

        public NetworkDatasetfrom(object  hook)
        {
            if (hook == null)
                return;

            if (m_hookhelper == null)
                m_hookhelper = new HookHelperClass();
            m_hookhelper.Hook = hook;

            InitializeComponent();    
            m_mapcontrol = m_hookhelper.Hook as IMapControl3;
        }

        private void button1_Click(object sender, EventArgs e)
        {        
           
           // Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory");  //("esriDataSourcesGDB.AccessWorkspaceFactory");
           //IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance (factoryType);
           // pWorkspace =workspaceFactory.OpenFromFile("C:\\arcgis\\ArcTutor\\Network Analyst\\Tutorial\\SanFrancisco.gdb", 0);
            IWorkspaceFactory workspaceFactory;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                workspaceFactory = new FileGDBWorkspaceFactoryClass();
                pWorkspace = workspaceFactory.OpenFromFile(folderBrowserDialog1.SelectedPath, 0);
                txtGDBName.Text = System.IO.Path.GetFileName(folderBrowserDialog1.SelectedPath);
            }
            GetDateset();
        }

        private void GetDateset()
        {
            IEnumDataset pEnumDataset;
            if (pWorkspace == null) return; 
            pEnumDataset = pWorkspace.get_Datasets(esriDatasetType.esriDTAny);
            IDataset pDataset;
            pEnumDataset.Reset();
            pDataset = pEnumDataset.Next();
            if (pDataset == null) {
                MessageBox.Show("there is no dataset in this database!");
                return; }

            cbxFeatureDataset.Items.Clear();
            while (pDataset != null)
            {
                if (pDataset.Type == esriDatasetType.esriDTFeatureDataset)
                {
                    cbxFeatureDataset.Items.Add(pDataset.Name.ToString());            
                }
               
                pDataset = pEnumDataset.Next();
            }
            if (cbxFeatureDataset.Items.Count == 0) { MessageBox.Show("no featuredataset be found!"); return; }
            cbxFeatureDataset.SelectedIndex = 0;

        }

        private void cbxFeatureDataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            featureDatasetName = cbxFeatureDataset.SelectedItem.ToString();
           enumNetworkDataset =  GetNtDataset();
        }
        private IEnumDataset  GetNtDataset()
        {
            IDatasetContainer3 datasetContainer3 = null;
            IFeatureWorkspace pFeatWorkspace = pWorkspace as IFeatureWorkspace;
            IFeatureDataset featureDataset= pFeatWorkspace.OpenFeatureDataset(featureDatasetName);
            IFeatureDatasetExtensionContainer featureDatasetExtensionContainer = featureDataset as IFeatureDatasetExtensionContainer; // Dynamic Cast
            IFeatureDatasetExtension featureDatasetExtension = featureDatasetExtensionContainer.FindExtension(esriDatasetType.esriDTNetworkDataset);
            datasetContainer3 = featureDatasetExtension as ESRI.ArcGIS.Geodatabase.IDatasetContainer3;
            if (datasetContainer3 == null)
                return null  ;

            IEnumDataset enumNTdataset = datasetContainer3.get_Datasets(esriDatasetType.esriDTNetworkDataset);  
            IDataset networkDataset;
            enumNTdataset.Reset();
            networkDataset = enumNTdataset.Next();
            if (enumNTdataset == null) { return  null ; }

            cbxNetworkdataset.Items.Clear();
            while (networkDataset  != null)
            {
                cbxNetworkdataset .Items .Add (networkDataset .Name .ToString ());
                networkDataset = enumNTdataset.Next();
            }
          
            return enumNTdataset;
        }

        private void cbxNetworkdataset_SelectedIndexChanged(object sender, EventArgs e)
        {
            networkDatasetName = cbxNetworkdataset.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {     
            if (enumNetworkDataset == null) return;

            IDataset Dataset;
            enumNetworkDataset.Reset();
            Dataset = enumNetworkDataset.Next();

            INetworkDataset pnetworkDataset=null ;
            while (Dataset.Name .ToString()==cbxNetworkdataset.SelectedItem .ToString ())
            {
                 pnetworkDataset = Dataset as INetworkDataset;
                break;
            }
            Dataset = enumNetworkDataset.Next();

            if (pnetworkDataset == null) return;
            INetworkLayer pnetworklayer = new NetworkLayerClass();
            pnetworklayer.NetworkDataset = pnetworkDataset;
            ILayer player;
            
            player = pnetworklayer as ILayer;
            player.Name = cbxNetworkdataset.SelectedItem.ToString();
            m_mapcontrol.AddLayer(player, 0);
            // Redraw the map
           m_mapcontrol.ActiveView.Refresh();
        }

        private void NetworkDatasetfrom_Load(object sender, EventArgs e)
        {

        }

        private void NetworkDatasetfrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
     
        private void cbxFeatureclass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
