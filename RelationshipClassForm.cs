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
    public partial class RelationshipClassForm : Form
    {
        IWorkspace workspace;

        //用于获取表或要素类
        IEnumDataset enumdataset;
        IDataset dataset;
        string datasetType;

        public RelationshipClassForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
             workspace = OpenGDB();
             
        }

        private IWorkspace OpenGDB()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                IWorkspaceFactory workspaceFactory;
                workspaceFactory = new FileGDBWorkspaceFactoryClass();
                workspace = workspaceFactory.OpenFromFile(folderBrowserDialog1.SelectedPath, 0);
            }
            return workspace;         
        }

        private void AddfeatureclassOrTable()
        {
            cbxOriginClass.Items.Clear();
            cbxDestinationClass.Items.Clear();
            IFeatureWorkspace featureworkspace = (IFeatureWorkspace)workspace;
             enumdataset = workspace.get_Datasets(esriDatasetType.esriDTAny );
            enumdataset.Reset();
            dataset = enumdataset.Next();
            while (dataset != null)
            {
                //获取要素数据集中的要素类
                if (dataset.Type == esriDatasetType.esriDTFeatureDataset )
                {
                    IFeatureDataset featuredataset = dataset as IFeatureDataset;
                    IEnumDataset penumdataset = featuredataset.Subsets;
                    IDataset pdataset;
                    penumdataset.Reset();
                    pdataset = penumdataset.Next();
                    while (pdataset !=null )
                    {
                        if (pdataset.Type == esriDatasetType.esriDTFeatureClass || pdataset.Type == esriDatasetType.esriDTTable )
                        {
                            cbxOriginClass.Items.Add(pdataset.Name);
                            cbxDestinationClass.Items.Add(pdataset.Name);
                            
                        }
                        pdataset = penumdataset.Next();
                    }
                   
                }
                //获取独立要素类和表
                if (dataset.Type == esriDatasetType.esriDTFeatureClass || dataset.Type == esriDatasetType.esriDTTable)
                {
                    cbxOriginClass.Items.Add(dataset.Name);
                    cbxDestinationClass.Items.Add(dataset.Name);
                }
                dataset = enumdataset.Next();
            }

        }

        private string  getDatasetType(string datasetName)
        {

            enumdataset.Reset();
            IDataset dataset;
            dataset = enumdataset.Next();
            while (dataset != null)
            {
                if (dataset.Type == esriDatasetType.esriDTFeatureDataset)
                {
                    IFeatureDataset featuredataset = dataset as IFeatureDataset;
                    IEnumDataset penumdataset = featuredataset.Subsets;
                    IDataset pdataset;
                    penumdataset.Reset();
                    pdataset = penumdataset.Next();
                    while (pdataset != null)
                    {
                        if (pdataset.Name == datasetName)
                        {
                            if (pdataset.Type == esriDatasetType.esriDTTable)
                            { datasetType = "table"; break; }
                            if (pdataset.Type == esriDatasetType.esriDTFeatureClass)
                            { datasetType = "featureclass"; break; }
                        }
                        pdataset = penumdataset.Next();
                    }                
                }

                if (dataset.Name == datasetName)
                {
                    if (dataset.Type == esriDatasetType.esriDTTable)
                    { datasetType = "table"; break; }
                    if (dataset.Type == esriDatasetType.esriDTFeatureClass)
                    { datasetType = "featureclass"; break; }                
                }
                dataset = enumdataset.Next();


            }
            return datasetType;
        }

        public void CreateRelClass(IFeatureWorkspace featureWorkspace)
        {
            if (featureWorkspace == null) return  ;
            // Open the participating classes from the workspace.
            string strOriginClass = getDatasetType(cbxOriginClass.Text);
            IObjectClass originClass=null ;
            switch (strOriginClass)
            {
                case "table":
                    originClass = (IObjectClass)featureWorkspace.OpenTable(cbxOriginClass.Text);
                    break;
                case "featureclass":
                    originClass = featureWorkspace.OpenFeatureClass(cbxOriginClass.Text);
                    break;
                case "":         
                    return;
                default: break;
            }

            //
            string strDestinationClass = getDatasetType(cbxDestinationClass.Text);
            IObjectClass destinationClass=null ;
            switch (strDestinationClass)
            {
                case "table":
                    destinationClass = (IObjectClass)featureWorkspace.OpenTable(cbxDestinationClass.Text);
                    break;
                case "featureclass":
                    destinationClass = featureWorkspace.OpenFeatureClass(cbxDestinationClass.Text);
                    break;
                case "":
                    return;
                default: break;
            }
          
            //关系类型
            string strType;
            strType = cbxType .SelectedItem .ToString ();
            bool IsComposite;
            switch (strType)
            {
                case "Simple":
                    IsComposite = false;
                    break;
                case "Composite":
                    IsComposite = true;
                    break;
                default:
                    IsComposite =false ;
                    break;
            }

            //关系基数（1-1，1-m，m-n）
            string cardinality;
            cardinality =cbxCardinality .SelectedItem.ToString ();      
            esriRelCardinality Relcardinality;
            switch (cardinality)
            {
                case "一对一":
                     Relcardinality=esriRelCardinality.esriRelCardinalityOneToOne  ;
                    break;
                case "一对多":
                    Relcardinality = esriRelCardinality.esriRelCardinalityOneToMany ;
                    break;
                case "多对多":
                     Relcardinality = esriRelCardinality.esriRelCardinalityManyToMany ;
                    break;
                default:
                    Relcardinality=esriRelCardinality.esriRelCardinalityOneToOne  ;
                    break;
       
            }

            try
            {
                // Creating a non-attributed relationship class.
                IRelationshipClass relClass = featureWorkspace.CreateRelationshipClass
                    (txtrelationshipclassName.Text, originClass, destinationClass, cbxDestinationClass.Text, cbxOriginClass.Text,
                    Relcardinality, esriRelNotification.esriRelNotificationNone, IsComposite, false, null, "OBJECTID",
                    "", "OBJECTID", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           
        }


        private void RelationshipClassForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenGDB();
            AddfeatureclassOrTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          CreateRelClass(workspace as IFeatureWorkspace);
        }

    }
}
