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
using ESRI.ArcGIS.esriSystem;

namespace SpatialDataManagement.空间数据管理
{
    public partial class Create_Table : Form
    {
        string strGDBDirectory;

        IWorkspace workspace = null;
        string tableName = "";

        public Create_Table()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableName =txtTableName .Text .ToString ();
            if (tableName == "") return;
            IFields fields=CreateFieldsCollectionForTable ();
            IWorkspace2 pworkspace;
            pworkspace = workspace as IWorkspace2;
            ITable table = CreateTable(pworkspace, tableName, fields);
            MessageBox.Show("已成功创建了表：" + tableName);
        }

        private void button1_Click(object sender, EventArgs e)
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
                        txtGDBName.Text = strGDBDirectory ;
                        break;
                    case ".mdb":
                        workspaceFactory = new AccessWorkspaceFactoryClass();
                        workspace = workspaceFactory.OpenFromFile(strGDBDirectory, 0);
                        txtGDBName.Text = strGDBDirectory ;
                        break;
                    default:
                        break;
                }

            }


        }

        public ITable CreateTable(IWorkspace2 workspace, String tableName, IFields fields)
        {
            // create the behavior clasid for the featureclass
           UID uid = new UIDClass();

            if (workspace == null) return null; // valid feature workspace not passed in as an argument to the method

            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace; // Explicit Cast
            ITable table;

            if (workspace.get_NameExists(esriDatasetType.esriDTTable, tableName))
            {
                // table with that name already exists return that table 
                table = featureWorkspace.OpenTable(tableName);
                return table;
            }

            uid.Value = "esriGeoDatabase.Object";

            IObjectClassDescription objectClassDescription = new ObjectClassDescriptionClass();

            // if a fields collection is not passed in then supply our own
            if (fields == null)
            {
                // create the fields using the required fields method
                fields = objectClassDescription.RequiredFields;
                IFieldsEdit fieldsEdit = (IFieldsEdit)fields; // Explicit Cast

                IField field = new FieldClass();

                // create a user defined text field
                IFieldEdit fieldEdit = (IFieldEdit)field; // Explicit Cast

                // setup field properties
                fieldEdit.Name_2 = "SampleField";
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                fieldEdit.IsNullable_2 = true;
                fieldEdit.AliasName_2 = "Sample Field Column";
                fieldEdit.DefaultValue_2 = "test";
                fieldEdit.Editable_2 = true;
                fieldEdit.Length_2 = 100;

                // add field to field collection
                fieldsEdit.AddField(field);
                fields = (IFields)fieldsEdit; // Explicit Cast
            }

            // Use IFieldChecker to create a validated fields collection.
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IEnumFieldError enumFieldError = null;
            IFields validatedFields = null;
            fieldChecker.ValidateWorkspace = (IWorkspace)workspace;
            fieldChecker.Validate(fields, out enumFieldError, out validatedFields);

            // The enumFieldError enumerator can be inspected at this point to determine 
            // which fields were modified during validation.


            // create and return the table
            table = featureWorkspace.CreateTable(tableName, validatedFields, uid, null, "");

            return table;
        }

        public IFields CreateFieldsCollectionForTable()
        {
            // Create a fields collection.
            IFields fields = new FieldsClass();

            // Cast to IFieldsEdit to modify the properties of the fields collection.
            IFieldsEdit fieldsEdit = (IFieldsEdit)fields;

            // Create the ObjectID field.
            IField oidField = new FieldClass();

            // Cast to IFieldEdit to modify the properties of the new field.
            IFieldEdit oidFieldEdit = (IFieldEdit)oidField;
            oidFieldEdit.Name_2 = "ObjectID";
            oidFieldEdit.AliasName_2 = "FID";
            oidFieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;

            // Add the new field to the fields collection.
            fieldsEdit.AddField(oidField);

            // Create the text field.
            IField textField = new FieldClass();
            IFieldEdit textFieldEdit = (IFieldEdit)textField;
            textFieldEdit.Length_2 = 30;
            // Only string fields require that you set the length.
            textFieldEdit.Name_2 = "Owner";
            textFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;

            // Add the new field to the fields collection.
            fieldsEdit.AddField(textField);

            return fields;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Create_Table_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void Create_Table_Load(object sender, EventArgs e)
        {

        }

    }

}
