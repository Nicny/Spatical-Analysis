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
    public partial class ConvertShapefileToFeatClass : Form
    {
        IWorkspace targetWorkspace;
        IWorkspace sourceWorkspace;
        IWorkspaceName sourceWorkspaceName;
        IWorkspaceName targetWorkspaceName;

        public ConvertShapefileToFeatClass()
        {
            InitializeComponent();
        }

        private void ConvertShapefileToFeatClass_Load(object sender, EventArgs e)
        {

        }

        public void ConvertShapefileToFeatureClass()
        {
                   
            // Create a name object for the source dataset.
            IFeatureClassName sourceFeatureClassName = new FeatureClassNameClass();
            IDatasetName sourceDatasetName = (IDatasetName)sourceFeatureClassName;
            sourceDatasetName.Name = txtSourcefeatureclass .Text ;
            sourceDatasetName.WorkspaceName = sourceWorkspaceName;

            IFeatureDatasetName targetFeatureDatasetName = new FeatureDatasetNameClass();
            IDatasetName targetDataserName = (IDatasetName)targetFeatureDatasetName;
            if (cbxTargetdataset.Text  == "") return ;
            else targetDataserName.Name = cbxTargetdataset.Text.ToString();
            targetDataserName.WorkspaceName = targetWorkspaceName;

            // Open source feature class to get field definitions.
            IName sourceName = (IName)sourceFeatureClassName;
            IFeatureClass sourceFeatureClass = (IFeatureClass)sourceName.Open();

            // Create the objects and references necessary for field validation.
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IFields sourceFields = sourceFeatureClass.Fields;
            IFields targetFields = null;
            IEnumFieldError enumFieldError = null;

            // Set the required properties for the IFieldChecker interface.
            fieldChecker.InputWorkspace = sourceWorkspace;
            fieldChecker.ValidateWorkspace = targetWorkspace;

            // Validate the fields and check for errors.
            fieldChecker.Validate(sourceFields, out enumFieldError, out targetFields);
            if (enumFieldError != null)
            {
                // Handle the errors in a way appropriate to your application.
                Console.WriteLine("Errors were encountered during field validation.");
            }

            // Find the shape field.
            String shapeFieldName = sourceFeatureClass.ShapeFieldName;
            int shapeFieldIndex = sourceFeatureClass.FindField(shapeFieldName);
            IField shapeField = sourceFields.get_Field(shapeFieldIndex);

            // Get the geometry definition from the shape field and clone it.
            IGeometryDef geometryDef = shapeField.GeometryDef;
            IClone geometryDefClone = (IClone)geometryDef;
            IClone targetGeometryDefClone = geometryDefClone.Clone();
            IGeometryDef targetGeometryDef = (IGeometryDef)targetGeometryDefClone;

            // Cast the IGeometryDef to the IGeometryDefEdit interface.
            IGeometryDefEdit targetGeometryDefEdit = (IGeometryDefEdit)targetGeometryDef;

            // Set the IGeometryDefEdit properties.
            targetGeometryDefEdit.GridCount_2 = 1;
            targetGeometryDefEdit.set_GridSize(0, 0.75);

        

            // Create the converter and run the conversion.
            IFeatureDataConverter featureDataConverter = new FeatureDataConverterClass();

            IEnumInvalidObject enumInvalidObject = featureDataConverter.ConvertFeatureClass
                (sourceFeatureClassName, null , targetFeatureDatasetName , null ,
                targetGeometryDef, targetFields, "", 1000, 0);

            // Check for errors.
            IInvalidObjectInfo invalidObjectInfo = null;
            enumInvalidObject.Reset();
            while ((invalidObjectInfo = enumInvalidObject.Next()) != null)
            {
                // Handle the errors in a way appropriate to the application.
                Console.WriteLine("Errors occurred for the following feature: {0}",
                    invalidObjectInfo.InvalidObjectID);
            }

            MessageBox.Show("转换成功！");
        }

        private void btnOpenShapefile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string shapefileLocation = openFileDialog.FileName;
                if (shapefileLocation != "")
                {
                    // Create a name object for the source (shapefile) workspace and open it.           
                    //sourceWorkspaceName = new WorkspaceNameClass
                    //{
                    //    WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory",
                    //    PathName = shapefileLocation
                    //};
                    sourceWorkspaceName = new WorkspaceNameClass();
                    sourceWorkspaceName.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";
                    sourceWorkspaceName.PathName = System.IO.Path.GetDirectoryName(shapefileLocation);

                    IName sourceWorkspaceIName = (IName)sourceWorkspaceName;
                    sourceWorkspace = (IWorkspace)sourceWorkspaceIName.Open();
                    txtsourceworkspace.Text = shapefileLocation;

                    IFeatureWorkspace featureWorkspace = sourceWorkspace as IFeatureWorkspace;
                    IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));
                    txtSourcefeatureclass.Text = featureClass.AliasName;
                }
            }  
        }

        private void btnOpenFilegdb_Click(object sender, EventArgs e)
        {
            OpenTargetGDB();
            getFeatureDataset();
        }

        private void  OpenTargetGDB()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
               
                string fileGDBLocation = folderBrowserDialog1.SelectedPath;
                string gdbExt = System.IO.Path.GetExtension(fileGDBLocation);

                IName targetWorkspaceIName;
                switch (gdbExt)
                {
                    case ".gdb":
                        // Create a name object for the target (file GDB) workspace and open it.
                        targetWorkspaceName = new WorkspaceNameClass
                        {
                            WorkspaceFactoryProgID = "esriDataSourcesGDB.FileGDBWorkspaceFactory",
                            PathName = fileGDBLocation
                        };
                         targetWorkspaceIName = (IName)targetWorkspaceName;
                        targetWorkspace = (IWorkspace)targetWorkspaceIName.Open();
                        txtTargetworkspace.Text = fileGDBLocation;
                        break;
                    case ".mdb":
                          targetWorkspaceName = new WorkspaceNameClass
                        {
                            WorkspaceFactoryProgID = "esriDataSourcesGDB.AccessWorkspaceFactory",
                            PathName = fileGDBLocation
                        };
                        targetWorkspaceIName = (IName)targetWorkspaceName;
                        targetWorkspace = (IWorkspace)targetWorkspaceIName.Open();
                        txtTargetworkspace.Text = fileGDBLocation;
                        break;                      
                }            
                }
            }

        private void getFeatureDataset()
        {
            if (targetWorkspace == null) return;
            cbxTargetdataset.Items.Clear();
            IEnumDataset enumDataset = targetWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            IFeatureDataset featuredataset;
            enumDataset.Reset();
            featuredataset = enumDataset.Next() as IFeatureDataset;
            while (featuredataset != null)
            {
                cbxTargetdataset.Items.Add(featuredataset.Name);
                 
                featuredataset = enumDataset.Next() as IFeatureDataset;
            }
           
                    
        }
      
        private void btnOK_Click(object sender, EventArgs e)
        {
           
          ConvertShapefileToFeatureClass();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ConvertShapefileToFeatClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void cbxTargetdataset_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
