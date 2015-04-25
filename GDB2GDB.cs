using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.VisualBasic;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.GeoSurvey;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.EditorExt;


namespace CoordinateTransformation
{
    //GDB2GDB类的功能：实现Geodatabase数据库的拷贝
    //拷贝过程中可以设置Z、M是否有效
    public partial class GDB2GDB : Form
    {
        IWorkspaceFactory workspaceFactory = null;
        IWorkspace sourceWorkspace = null;
        IWorkspace targetWorkspace = null;

        string sourceGDBDirectory;
        string sourceGDBName;
        string targetGDBDirectory;

        bool bHasZ = false;
        bool bHasM = false;

        public GDB2GDB()
        {
            InitializeComponent();
        }        

        //选择用于拷贝的源数据库：可以是*.gdb或*.mdb
        private void btnSelectSourceDB_Click(object sender, EventArgs e)
        {
            IEnumGxObject gxObjects = AddDatasetWithGxDialog();
            IGxObject gxObject = gxObjects.Next();
            if (gxObject == null) return;
            sourceGDBDirectory = gxObject.FullName;
            sourceGDBName = System.IO.Path.GetFileNameWithoutExtension(sourceGDBDirectory);
            string gdbExt = System.IO.Path.GetExtension(sourceGDBDirectory);
            switch (gdbExt)
            {
                case ".gdb":
                    workspaceFactory = new FileGDBWorkspaceFactoryClass();
                    sourceWorkspace = workspaceFactory.OpenFromFile(sourceGDBDirectory, 0);
                    break;
                case ".mdb":
                    workspaceFactory = new AccessWorkspaceFactoryClass();
                    sourceWorkspace = workspaceFactory.OpenFromFile(sourceGDBDirectory, 0);
                    break;
                default:
                    break;
            }

            if (sourceWorkspace == null) return;

            trvSourceGDB.Nodes.Clear();
            trvTargetGDB.Nodes.Clear();
            TreeNode rootnode = new TreeNode("源数据库" + "--" + sourceGDBDirectory);
            trvSourceGDB.Nodes.Add(rootnode);

            IEnumDataset featureDatasets = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            TreeViewAddNodes(featureDatasets, rootnode);
            IEnumDataset featureClasses = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
            TreeViewAddNodes(featureClasses, rootnode);
            trvSourceGDB.Sort();
        }

