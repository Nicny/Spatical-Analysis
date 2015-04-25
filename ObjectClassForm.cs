using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;

namespace SpatialDataManagement.空间数据管理
{
    public partial class ObjectClassForm : Form
    {
        IWorkspace workspace = null;
        string objectClassName = "";
        string strGDBDirectory = "";
        
        IObjectClass objectClass = null;//用于修改对象类属性

        public ObjectClassForm()
        {
            InitializeComponent();
        }

        private void ObjectClassForm_Load(object sender, EventArgs e)
        {

        }

        public void CreateObjectClassWithFields(IWorkspace workspace, String className)
        {
            // Cast the workspace to IFeatureWorkspace and IWorkspace2. An explicit cast is not used
            // for IWorkspace2 because not all workspaces implement it.
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;
            IWorkspace2 workspace2 = workspace as IWorkspace2;

            // See if a class with the provided name already exists. If so, return it.
            // Note that this will not work with file-based workspaces, such as shapefile workspaces.
            if (workspace2 != null)
            {
                if (workspace2.get_NameExists(esriDatasetType.esriDTTable, className))
                {
                    ITable existingTable = featureWorkspace.OpenTable(className);
                    IObjectClass objectClass= (IObjectClass)existingTable;
                }
            }

            // Use IFieldChecker.ValidateTableName to validate the name of the class. The 
            // tableNameErrorType variable is not used in this example, but it indicates the reasons 
            // the table name was invalid, if any.
            IFieldChecker fieldChecker = new FieldCheckerClass();
            String validatedClassName = null;
            fieldChecker.ValidateWorkspace = workspace;
            int tableNameErrorType = fieldChecker.ValidateTableName(className, out validatedClassName);

            // Create an object class description and get the required fields from it.
            IObjectClassDescription ocDescription = new ObjectClassDescriptionClass();
            IFields fields = ocDescription.RequiredFields;
            IFieldsEdit fieldsEdit = (IFieldsEdit)fields;

            // Add the Name field to the required fields.
            IField nameField = new FieldClass();
            IFieldEdit nameFieldEdit = (IFieldEdit)nameField;
            nameFieldEdit.Name_2 = "Name";
            nameFieldEdit.AliasName_2 = "Student_Name";
            nameFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            fieldsEdit.AddField(nameField);

            // Use the field checker created earlier to validate the fields.
            IEnumFieldError enumFieldError = null;
            IFields validatedFields = null;
            fieldChecker.Validate(fields, out enumFieldError, out validatedFields);

            // Create and return the object class.
            ITable table = featureWorkspace.CreateTable(validatedClassName, validatedFields, ocDescription.InstanceCLSID, null, "");
            IObjectClass objectclass= (IObjectClass)table;
            MessageBox.Show("创建对象类成功！");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ModifyObjectClassAliasName();
            ModifyFieldAliasName();
            if (txtNewObjectClassName.Text.ToString() == "") return;
            objectClassName = txtNewObjectClassName.Text.ToString();
            CreateObjectClassWithFields(workspace, objectClassName);
        }
 
        private void GetObjectClass()
        {
            IEnumDataset enumdataset = workspace.get_Datasets(esriDatasetType.esriDTTable);
            IDataset dataset;
            enumdataset.Reset();
            dataset = enumdataset.Next();
            while (dataset != null)
            {
                if (dataset is ITable)
                {
                    ITable table = dataset as ITable;
                    objectClass = table as IObjectClass;
                    cbxObjectClass.Items.Add(objectClass.AliasName.ToString());
                }
                dataset = enumdataset.Next();
            }
            //cbxObjectClass.SelectedIndex = 0;
        }     

        private void btnOpen_Click(object sender, EventArgs e)
        {
            IWorkspaceFactory workspaceFactory;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                strGDBDirectory = folderBrowserDialog1.SelectedPath;
                string gdbExt = System.IO.Path.GetExtension(strGDBDirectory);
                switch (gdbExt)
                {
                    case ".gdb":
                        workspaceFactory = new FileGDBWorkspaceFactoryClass();
                        workspace = workspaceFactory.OpenFromFile(strGDBDirectory, 0);
                        txtGDBName.Text = strGDBDirectory;
                        break;
                    case ".mdb":
                        workspaceFactory = new AccessWorkspaceFactoryClass();
                        workspace = workspaceFactory.OpenFromFile(strGDBDirectory, 0);
                        txtGDBName.Text = strGDBDirectory;
                        break;
                    default:
                        break;
                }

                GetObjectClass();
            }






        }
        
        private void GetFields()
        {
            IEnumDataset enumdataset = workspace.get_Datasets(esriDatasetType.esriDTTable);
            IDataset dataset; 
            enumdataset.Reset();
            dataset = enumdataset.Next();
            while (dataset != null)
            {
                if (dataset is ITable)
                {
                    ITable table = dataset as ITable;
                    IObjectClass pobjectclass = table as IObjectClass;
                    if (pobjectclass.AliasName == cbxObjectClass.Text)
                    {
                        objectClass = pobjectclass;
                        break;
                    }
                }
                dataset = enumdataset.Next();
            }

            if (objectClass == null) return;
              IFields fields;
              fields = objectClass.Fields;
              for (int i = 0; i < fields.FieldCount; i++)
              {
                  cbxFieldName.Items.Add(fields.get_Field(i).Name);

              }
              //cbxFieldName.SelectedIndex = 0;              
        }

        private void ModifyFieldAliasName()
        {
           
            if (txtFieldAliasName.Text == "") return;
            IClassSchemaEdit pOcSchemaEdit;
            pOcSchemaEdit = objectClass as IClassSchemaEdit;
            ISchemaLock pSchLock;
            pSchLock = objectClass as ISchemaLock;
            pSchLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
            pOcSchemaEdit.AlterFieldAliasName(cbxFieldName.Text , txtFieldAliasName.Text );
            pSchLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            MessageBox.Show("修改字段" + cbxFieldName.Text + "别名成功！");
        }

        private void ModifyObjectClassAliasName()
        {
            if (txtObjectClassAliaName.Text == "") return;
            IClassSchemaEdit pOcSchemaEdit;
            pOcSchemaEdit = objectClass as IClassSchemaEdit;
            ISchemaLock pSchLock;
            pSchLock = objectClass as ISchemaLock;
            pSchLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock);
            pOcSchemaEdit.AlterAliasName(txtObjectClassAliaName.Text);
            pSchLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock);
            MessageBox.Show("修改对象类" + cbxObjectClass.Text + "别名成功！");
        }

        private void cbxObjectClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFields();
        }      

        private void ObjectClassForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbxFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFieldAliasName.Enabled = true;
            if (cbxFieldName.Text == "OBJECTID" || cbxFieldName.Text == "FID")
            {
                txtFieldAliasName.Enabled = false;
            }
        }


    }
}
