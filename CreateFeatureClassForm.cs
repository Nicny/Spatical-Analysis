using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesGDB;

namespace SpatialDataManagement.空间数据管理
{
    public partial class CreateFeatureClassForm : Form
    {
        IWorkspace pworkspace = null;
        IFeatureDataset pfeatureDataset = null;
        string featureDatasetName = "";
        string featureClassName="";
        IFeatureDataset featureDataset = null;


        public CreateFeatureClassForm()
        {
            InitializeComponent();
        }

        public void CreateFeatureClass(IWorkspace2 workspace, IFeatureDataset featureDataset, String featureClassName)//, ESRI.ArcGIS.Geodatabase.IFields fields, UID CLSID, UID CLSEXT, System.String strConfigKeyword)
        {
            if (featureClassName == "") return ; // name was not passed in 

            IFeatureClass featureClass;
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace; // Explicit Cast

            if (workspace.get_NameExists(esriDatasetType.esriDTFeatureClass, featureClassName)) //feature class with that name already exists 
            {
                featureClass = featureWorkspace.OpenFeatureClass(featureClassName);
                return;
            }
     
            UID CLSID;
            CLSID = new UIDClass();
            CLSID.Value = "esriGeoDatabase.Feature";

            IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();

       
               IFields fields=new FieldsClass() ;
                fields = objectClassDescription.RequiredFields;
                IFieldsEdit fieldsEdit = (IFieldsEdit)fields; // Explicit Cast
                IField field = new FieldClass();

                // create a user defined text field
                IFieldEdit fieldEdit = (IFieldEdit)field; // Explicit Cast

                // setup field properties
                fieldEdit.Name_2 = "SampleField";
                fieldEdit.Type_2 = ESRI.ArcGIS.Geodatabase.esriFieldType.esriFieldTypeString;
                fieldEdit.IsNullable_2 = true;
                fieldEdit.AliasName_2 = "Sample Field Column";
                fieldEdit.DefaultValue_2 = "test";
                fieldEdit.Editable_2 = true;
                fieldEdit.Length_2 = 100;

                // add field to field collection
                fieldsEdit.AddField(field);
                fields = (IFields)fieldsEdit; // Explicit Cast
       

            System.String strShapeField = "";

            // locate the shape field
            for (int j = 0; j < fields.FieldCount; j++)
            {
                if (fields.get_Field(j).Type == esriFieldType.esriFieldTypeGeometry)
                {
                    strShapeField = fields.get_Field(j).Name;
                }
            }

            // Use IFieldChecker to create a validated fields collection.
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IEnumFieldError enumFieldError = null;
            IFields validatedFields = null;
            fieldChecker.ValidateWorkspace = (IWorkspace)workspace;
            fieldChecker.Validate(fields, out enumFieldError, out validatedFields);

            // finally create and return the feature class
            if (featureDataset == null)// 如果未选择要素数据集，则在数据库中建立独立的要素类
            {
                featureClass = featureWorkspace.CreateFeatureClass(featureClassName, validatedFields, CLSID, null , ESRI.ArcGIS.Geodatabase.esriFeatureType.esriFTSimple, strShapeField,"");
                MessageBox.Show("成功创建了名为" + txtFeatureclassname.Text, ToString() + "的独立要素类！");
            }
            else
            {
                featureClass = featureDataset.CreateFeatureClass(featureClassName, validatedFields, CLSID, null , ESRI.ArcGIS.Geodatabase.esriFeatureType.esriFTSimple, strShapeField, "");
                MessageBox.Show ("已在"+cbxFeatureDataset .Text.ToString ()+"中成功创建了名为"+txtFeatureclassname.Text.ToString ()+"的要素类!");
            }       

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory");  //("esriDataSourcesGDB.AccessWorkspaceFactory");
            //IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance(factoryType);
            //pworkspace = workspaceFactory.OpenFromFile("C:\\arcgis\\ArcTutor\\Network Analyst\\Tutorial\\SanFrancisco.gdb", 0);
           IWorkspaceFactory workspaceFactory;

           if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
           {
                       workspaceFactory = new FileGDBWorkspaceFactoryClass();
                       pworkspace = workspaceFactory.OpenFromFile(folderBrowserDialog1.SelectedPath, 0);
                       txtGDBName.Text = System.IO.Path .GetFileName( folderBrowserDialog1.SelectedPath);                  
           }


            GetDateset();
        }

        private void GetDateset()
        {
            IEnumDataset pEnumDataset;

            pEnumDataset = pworkspace.get_Datasets(esriDatasetType.esriDTAny);
            IDataset pDataset;
            pEnumDataset.Reset();
            pDataset = pEnumDataset.Next();
            if (pDataset == null)
            {
                MessageBox.Show("there is no dataset in this database!");
                return;
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (pworkspace == null) return;
            IWorkspace2 worksapce = (IWorkspace2)pworkspace;
            if (worksapce.get_NameExists(esriDatasetType.esriDTFeatureClass, featureClassName))
            {
                MessageBox.Show("该名称已存在，请重新输入!");
                txtFeatureclassname.Text = "";
            }
            else
            {
                MessageBox.Show("该名称可用！");
                featureClassName = txtFeatureclassname.Text.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            featureDatasetName = cbxFeatureDataset.Text.ToString();
            featureDataset = GetFeatureDataset(featureDatasetName);
           CreateFeatureClass((IWorkspace2 )pworkspace, featureDataset, featureClassName);
        }

        private IFeatureDataset GetFeatureDataset(string strfeatureDatasetName)
        {
            if (pworkspace == null) return null ;
            IFeatureWorkspace featureSpace=pworkspace as IFeatureWorkspace ;
            if (featureDatasetName != "")
            {
                featureDataset = featureSpace.OpenFeatureDataset(strfeatureDatasetName);
                return featureDataset;

            }
            else return null;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtFeatureclassname_TextChanged(object sender, EventArgs e)
        {
            featureClassName = txtFeatureclassname.Text.ToString();
        }

        private void cbxFeatureDataset_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateFeatureClassForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateFeatureClassForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
     
    }
}