        //选择目标数据库
        private void btnSelectTargetDB_Click(object sender, EventArgs e)
        {
            targetWorkspace = OpenTargetGDB();
        }
        //目标数据库：可以是*.gdb或*.mdb，如果选择的目标路径不含Geodatabase数据库，则新建一gdb
        private IWorkspace OpenTargetGDB()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                IWorkspace workspace = null;
                targetGDBDirectory = folderBrowserDialog1.SelectedPath;
                string gdbExt = System.IO.Path.GetExtension(targetGDBDirectory);
                switch (gdbExt)
                {
                    case ".gdb":
                        workspaceFactory = new FileGDBWorkspaceFactoryClass();
                        workspace = workspaceFactory.OpenFromFile(targetGDBDirectory, 0);
                        break;
                    case ".mdb":
                        workspaceFactory = new AccessWorkspaceFactoryClass();
                        workspace = workspaceFactory.OpenFromFile(targetGDBDirectory, 0);
                        break;
                    case "":
                        workspaceFactory = new FileGDBWorkspaceFactoryClass();
                        string gdbName = sourceGDBName + ".gdb";
                        string gdbFullPath = System.IO.Path.Combine(targetGDBDirectory, gdbName);
                        if (System.IO.Directory.Exists(gdbFullPath))
                        {
                            workspace = workspaceFactory.OpenFromFile(gdbFullPath, 0);
                        }
                        else
                        {
                            IWorkspaceName workspaceName = workspaceFactory.Create(targetGDBDirectory, gdbName, null, 0);
                            IName name = (ESRI.ArcGIS.esriSystem.IName)workspaceName;
                            workspace = (IWorkspace)name.Open();
                        }
                        break;
                    default:
                        break;
                }
                return workspace;
            }
            return null;
        }

        //拷贝数据库的属性域
        public void CopyDomains(IWorkspace sourceWorkspace, IWorkspace targetWorkspace)
        {
            IWorkspaceDomains targetWorkspaceDomains = (IWorkspaceDomains)targetWorkspace;
            IWorkspaceDomains sourceWorkspaceDomains = (IWorkspaceDomains)sourceWorkspace;
            IEnumDomain sourceDomains = sourceWorkspaceDomains.Domains;
            if (sourceDomains == null) return;
            IDomain sourceDomain = sourceDomains.Next();
            IDomain targetDomain = null;
            while (sourceDomain != null)
            {
                if (sourceDomain is IRangeDomain)
                {
                    IRangeDomain rangeDomain = new RangeDomainClass();
                    rangeDomain.MinValue = (sourceDomain as IRangeDomain).MinValue;
                    rangeDomain.MaxValue = (sourceDomain as IRangeDomain).MaxValue;
                    targetDomain = rangeDomain as IDomain;
                }
                if (sourceDomain is ICodedValueDomain)
                {
                    ICodedValueDomain sourceCodedDomain =sourceDomain as ICodedValueDomain;
                    ICodedValueDomain codedDomain = new CodedValueDomainClass();
                    for (int i = 0; i < sourceCodedDomain.CodeCount; i++)
                    {
                        codedDomain.AddCode(sourceCodedDomain.get_Value(i),sourceCodedDomain.get_Name(i));
                    }
                    targetDomain = codedDomain as IDomain;                    
                }
                if (targetDomain == null) return;
                targetDomain.Name = sourceDomain.Name;
                targetDomain.FieldType = sourceDomain.FieldType;
                targetDomain.MergePolicy = sourceDomain.MergePolicy;
                targetDomain.SplitPolicy = sourceDomain.SplitPolicy;
                targetWorkspaceDomains.AddDomain(targetDomain);
                sourceDomain = sourceDomains.Next();
            } 
        }

        //拷贝数据库模式：包括属性域、要素集、要素类（包括要素集中的要素类和独立的要素类）、表
        private void CreateSchema()
        {
            CopyDomains(sourceWorkspace, targetWorkspace);
            IEnumDataset sourceFeatureDatasets = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            CreateFeatureDatasetsAndFeatureClasses(sourceFeatureDatasets);
            IEnumDataset featureClasses = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
            CreateFeatureClassesInWorkspace(featureClasses);
            IEnumDataset tables = sourceWorkspace.get_Datasets(esriDatasetType.esriDTTable);
            CreateTablesInWorkspace(tables);
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {

            txtMessages.Text += "数据库拷贝, 请稍候..." + "\r\n";
            txtMessages.Text += "\r\n创建数据库模式开始...\r\n";
            DateTime startTime = DateTime.Now;
            txtMessages.Text += startTime.ToString() + "\r\n";
            txtMessages.Update();

            CreateSchema();            
            
            txtMessages.Text += "\r\n创建数据库模式完成.\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
            txtMessages.Text += "-------------------------------------------------------\r\n";

            txtMessages.Text += "\r\n开始数据拷贝...\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
            txtMessages.Text += "-------------------------------------------------------\r\n";

            CopyFeatureDatasetAndFeatureClass();

            txtMessages.Text += "\r\n数据拷贝完成...\r\n";
            DateTime endTime = DateTime.Now;
            txtMessages.Text += endTime.ToString() + "\r\n";
            TimeSpan time = endTime - startTime;
            txtMessages.Text += "总用时：" +time.ToString()+" \r\n";
            txtMessages.Text += "-------------------------------------------------------\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();

            //填充目标数据库树视图
            trvTargetGDB.Nodes.Clear();
            string sourceGDBName2 = sourceGDBName + ".gdb";
            string targetGDBFullName = System.IO.Path.Combine(targetGDBDirectory, sourceGDBName2);
            TreeNode rootnode = new TreeNode("目标数据库" + "--" + targetGDBFullName);
            trvTargetGDB.Nodes.Add(rootnode);

            IEnumDataset targetFeatureDatasets = targetWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            TreeViewAddNodes(targetFeatureDatasets, rootnode);
            IEnumDataset targetFeatureClasses = targetWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
            TreeViewAddNodes(targetFeatureClasses, rootnode);
            trvTargetGDB.Sort();
        }                

        
        private void CreateFeatureDatasetsAndFeatureClasses(IEnumDataset sourceFeatureDatasets)
        {
            if (sourceWorkspace == null || targetWorkspace == null) return;   
            ISpatialReference spatialRference;
            sourceFeatureDatasets.Reset();
            IDataset dataset = sourceFeatureDatasets.Next();
            while (dataset != null)
            {
                IGeoDataset geoDataset = dataset as IGeoDataset;
                spatialRference = geoDataset.SpatialReference;
                IFeatureDataset sourceFeatureDataset = dataset as IFeatureDataset;
                IFeatureWorkspace featureWorkspace = targetWorkspace as IFeatureWorkspace;

                if (((IWorkspace2)targetWorkspace).get_NameExists(esriDatasetType.esriDTFeatureDataset, ((IDataset)sourceFeatureDataset).Name))
                    dataset = sourceFeatureDatasets.Next();

                IFeatureDataset targetFeatureDataset = featureWorkspace.CreateFeatureDataset(dataset.Name, spatialRference);
                CreateFeatureClassesInDataset(sourceFeatureDataset, targetFeatureDataset);
                dataset = sourceFeatureDatasets.Next();
            }
        }

        //创建要素集中的要素类：要素类、拓扑关系
        #region "CreateFeatureClassesInDataset"
        public void CreateFeatureClassesInDataset(IFeatureDataset sourceFeatureDataset, IFeatureDataset targetFeatureDataset)
        {
            if (sourceFeatureDataset == null || targetFeatureDataset == null) return;

            IEnumDataset datasets = sourceFeatureDataset.Subsets;

            IDataset sourceDataset = datasets.Next();
            while (sourceDataset != null)
            {                
                switch (sourceDataset.Type)
                {
                    case esriDatasetType.esriDTFeatureClass:
                        if (((IWorkspace2)targetWorkspace).get_NameExists(esriDatasetType.esriDTFeatureClass, sourceDataset.Name))
                            break;
                        IFeatureClass sourceFeatureClass = sourceDataset as IFeatureClass;
                        CreateFeatureClassInThisDataset(sourceFeatureClass, targetFeatureDataset);
                        break;

                    case esriDatasetType.esriDTGeometricNetwork:

                        break;
                    case esriDatasetType.esriDTNetworkDataset:
                        INetworkDataset sourceNetworkDataset = sourceDataset as INetworkDataset;

                        break;
                    case esriDatasetType.esriDTRelationshipClass:
                        CreateRelationshipClassSchema(sourceFeatureDataset, targetFeatureDataset);
                        break;
                    case esriDatasetType.esriDTTopology:
                        CreateTopology(sourceFeatureDataset, targetFeatureDataset);
                        break;
                    default:
                        break;
                }                     
                sourceDataset = datasets.Next();
            }
        }
        #endregion

        private void CreateFeatureClassInThisDataset(IFeatureClass sourceFeatureClass, IFeatureDataset targetFeatureDataset)
        {
            IFields fields = sourceFeatureClass.Fields;
            if (fields == null) return;

            IFieldsEdit fieldsEdit = (IFieldsEdit)fields;
            IField fieldUserDefined = new Field();
            IFieldEdit fieldEdit = (IFieldEdit)fieldUserDefined;
            IGeometryDef geometryDef = new GeometryDefClass();
            IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
            geometryDefEdit.GeometryType_2 = sourceFeatureClass.ShapeType;

            // By setting the grid size to 0, you're allowing ArcGIS to determine the appropriate grid sizes for the feature class. 
            // If in a personal geodatabase, the grid size will be 1000. If in a file or ArcSDE geodatabase, the grid size
            // will be based on the initial loading or inserting of features.
            geometryDefEdit.GridCount_2 = 1;
            geometryDefEdit.set_GridSize(0, 0);
            geometryDefEdit.HasM_2 = bHasM;
            geometryDefEdit.HasZ_2 = bHasZ;

            // Set standard field properties.
            fieldEdit.Name_2 = "SHAPE";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geometryDef;
            fieldEdit.IsNullable_2 = true;
            fieldEdit.Required_2 = true;
            fieldsEdit.set_Field(fields.FindField("SHAPE"), fieldUserDefined);

            UID CLSID = new UIDClass();
            CLSID.Value = "esriGeoDatabase.Feature";
            string featureClassName = ((IDataset)sourceFeatureClass).Name;
            //创建目标要素类
            IFeatureClass targetClass = targetFeatureDataset.CreateFeatureClass(featureClassName, fields, CLSID, null, esriFeatureType.esriFTSimple, "Shape", "");
            //设置要素类子类型
            SetSubtypes(sourceFeatureClass, targetClass);

            IClassSchemaEdit targetFeatureClassSchema = targetClass as IClassSchemaEdit;
            targetFeatureClassSchema.AlterAliasName(sourceFeatureClass.AliasName);

        }

        private void CreateRelationshipClassSchema(IFeatureDataset sourceFeatureDataset, IFeatureDataset targetFeatureDataset)
        {
            IRelationshipClassContainer fromRelClassContainer = sourceFeatureDataset as IRelationshipClassContainer;
            IEnumRelationshipClass fromRelClasses = fromRelClassContainer.RelationshipClasses;
            fromRelClasses.Reset();
            IRelationshipClass fromRelClass = fromRelClasses.Next();
            while (fromRelClass != null)
            {

            }
        }

        //拷贝拓扑关系
        private void CreateTopology(IFeatureDataset sourceFeatureDataset, IFeatureDataset targetFeatureDataset)
        {
            IFeatureWorkspace targetFeatureWorkspace = targetWorkspace as IFeatureWorkspace;
            ITopologyContainer toTopoContainer = (ITopologyContainer)targetFeatureDataset;
            ITopologyContainer fromTopoContainer = (ITopologyContainer)sourceFeatureDataset;
            int topoCount = fromTopoContainer.TopologyCount;
            ITopology fromTopology;
            ITopology toTopology;
            for (int i = 0; i < topoCount; i++)
            {
                fromTopology = fromTopoContainer.get_Topology(i);
                string topologyName = (fromTopology as IDataset).Name;
                if (((IWorkspace2)targetWorkspace).get_NameExists(esriDatasetType.esriDTTopology, topologyName))
                    continue;
                ITopologyProperties fromTopoProps = fromTopology as ITopologyProperties;
                IEnumFeatureClass fromTopoClasses = fromTopoProps.Classes;
                ITopologyRuleContainer fromTopoRuleContainer = fromTopology as ITopologyRuleContainer;
                IEnumRule fromRules = fromTopoRuleContainer.Rules;

                toTopology = toTopoContainer.CreateTopology(topologyName, toTopoContainer.DefaultClusterTolerance, -1, "");

                IFeatureClass fromFeatureClass = fromTopoClasses.Next();
                while (fromFeatureClass != null)
                {
                    ITopologyClass fromTopoClass = fromFeatureClass as ITopologyClass;
                    IFeatureClass toFeatureClass = targetFeatureWorkspace.OpenFeatureClass(((IDataset)fromFeatureClass).Name);
                    toTopology.AddClass(toFeatureClass, fromTopoClass.Weight, fromTopoClass.XYRank, fromTopoClass.ZRank, false);
                    fromFeatureClass = fromTopoClasses.Next();
                }

                IRule fromRule = fromRules.Next();
                ITopologyRuleContainer toTopoRuleContainer = toTopology as ITopologyRuleContainer;
                while (fromRule != null)
                {
                    ITopologyRule fromTopoRule = fromRule as ITopologyRule;
                    ITopologyRule topologyRule = new TopologyRuleClass();
                    topologyRule.AllDestinationSubtypes = fromTopoRule.AllDestinationSubtypes;
                    topologyRule.AllOriginSubtypes = fromTopoRule.AllOriginSubtypes;
                    topologyRule.DestinationClassID = fromTopoRule.DestinationClassID;
                    topologyRule.DestinationSubtype = fromTopoRule.DestinationSubtype;
                    topologyRule.Name = fromTopoRule.Name;
                    topologyRule.OriginClassID = fromTopoRule.OriginClassID;
                    topologyRule.OriginSubtype = fromTopoRule.OriginSubtype;
                    topologyRule.TopologyRuleType = fromTopoRule.TopologyRuleType;

                    if (toTopoRuleContainer.get_CanAddRule(topologyRule))
                    {
                        toTopoRuleContainer.AddRule(topologyRule);
                    }
                    fromRule = fromRules.Next();
                }
            }
        }
        
        //拷贝独立要素类的模式
        private void CreateFeatureClassesInWorkspace(IEnumDataset datasets)
        {
            IDataset dataset = datasets.Next();
            while (dataset != null)
            {
                IFeatureClass sourceClass = dataset as IFeatureClass;
                if (((IWorkspace2)targetWorkspace).get_NameExists(esriDatasetType.esriDTFeatureClass, ((IDataset)sourceClass).Name))
                    dataset = datasets.Next();
                else
                {
                    IFields fields = sourceClass.Fields;
                    if (fields == null) return;

                    IFieldsEdit fieldsEdit = (IFieldsEdit)fields;
                    IField fieldUserDefined = new Field();
                    IFieldEdit fieldEdit = (IFieldEdit)fieldUserDefined;
                    IGeometryDef geometryDef = new GeometryDefClass();
                    IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
                    geometryDefEdit.GeometryType_2 = sourceClass.ShapeType;
                    geometryDefEdit.SpatialReference_2 = ((IGeoDataset)dataset).SpatialReference;

                    // By setting the grid size to 0, you're allowing ArcGIS to determine the appropriate grid sizes for the feature class. 
                    // If in a personal geodatabase, the grid size will be 1000. If in a file or ArcSDE geodatabase, the grid size
                    // will be based on the initial loading or inserting of features.
                    geometryDefEdit.GridCount_2 = 1;
                    geometryDefEdit.set_GridSize(0, 0);
                    geometryDefEdit.HasM_2 = bHasM;
                    geometryDefEdit.HasZ_2 = bHasZ;

                    // Set standard field properties.
                    fieldEdit.Name_2 = "SHAPE";
                    fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                    fieldEdit.GeometryDef_2 = geometryDef;
                    fieldEdit.IsNullable_2 = true;
                    fieldEdit.Required_2 = true;
                    fieldsEdit.set_Field(fields.FindField("SHAPE"), fieldUserDefined);

                    UID CLSID = new UIDClass();
                    CLSID.Value = "esriGeoDatabase.Feature";
                    string featureClassName = ((IDataset)sourceClass).Name;
                    IFeatureWorkspace featureWorkspace = targetWorkspace as IFeatureWorkspace;
                    IFeatureClass targetClass = featureWorkspace.CreateFeatureClass(featureClassName, fields, CLSID, null, esriFeatureType.esriFTSimple, "SHAPE", "");
                    //设置要素类子类型
                    SetSubtypes(sourceClass, targetClass);
                    IClassSchemaEdit targetFeatureClassSchema = targetClass as IClassSchemaEdit;
                    targetFeatureClassSchema.AlterAliasName(sourceClass.AliasName);
                }
                dataset = datasets.Next();
            }
        }

        //拷贝表模式
        private void CreateTablesInWorkspace(IEnumDataset tables)
        {
            IDataset dataset = tables.Next();
            while (dataset != null)
            {
                ITable sourceTable = dataset as ITable;
                if (((IWorkspace2)targetWorkspace).get_NameExists(esriDatasetType.esriDTTable, ((IDataset)sourceTable).Name))
                    dataset = tables.Next();
                else
                {
                    IFields fields = sourceTable.Fields;
                    if (fields == null) return;                   

                    UID CLSID = new UIDClass();
                    CLSID.Value = "esriGeoDatabase.Object";
                    string featureClassName = ((IDataset)sourceTable).Name;
                    IFeatureWorkspace featureWorkspace = targetWorkspace as IFeatureWorkspace;
                    ITable targetTable = featureWorkspace.CreateTable(featureClassName, fields, CLSID, null, "");                     
                }
                dataset = tables.Next();
            }           
        }

        //拷贝要素类的子类型定义
        private void SetSubtypes(IFeatureClass fromFeatureClass, IFeatureClass toFeatureClass)
        {
            IWorkspaceDomains targetWorkspaceDomains = (IWorkspaceDomains)targetWorkspace;

            ISubtypes toSubtypes = (ISubtypes)toFeatureClass;
            ISubtypes fromSubtypes = (ISubtypes)fromFeatureClass;
            IEnumSubtype fromEnumSubtype;

            string subtypeFieldName;
            int subtypeCode;
            string subtypeName;
            IDomain fromDomain;

            if (fromSubtypes.HasSubtype)
            {
                fromEnumSubtype = fromSubtypes.Subtypes;
                subtypeFieldName = fromSubtypes.SubtypeFieldName;
                toSubtypes.SubtypeFieldName = subtypeFieldName;
                subtypeName = fromEnumSubtype.Next(out subtypeCode);
                while (subtypeName != null)
                {
                    fromDomain = fromSubtypes.get_Domain(subtypeCode, subtypeName);
                    toSubtypes.AddSubtype(subtypeCode, subtypeName);
                    if (fromDomain != null)
                        toSubtypes.set_Domain(subtypeCode, subtypeFieldName, targetWorkspaceDomains.get_DomainByName(fromDomain.Name));
                    subtypeName = fromEnumSubtype.Next(out subtypeCode);
                }
            }
        }

        //拷贝数据
        private void CopyFeatureDatasetAndFeatureClass()
        {
            CopyFeatureDatasets();
            CopyAloneFeatureClasses();
            CopyTablesInWorkspace();
        }

        private void CopyFeatureDatasets()
        {
            if (sourceWorkspace == null || targetWorkspace == null) return;
            IFeatureWorkspace targetFeatureWorkspace = targetWorkspace as IFeatureWorkspace;
            IFeatureWorkspace sourceFeatureWorkspace = sourceWorkspace as IFeatureWorkspace;

            IEnumDataset sourceFeatureDatasets = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            sourceFeatureDatasets.Reset();
            IDataset dataset = sourceFeatureDatasets.Next();
            while (dataset != null)
            {
                IWorkspace workspace = dataset.Workspace;
                IWorkspaceEdit workspaceEdit = (IWorkspaceEdit)workspace;
                workspaceEdit.StartEditing(true);
                workspaceEdit.StartEditOperation();

                IFeatureDataset sourceFeatureDataset = sourceFeatureWorkspace.OpenFeatureDataset(dataset.Name);
                IEnumDataset sourceFeatureClasses = sourceFeatureDataset.Subsets;
                sourceFeatureClasses.Reset();
                IDataset sourceDataset = sourceFeatureClasses.Next();
                while (sourceDataset != null)
                {
                    switch (sourceDataset.Type)
                    {
                        case esriDatasetType.esriDTFeatureClass:
                            IFeatureClass sourceFeatureClass = sourceDataset as IFeatureClass;
                            IFeatureClass targetFeatureClass = targetFeatureWorkspace.OpenFeatureClass(sourceDataset.Name);
                            CopyFeatureClass(sourceFeatureClass, targetFeatureClass);
                            break;
                        case esriDatasetType.esriDTGeometricNetwork:

                            break;
                        case esriDatasetType.esriDTNetworkDataset:

                            break;
                        case esriDatasetType.esriDTRelationshipClass:

                            break;
                        case esriDatasetType.esriDTTopology:
                            //在模式拷贝部分已实现
                            break;
                        default:
                            break;
                    }
                    sourceDataset = sourceFeatureClasses.Next();
                }

                workspaceEdit.StopEditOperation();
                workspaceEdit.StopEditing(true);

                dataset = sourceFeatureDatasets.Next();
            }
        }

        private void CopyAloneFeatureClasses()
        {
            if (sourceWorkspace == null || targetWorkspace == null) return;
            IFeatureWorkspace targetFeatureWorkspace = targetWorkspace as IFeatureWorkspace;
            IFeatureWorkspace sourceFeatureWorkspace = sourceWorkspace as IFeatureWorkspace;

            IEnumDataset sourceFeatureClasses = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
            sourceFeatureClasses.Reset();
            IDataset dataset = sourceFeatureClasses.Next();
            while (dataset != null)
            {
                IWorkspace workspace = dataset.Workspace;
                IWorkspaceEdit workspaceEdit = (IWorkspaceEdit)workspace;
                workspaceEdit.StartEditing(true);
                workspaceEdit.StartEditOperation();

                IFeatureClass sourceFeatureClass = dataset as IFeatureClass;
                IFeatureClass targetFeatureClass = targetFeatureWorkspace.OpenFeatureClass(dataset.Name);
                CopyFeatureClass(sourceFeatureClass, targetFeatureClass);
                dataset = sourceFeatureClasses.Next();

                workspaceEdit.StopEditOperation();
                workspaceEdit.StopEditing(true);
            }
        }

        private void CopyTablesInWorkspace()
        {
            if (sourceWorkspace == null || targetWorkspace == null) return;
            IFeatureWorkspace targetFeatureWorkspace = targetWorkspace as IFeatureWorkspace;
            IFeatureWorkspace sourceFeatureWorkspace = sourceWorkspace as IFeatureWorkspace;

            IEnumDataset sourceTables = sourceWorkspace.get_Datasets(esriDatasetType.esriDTTable);
            sourceTables.Reset();
            IDataset dataset = sourceTables.Next();
            while (dataset != null)
            {
                IWorkspace workspace = dataset.Workspace;
                IWorkspaceEdit workspaceEdit = (IWorkspaceEdit)workspace;
                workspaceEdit.StartEditing(true);
                workspaceEdit.StartEditOperation();

                ITable sourceTable = dataset as ITable;
                ITable targetTable = targetFeatureWorkspace.OpenTable(dataset.Name);
                CopyTables(sourceTable, targetTable);
                dataset = sourceTables.Next();
                workspaceEdit.StopEditOperation();
                workspaceEdit.StopEditing(true);
            }
        }


        private void CopyFeatureClass(IFeatureClass sourceClass, IFeatureClass targetClass)
        {
            IFeatureBuffer targetFeatureBuffer = targetClass.CreateFeatureBuffer();
            IFeatureCursor targetFeatureCursor = targetClass.Insert(true);

            txtMessages.Text += "要素类" + ((IDataset)sourceClass).Name + "拷贝开始..." + "\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();

            IFields sourceFields  = sourceClass.Fields;
            IFields targetFields = targetClass.Fields;

            IFeatureCursor sourceFeatureCursor = sourceClass.Search(null, false);
            IFeature sourceFeature = sourceFeatureCursor.NextFeature();
            int j = 0;
            while (sourceFeature != null)
            {
                IGeometry geometry = sourceFeature.ShapeCopy;
                if (geometry == null) goto nextFeature;
                if (geometry is ITopologicalOperator2)
                {
                    ITopologicalOperator2 topo = geometry as ITopologicalOperator2;
                    topo.IsKnownSimple_2 = false;
                    topo.Simplify();
                }
                IZAware za = geometry as IZAware;
                za.ZAware = bHasZ;
                IMAware ma = geometry as IMAware;
                ma.MAware = bHasM;
                targetFeatureBuffer.Shape = geometry;

                try
                {
                    for (int i = 0; i < targetFields.FieldCount; i++)
                    {
                        IField field = new FieldClass();
                        field = targetFields.get_Field(i);
                        if (field.Type == esriFieldType.esriFieldTypeOID)
                            continue;
                        if (field.Type == esriFieldType.esriFieldTypeGeometry)
                            continue;
                        if (field.Name == "Shape_Length")
                            continue;
                        if (field.Name == "Shape_Area")
                            continue;

                        int fieldIdx = sourceFields.FindField(field.Name);
                        object fieldValue = sourceFeature.get_Value(fieldIdx);
                        targetFeatureBuffer.set_Value(i, fieldValue);
                    }
                    targetFeatureCursor.InsertFeature(targetFeatureBuffer);
                    sourceFeature = null;
                    j++;
                }
                catch (Exception e)
                {
                    txtMessages.Text += "要素类：" + ((IDataset)sourceClass).Name + "  拷贝有问题" + "\r\n";
                    txtMessages.Text += e.Message + "\r\n";
                    txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
                    ScrollToBottom(txtMessages);
                    txtMessages.Update();
                }
            nextFeature: sourceFeature = sourceFeatureCursor.NextFeature();
            }
            targetFeatureCursor.Flush();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(targetFeatureCursor);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sourceFeatureCursor);

            txtMessages.Text += "要素类 " + ((IDataset)sourceClass).Name + " 拷贝结束" + "\r\n";
            txtMessages.Text += "总要素个数: " + sourceClass.FeatureCount(null).ToString() + "\r\n";
            txtMessages.Text += "拷贝要素个数: " + j.ToString() + "\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n\r\n\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
        }


        private void CopyTables(ITable sourceTable, ITable targetTable)
        {
            IRowBuffer targetRowBuffer = targetTable.CreateRowBuffer();
            ICursor targetRowCursor = targetTable.Insert(true);

            txtMessages.Text += "要素类" + ((IDataset)sourceTable).Name + "拷贝开始..." + "\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();

            IFields sourceFields = new FieldsClass();
            sourceFields = sourceTable.Fields;
            IFields targetFields = new FieldsClass();
            targetFields = targetTable.Fields;

            ICursor sourceRowCursor = sourceTable.Search(null, false);
            IRow sourceRow = sourceRowCursor.NextRow();
            int j = 0;
            while (sourceRow != null)
            {
                for (int i = 0; i < targetFields.FieldCount; i++)
                {
                    IField field = new FieldClass();
                    field = targetFields.get_Field(i);
                    if (field.Type == esriFieldType.esriFieldTypeOID)
                        continue;
                    int fieldIdx = sourceFields.FindField(field.Name);
                    object fieldValue = sourceRow.get_Value(fieldIdx);
                    targetRowBuffer.set_Value(i, fieldValue);
                }

                try
                {
                    targetRowCursor.InsertRow(targetRowBuffer);
                    sourceRow = null;
                    j++;
                }
                catch (Exception e)
                {
                    txtMessages.Text += "表：" + ((IDataset)sourceTable).Name + "  拷贝有问题" + "\r\n";
                    txtMessages.Text += e.Message + "\r\n";
                    txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
                    ScrollToBottom(txtMessages);
                    txtMessages.Update();
                }
                sourceRow = sourceRowCursor.NextRow();
            }
            targetRowCursor.Flush();

            txtMessages.Text += "表 " + ((IDataset)sourceTable).Name + " 拷贝结束" + "\r\n";
            txtMessages.Text += "总对象个数: " + sourceTable.RowCount(null).ToString() + "\r\n";
            txtMessages.Text += "拷贝对象个数: " + j.ToString() + "\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n\r\n\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
        }
        

        private void CopyFeatureClass2(IFeatureClass sourceClass, IFeatureClass targetClass)
        {
            txtMessages.Text += "要素类" + ((IDataset)sourceClass).Name + "拷贝开始..." + "\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();

            IFeatureCursor sourceFeatureCursor = sourceClass.Search(null, false);
            IFeature sourceFeature = sourceFeatureCursor.NextFeature();

            int j = 0;
            while (sourceFeature != null)
            {
                IFields sourceFields = new FieldsClass();
                sourceFields = sourceFeature.Fields;
                IFeature targetFeature = targetClass.CreateFeature();
                IFields targetFields = new FieldsClass();
                targetFields = targetFeature.Fields;

                IGeometry geometry = sourceFeature.ShapeCopy;
                if (geometry == null) goto nextFeature;
                if (geometry is ITopologicalOperator2)
                {
                    ITopologicalOperator2 topo = geometry as ITopologicalOperator2;
                    topo.IsKnownSimple_2 = false;
                    topo.Simplify();
                }
                IZAware za = geometry as IZAware;
                za.ZAware = bHasZ;
                IMAware ma = geometry as IMAware;
                ma.MAware = bHasM;
                targetFeature.Shape = geometry;

                ISubtypes subtypes = (ISubtypes)targetClass;
                IRowSubtypes rowSubtypes = (IRowSubtypes)targetFeature;
                rowSubtypes.InitDefaultValues();

                for (int i = 0; i < targetFields.FieldCount; i++)
                {
                    IField field = new FieldClass();
                    field = targetFields.get_Field(i);
                    if (field.Type == esriFieldType.esriFieldTypeOID)
                        continue;
                    if (field.Type == esriFieldType.esriFieldTypeGeometry)
                        continue;
                    if (field.Name == "Shape_Length")
                        continue;
                    if (field.Name == "Shape_Area")
                        continue;

                    int fieldIdx = sourceFields.FindField(field.Name);
                    object fieldValue = sourceFeature.get_Value(fieldIdx);
                    targetFeature.set_Value(i, fieldValue);
                }
                try
                {
                    targetFeature.Store();
                    j++;
                }
                catch (Exception e)
                {
                    txtMessages.Text += "要素类 " + ((IDataset)sourceClass).Name + "  拷贝有问题" + "\r\n";
                    txtMessages.Text += e.Message + "\r\n";
                    txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
                    ScrollToBottom(txtMessages);
                    txtMessages.Update();
                }
            nextFeature: sourceFeature = sourceFeatureCursor.NextFeature();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(sourceFeatureCursor);

            txtMessages.Text += "要素类 " + ((IDataset)sourceClass).Name + " 拷贝结束" + "\r\n";
            txtMessages.Text += "总要素个数: " + sourceClass.FeatureCount(null).ToString() + "\r\n";
            txtMessages.Text += "拷贝要素个数: " + j.ToString() + "\r\n";
            txtMessages.Text += DateAndTime.Now.ToString() + "\r\n\r\n\r\n";
            ScrollToBottom(txtMessages);
            txtMessages.Update();
        }


        private IEnumGxObject AddDatasetWithGxDialog()
        {
            try
            {
                IGxDialog gxDlg = new GxDialogClass();
                IGxObjectFilter gxObjFilter = new GxFilterFileGeodatabasesClass();
                IGxObjectFilterCollection filters = gxDlg as IGxObjectFilterCollection;
                filters.AddFilter(gxObjFilter, true);
                gxObjFilter = new GxFilterPersonalGeodatabasesClass();
                filters.AddFilter(gxObjFilter, false);
                //gxDlg.Title = "Open A Geodatabase";
                ////gxDlg.ObjectFilter = gxObjFilter;
                //gxDlg.AllowMultiSelect = false;
                //gxDlg.RememberLocation = true;


                IEnumGxObject gxObjects;
                bool open = gxDlg.DoModalOpen(0, out gxObjects);


                return gxObjects;
            }
            catch (Exception e)
            {
                txtMessages.Text += "打开数据库出错！ \r\n";
                txtMessages.Text += e.Message + "\r\n";
                txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
                ScrollToBottom(txtMessages);
                txtMessages.Update();
            }
            return null;
        }


        private void TreeViewAddNodes(IEnumDataset datasets, TreeNode currentNode)
        {
            if (datasets == null)
                return;

            datasets.Reset();

            IDataset dataset = datasets.Next() as IDataset;
            while (dataset != null)
            {
                if (dataset is IFeatureClass)
                {
                    TreeNode datasetNode = new TreeNode(dataset.Name);
                    currentNode.Nodes.Add(datasetNode);
                }
                else if (dataset is IFeatureDataset)
                {
                    TreeNode datasetName = new TreeNode(dataset.Name);

                    IFeatureDataset featureDataset = dataset as IFeatureDataset;
                    IEnumDataset pEnumDataset = featureDataset.Subsets;
                    pEnumDataset.Reset();
                    IDataset pDataSet = pEnumDataset.Next();
                    while (pDataSet != null)
                    {
                        if ((pDataSet is ITopology) || (pDataSet is IGeometricNetwork) || (pDataSet is INetworkDataset))
                        {
                            pDataSet = pEnumDataset.Next();
                        }
                        else
                        {
                            TreeNode featureClassName = new TreeNode(pDataSet.Name);
                            datasetName.Nodes.Add(featureClassName);
                            pDataSet = pEnumDataset.Next();
                        }
                    }
                    currentNode.Nodes.Add(datasetName);
                }
                dataset = datasets.Next() as IDataset;
            }
        }

        private void CopyFeatureDatasetByGeoTransfer()
        {
            if (sourceWorkspace == null || targetWorkspace == null) return;
            IEnumDataset sourceFeatureDatasets = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            sourceFeatureDatasets.Reset();
            IDataset dataset = sourceFeatureDatasets.Next();
            while (dataset != null)
            {
                IGeoDataset geoDataset = dataset as IGeoDataset;
                IFeatureDataset sourceFeatureDataset = dataset as IFeatureDataset;
                CopyDataByGeoTransfer(sourceWorkspace, targetWorkspace, sourceFeatureDataset.Name, esriDatasetType.esriDTFeatureDataset);

                dataset = sourceFeatureDatasets.Next();
            }
        }


        public void CopyDataByGeoTransfer(IWorkspace sourceWorkspace, IWorkspace targetWorkspace, String objectName, esriDatasetType esriDataType)
        {
            if ((sourceWorkspace.Type == esriWorkspaceType.esriFileSystemWorkspace) || (targetWorkspace.Type == esriWorkspaceType.esriFileSystemWorkspace))
            {
                return;
            }
            IDataset sourceWorkspaceDataset = (IDataset)sourceWorkspace;
            IWorkspaceName sourceWorkspaceName = (IWorkspaceName)sourceWorkspaceDataset.FullName;

            //create target workspace name
            IDataset targetWorkspaceDataset = (IDataset)targetWorkspace;
            IWorkspaceName targetWorkspaceName = (IWorkspaceName)targetWorkspaceDataset.FullName;

            //Create Name Object Based on data type
            IDatasetName datasetName;
            switch (esriDataType)
            {
                case esriDatasetType.esriDTFeatureDataset:
                    IFeatureDatasetName inFeatureDatasetName = new FeatureDatasetNameClass();
                    datasetName = (IDatasetName)inFeatureDatasetName;
                    break;
                case esriDatasetType.esriDTFeatureClass:
                    IFeatureClassName inFeatureClassName = new FeatureClassNameClass();
                    datasetName = (IDatasetName)inFeatureClassName;
                    break;
                case esriDatasetType.esriDTTable:
                    ITableName inTableName = new TableNameClass();
                    datasetName = (IDatasetName)inTableName;
                    break;
                case esriDatasetType.esriDTGeometricNetwork:
                    IGeometricNetworkName inGeometricNetworkName = new GeometricNetworkNameClass();
                    datasetName = (IDatasetName)inGeometricNetworkName;
                    break;
                case esriDatasetType.esriDTRelationshipClass:
                    IRelationshipClassName inRelationshipClassName = new RelationshipClassNameClass();
                    datasetName = (IDatasetName)inRelationshipClassName;
                    break;
                case esriDatasetType.esriDTNetworkDataset:
                    INetworkDatasetName inNetworkDatasetName = new NetworkDatasetNameClass();
                    datasetName = (IDatasetName)inNetworkDatasetName;
                    break;
                case esriDatasetType.esriDTTopology:
                    ITopologyName inTopologyName = new TopologyNameClass();
                    datasetName = (IDatasetName)inTopologyName;
                    break;
                default:
                    return;
            }

            // Set the name of the object to be copied
            datasetName.WorkspaceName = (IWorkspaceName)sourceWorkspaceName;
            datasetName.Name = objectName;

            //Setup mapping for copy/paste
            IEnumNameMapping fromNameMapping;
            ESRI.ArcGIS.esriSystem.IEnumNameEdit editFromName;
            ESRI.ArcGIS.esriSystem.IEnumName fromName = new NamesEnumerator();
            editFromName = (ESRI.ArcGIS.esriSystem.IEnumNameEdit)fromName;
            editFromName.Add((ESRI.ArcGIS.esriSystem.IName)datasetName);
            ESRI.ArcGIS.esriSystem.IName toName = (ESRI.ArcGIS.esriSystem.IName)targetWorkspaceName;

            // Generate name mapping
            ESRI.ArcGIS.Geodatabase.IGeoDBDataTransfer geoDBDataTransfer = new GeoDBDataTransferClass();
            IEnumNameMapping enumChildMapping;
            INameMapping childMapping;
            // If there are name mapping conflicts, supply suggested names.
            if (geoDBDataTransfer.GenerateNameMapping(fromName, toName, out fromNameMapping))
            {

                fromNameMapping.Reset();
                ESRI.ArcGIS.Geodatabase.INameMapping nameMapping = fromNameMapping.Next();
                while (nameMapping != null)
                {
                    if (nameMapping.NameConflicts)
                    {
                        nameMapping.TargetName = nameMapping.GetSuggestedName(toName);
                    }
                    if (nameMapping.Children != null)
                    {
                        enumChildMapping = nameMapping.Children;
                        enumChildMapping.Reset();
                        childMapping = enumChildMapping.Next();
                        while (childMapping != null)
                        {
                            if (childMapping.NameConflicts)
                            {
                                childMapping.TargetName = childMapping.GetSuggestedName(toName);
                            }
                            childMapping = enumChildMapping.Next();
                        }
                    }
                    nameMapping = fromNameMapping.Next();
                }
            }
            // Copy and paste the data.
            geoDBDataTransfer.Transfer(fromNameMapping, toName);

        }

        private void GDB2GDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            sourceWorkspace = null;
            targetWorkspace = null;
        }


        private void btnClearSourceDatabase_Click(object sender, EventArgs e)
        {
            ClearFeatureDatasetAndFeatureClass();
        }


        private void ClearFeatureDatasetAndFeatureClass()
        {
            ClearFeatureDatasets();
            ClearAloneFeatureClasses();
        }

        private void ClearFeatureDatasets()
        {
            if (sourceWorkspace == null) return;
            IFeatureWorkspace sourceFeatureWorkspace = sourceWorkspace as IFeatureWorkspace;

            IEnumDataset sourceFeatureDatasets = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);
            sourceFeatureDatasets.Reset();
            IDataset dataset = sourceFeatureDatasets.Next();
            while (dataset != null)
            {
                if (dataset is IFeatureDataset)
                {
                    IFeatureDataset sourceFeatureDataset = sourceFeatureWorkspace.OpenFeatureDataset(dataset.Name);
                    IEnumDataset sourceFeatureClasses = sourceFeatureDataset.Subsets;
                    sourceFeatureClasses.Reset();
                    IDataset sourceDataset = sourceFeatureClasses.Next();
                    while (sourceDataset != null)
                    {
                        if (sourceDataset is IFeatureClass)
                        {
                            IFeatureClass sourceClass = sourceDataset as IFeatureClass;
                            ClearFeatureClass(sourceClass);
                        }
                        sourceDataset = sourceFeatureClasses.Next();
                    }
                }
                dataset = sourceFeatureDatasets.Next();
            }
        }

        private void ClearAloneFeatureClasses()
        {
            if (sourceWorkspace == null) return;
            IFeatureWorkspace sourceFeatureWorkspace = sourceWorkspace as IFeatureWorkspace;

            IEnumDataset sourceFeatureClasses = sourceWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
            sourceFeatureClasses.Reset();
            IDataset dataset = sourceFeatureClasses.Next();
            while (dataset != null)
            {
                IFeatureClass sourceClass = dataset as IFeatureClass;
                ClearFeatureClass(sourceClass);
                dataset = sourceFeatureClasses.Next();
            }
        }

        private void ClearFeatureClass(IFeatureClass sourceClass)
        {
            try
            {
                IFeatureCursor sourceFeatureCursor = sourceClass.Search(null, false);
                IFeature sourceFeature = sourceFeatureCursor.NextFeature();
                while (sourceFeature != null)
                {
                    sourceFeature.Delete();
                    sourceFeature = sourceFeatureCursor.NextFeature();
                }
                txtMessages.Text += "要素类：" + ((IDataset)sourceClass).Name + " 清空完毕！" + "\r\n\r\n";
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sourceFeatureCursor);

            }
            catch (Exception e)
            {
                txtMessages.Text += "要素类：" + ((IDataset)sourceClass).Name + "  删除有问题" + "\r\n";
                txtMessages.Text += e.Message + "\r\n";
                txtMessages.Text += DateAndTime.Now.ToString() + "\r\n";
                ScrollToBottom(txtMessages);
                txtMessages.Update();
            }
        }
        
        private void ScrollToBottom(TextBox txtBox)
        {
            txtBox.SelectionStart = txtBox.Text.Length;
            txtBox.SelectionLength = 0;
            txtBox.ScrollToCaret();
        }

        private void chkHasZ_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasZ.Checked)
                bHasZ = true;
            else
                bHasZ = false;
        }

        private void chkHasM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasM.Checked)
                bHasM = true;
            else
                bHasM = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearInfo_Click(object sender, EventArgs e)
        {
            txtMessages.Clear();
        }

        private void btnExportInfo_Click(object sender, EventArgs e)
        {
            string infoFile = "info.txt";
            saveFileDialog1.Filter = "操作信息文件(*.txt)|*.txt";
            saveFileDialog1.FileName = infoFile;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string infoFilepath = saveFileDialog1.FileName;
                System.IO.StreamWriter sw = File.CreateText(infoFilepath);
                sw.Write(txtMessages.Text);
                sw.Close();
                
                MessageBox.Show("数据导出完毕！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GDB2GDB_Load(object sender, EventArgs e)
        {

        }        
        
    }
}