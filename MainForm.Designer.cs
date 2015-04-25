namespace SpatialDataManagement
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.basicToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkCustomize = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataView = new System.Windows.Forms.TabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.LayoutView = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuAddData = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.workspace及相关对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDatabaseWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatingAFileGeodatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.creatingAPersonalGeodatabaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.connectingAFilepersonalGeodatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remotaDatabaseWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geoDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterSpatialReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featureDataset对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNetworkDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDataSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表对象类和要素类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建表ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.创建对象类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建要素类ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.创建当前图层要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.拷贝数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOWObject和Feature对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关系与关系类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看关系类属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.basicToolbarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.dataView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.LayoutView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // basicToolbarControl
            // 
            this.basicToolbarControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.basicToolbarControl.Location = new System.Drawing.Point(0, 25);
            this.basicToolbarControl.Name = "basicToolbarControl";
            this.basicToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("basicToolbarControl.OcxState")));
            this.basicToolbarControl.Size = new System.Drawing.Size(855, 28);
            this.basicToolbarControl.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(3, 3);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(274, 460);
            this.axTOCControl1.TabIndex = 4;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(291, 167);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 488);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(3, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(852, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(57, 17);
            this.statusBarXY.Text = "Test 123";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkCustomize
            // 
            this.chkCustomize.AutoSize = true;
            this.chkCustomize.Location = new System.Drawing.Point(681, 28);
            this.chkCustomize.Name = "chkCustomize";
            this.chkCustomize.Size = new System.Drawing.Size(102, 16);
            this.chkCustomize.TabIndex = 10;
            this.chkCustomize.Text = "定制工具条...";
            this.chkCustomize.UseVisualStyleBackColor = false;
            this.chkCustomize.CheckedChanged += new System.EventHandler(this.chkCustomize_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.dataView);
            this.tabControl1.Controls.Add(this.LayoutView);
            this.tabControl1.Location = new System.Drawing.Point(283, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(566, 460);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // dataView
            // 
            this.dataView.Controls.Add(this.axLicenseControl1);
            this.dataView.Controls.Add(this.axMapControl1);
            this.dataView.Location = new System.Drawing.Point(4, 4);
            this.dataView.Name = "dataView";
            this.dataView.Padding = new System.Windows.Forms.Padding(3);
            this.dataView.Size = new System.Drawing.Size(558, 434);
            this.dataView.TabIndex = 0;
            this.dataView.Text = "数据视图";
            this.dataView.UseVisualStyleBackColor = true;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(552, 428);
            this.axMapControl1.TabIndex = 3;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnViewRefreshed += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnViewRefreshedEventHandler(this.axMapControl1_OnViewRefreshed);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // LayoutView
            // 
            this.LayoutView.Controls.Add(this.axPageLayoutControl1);
            this.LayoutView.Location = new System.Drawing.Point(4, 4);
            this.LayoutView.Name = "LayoutView";
            this.LayoutView.Padding = new System.Windows.Forms.Padding(3);
            this.LayoutView.Size = new System.Drawing.Size(558, 434);
            this.LayoutView.TabIndex = 1;
            this.LayoutView.Text = "布局视图";
            this.LayoutView.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(552, 428);
            this.axPageLayoutControl1.TabIndex = 9;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            this.axPageLayoutControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseMoveEventHandler(this.axPageLayoutControl1_OnMouseMove);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuAddData,
            this.退出ToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(44, 21);
            this.menuFile.Text = "文件";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(157, 22);
            this.menuNewDoc.Text = "新建地图文档";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(157, 22);
            this.menuOpenDoc.Text = "打开地图文档...";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(157, 22);
            this.menuSaveDoc.Text = "保存地图文档";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(157, 22);
            this.menuSaveAs.Text = "另存地图文档...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(154, 6);
            // 
            // menuAddData
            // 
            this.menuAddData.Image = ((System.Drawing.Image)(resources.GetObject("menuAddData.Image")));
            this.menuAddData.Name = "menuAddData";
            this.menuAddData.Size = new System.Drawing.Size(157, 22);
            this.menuAddData.Text = "添加数据";
            this.menuAddData.Click += new System.EventHandler(this.menuAddData_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("退出ToolStripMenuItem.Image")));
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.workspace及相关对象ToolStripMenuItem,
            this.datasetToolStripMenuItem,
            this.表对象类和要素类ToolStripMenuItem,
            this.rOWObject和Feature对象ToolStripMenuItem,
            this.其他ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // workspace及相关对象ToolStripMenuItem
            // 
            this.workspace及相关对象ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileSystemWorkspaceToolStripMenuItem,
            this.localDatabaseWorkspaceToolStripMenuItem,
            this.remotaDatabaseWorkspaceToolStripMenuItem});
            this.workspace及相关对象ToolStripMenuItem.Name = "workspace及相关对象ToolStripMenuItem";
            this.workspace及相关对象ToolStripMenuItem.Size = new System.Drawing.Size(146, 21);
            this.workspace及相关对象ToolStripMenuItem.Text = "Workspace及相关对象";
            // 
            // fileSystemWorkspaceToolStripMenuItem
            // 
            this.fileSystemWorkspaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addShapefileToolStripMenuItem});
            this.fileSystemWorkspaceToolStripMenuItem.Name = "fileSystemWorkspaceToolStripMenuItem";
            this.fileSystemWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.fileSystemWorkspaceToolStripMenuItem.Text = "FileSystemWorkspace";
            // 
            // addShapefileToolStripMenuItem
            // 
            this.addShapefileToolStripMenuItem.Name = "addShapefileToolStripMenuItem";
            this.addShapefileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addShapefileToolStripMenuItem.Text = "Add Shapefile ";
            this.addShapefileToolStripMenuItem.Click += new System.EventHandler(this.addShapefileToolStripMenuItem_Click);
            // 
            // localDatabaseWorkspaceToolStripMenuItem
            // 
            this.localDatabaseWorkspaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creatingAFileGeodatabaseToolStripMenuItem1,
            this.creatingAPersonalGeodatabaseToolStripMenuItem1,
            this.connectingAFilepersonalGeodatabaseToolStripMenuItem});
            this.localDatabaseWorkspaceToolStripMenuItem.Name = "localDatabaseWorkspaceToolStripMenuItem";
            this.localDatabaseWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.localDatabaseWorkspaceToolStripMenuItem.Text = "LocalDatabaseWorkspace";
            // 
            // creatingAFileGeodatabaseToolStripMenuItem1
            // 
            this.creatingAFileGeodatabaseToolStripMenuItem1.Name = "creatingAFileGeodatabaseToolStripMenuItem1";
            this.creatingAFileGeodatabaseToolStripMenuItem1.Size = new System.Drawing.Size(310, 22);
            this.creatingAFileGeodatabaseToolStripMenuItem1.Text = "Creating a file geodatabase";
            this.creatingAFileGeodatabaseToolStripMenuItem1.Click += new System.EventHandler(this.creatingAFileGeodatabaseToolStripMenuItem1_Click);
            // 
            // creatingAPersonalGeodatabaseToolStripMenuItem1
            // 
            this.creatingAPersonalGeodatabaseToolStripMenuItem1.Name = "creatingAPersonalGeodatabaseToolStripMenuItem1";
            this.creatingAPersonalGeodatabaseToolStripMenuItem1.Size = new System.Drawing.Size(310, 22);
            this.creatingAPersonalGeodatabaseToolStripMenuItem1.Text = "Creating a personal geodatabase";
            this.creatingAPersonalGeodatabaseToolStripMenuItem1.Click += new System.EventHandler(this.creatingAPersonalGeodatabaseToolStripMenuItem1_Click);
            // 
            // connectingAFilepersonalGeodatabaseToolStripMenuItem
            // 
            this.connectingAFilepersonalGeodatabaseToolStripMenuItem.Name = "connectingAFilepersonalGeodatabaseToolStripMenuItem";
            this.connectingAFilepersonalGeodatabaseToolStripMenuItem.Size = new System.Drawing.Size(310, 22);
            this.connectingAFilepersonalGeodatabaseToolStripMenuItem.Text = "Connecting a file/personal geodatabase";
            this.connectingAFilepersonalGeodatabaseToolStripMenuItem.Click += new System.EventHandler(this.connectingAFilepersonalGeodatabaseToolStripMenuItem_Click);
            // 
            // remotaDatabaseWorkspaceToolStripMenuItem
            // 
            this.remotaDatabaseWorkspaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem,
            this.connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem});
            this.remotaDatabaseWorkspaceToolStripMenuItem.Name = "remotaDatabaseWorkspaceToolStripMenuItem";
            this.remotaDatabaseWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.remotaDatabaseWorkspaceToolStripMenuItem.Text = "RemoteDatabaseWorkspace";
            // 
            // creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem
            // 
            this.creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem.Name = "creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem";
            this.creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem.Size = new System.Drawing.Size(448, 22);
            this.creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem.Text = "Creating a connection file to an enterprise ArcSDE geodatabase";
            this.creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem.Click += new System.EventHandler(this.creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem_Click);
            // 
            // connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem
            // 
            this.connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem.Name = "connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem";
            this.connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem.Size = new System.Drawing.Size(448, 22);
            this.connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem.Text = "Connecting to enterprise ArcSDE geodatabases";
            this.connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem.Click += new System.EventHandler(this.connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem_Click);
            // 
            // datasetToolStripMenuItem
            // 
            this.datasetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geoDatasetToolStripMenuItem,
            this.featureDataset对象ToolStripMenuItem});
            this.datasetToolStripMenuItem.Name = "datasetToolStripMenuItem";
            this.datasetToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.datasetToolStripMenuItem.Text = "Dataset对象";
            // 
            // geoDatasetToolStripMenuItem
            // 
            this.geoDatasetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterSpatialReferenceToolStripMenuItem});
            this.geoDatasetToolStripMenuItem.Name = "geoDatasetToolStripMenuItem";
            this.geoDatasetToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.geoDatasetToolStripMenuItem.Text = "GeoDataset(sample)";
            // 
            // alterSpatialReferenceToolStripMenuItem
            // 
            this.alterSpatialReferenceToolStripMenuItem.Name = "alterSpatialReferenceToolStripMenuItem";
            this.alterSpatialReferenceToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.alterSpatialReferenceToolStripMenuItem.Text = "Alter SpatialReference";
            this.alterSpatialReferenceToolStripMenuItem.Click += new System.EventHandler(this.alterSpatialReferenceToolStripMenuItem_Click);
            // 
            // featureDataset对象ToolStripMenuItem
            // 
            this.featureDataset对象ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openNetworkDatasetToolStripMenuItem,
            this.setDataSourceToolStripMenuItem});
            this.featureDataset对象ToolStripMenuItem.Name = "featureDataset对象ToolStripMenuItem";
            this.featureDataset对象ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.featureDataset对象ToolStripMenuItem.Text = "FeatureDataset对象";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.createToolStripMenuItem.Text = "Create FeatureClass";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // openNetworkDatasetToolStripMenuItem
            // 
            this.openNetworkDatasetToolStripMenuItem.Name = "openNetworkDatasetToolStripMenuItem";
            this.openNetworkDatasetToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.openNetworkDatasetToolStripMenuItem.Text = "Open Network Dataset ";
            this.openNetworkDatasetToolStripMenuItem.Click += new System.EventHandler(this.openNetworkDatasetToolStripMenuItem_Click);
            // 
            // setDataSourceToolStripMenuItem
            // 
            this.setDataSourceToolStripMenuItem.Name = "setDataSourceToolStripMenuItem";
            this.setDataSourceToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.setDataSourceToolStripMenuItem.Text = "Set Data Source";
            this.setDataSourceToolStripMenuItem.Click += new System.EventHandler(this.setDataSourceToolStripMenuItem_Click);
            // 
            // 表对象类和要素类ToolStripMenuItem
            // 
            this.表对象类和要素类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建表ToolStripMenuItem1,
            this.创建对象类ToolStripMenuItem,
            this.创建要素类ToolStripMenuItem1,
            this.toolStripSeparator1,
            this.拷贝数据库ToolStripMenuItem});
            this.表对象类和要素类ToolStripMenuItem.Name = "表对象类和要素类ToolStripMenuItem";
            this.表对象类和要素类ToolStripMenuItem.Size = new System.Drawing.Size(128, 21);
            this.表对象类和要素类ToolStripMenuItem.Text = "表、对象类和要素类";
            // 
            // 创建表ToolStripMenuItem1
            // 
            this.创建表ToolStripMenuItem1.Name = "创建表ToolStripMenuItem1";
            this.创建表ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.创建表ToolStripMenuItem1.Text = "创建表";
            this.创建表ToolStripMenuItem1.Click += new System.EventHandler(this.创建表ToolStripMenuItem1_Click);
            // 
            // 创建对象类ToolStripMenuItem
            // 
            this.创建对象类ToolStripMenuItem.Name = "创建对象类ToolStripMenuItem";
            this.创建对象类ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.创建对象类ToolStripMenuItem.Text = "对象类";
            this.创建对象类ToolStripMenuItem.Click += new System.EventHandler(this.创建对象类ToolStripMenuItem_Click);
            // 
            // 创建要素类ToolStripMenuItem1
            // 
            this.创建要素类ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建当前图层要素ToolStripMenuItem});
            this.创建要素类ToolStripMenuItem1.Name = "创建要素类ToolStripMenuItem1";
            this.创建要素类ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.创建要素类ToolStripMenuItem1.Text = "要素类";
            // 
            // 创建当前图层要素ToolStripMenuItem
            // 
            this.创建当前图层要素ToolStripMenuItem.Name = "创建当前图层要素ToolStripMenuItem";
            this.创建当前图层要素ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.创建当前图层要素ToolStripMenuItem.Text = "创建当前图层要素";
            this.创建当前图层要素ToolStripMenuItem.Click += new System.EventHandler(this.创建当前图层要素ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // 拷贝数据库ToolStripMenuItem
            // 
            this.拷贝数据库ToolStripMenuItem.Name = "拷贝数据库ToolStripMenuItem";
            this.拷贝数据库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.拷贝数据库ToolStripMenuItem.Text = "拷贝数据库";
            this.拷贝数据库ToolStripMenuItem.Click += new System.EventHandler(this.拷贝数据库ToolStripMenuItem_Click);
            // 
            // rOWObject和Feature对象ToolStripMenuItem
            // 
            this.rOWObject和Feature对象ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新要素ToolStripMenuItem});
            this.rOWObject和Feature对象ToolStripMenuItem.Name = "rOWObject和Feature对象ToolStripMenuItem";
            this.rOWObject和Feature对象ToolStripMenuItem.Size = new System.Drawing.Size(170, 21);
            this.rOWObject和Feature对象ToolStripMenuItem.Text = "ROW,Object和Feature对象";
            // 
            // 更新要素ToolStripMenuItem
            // 
            this.更新要素ToolStripMenuItem.Name = "更新要素ToolStripMenuItem";
            this.更新要素ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.更新要素ToolStripMenuItem.Text = "点选获取要素并更新要素";
            this.更新要素ToolStripMenuItem.Click += new System.EventHandler(this.更新要素ToolStripMenuItem_Click_1);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关系与关系类ToolStripMenuItem,
            this.数据转换ToolStripMenuItem});
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.其他ToolStripMenuItem.Text = "其他";
            // 
            // 关系与关系类ToolStripMenuItem
            // 
            this.关系与关系类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看关系类属性ToolStripMenuItem});
            this.关系与关系类ToolStripMenuItem.Name = "关系与关系类ToolStripMenuItem";
            this.关系与关系类ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.关系与关系类ToolStripMenuItem.Text = "关系与关系类";
            // 
            // 查看关系类属性ToolStripMenuItem
            // 
            this.查看关系类属性ToolStripMenuItem.Name = "查看关系类属性ToolStripMenuItem";
            this.查看关系类属性ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.查看关系类属性ToolStripMenuItem.Text = "新建关系类";
            this.查看关系类属性ToolStripMenuItem.Click += new System.EventHandler(this.查看关系类属性ToolStripMenuItem_Click);
            // 
            // 数据转换ToolStripMenuItem
            // 
            this.数据转换ToolStripMenuItem.Name = "数据转换ToolStripMenuItem";
            this.数据转换ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.数据转换ToolStripMenuItem.Text = "数据转换";
            this.数据转换ToolStripMenuItem.Click += new System.EventHandler(this.数据转换ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 52);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1060, 28);
            this.axToolbarControl1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.axTOCControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 466);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(855, 541);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.chkCustomize);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.basicToolbarControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "城市基础地理信息系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.basicToolbarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.dataView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.LayoutView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxToolbarControl basicToolbarControl;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkCustomize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage dataView;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.TabPage LayoutView;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private System.Windows.Forms.ToolStripMenuItem menuAddData;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ToolStripMenuItem workspace及相关对象ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSystemWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDatabaseWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creatingAFileGeodatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem creatingAPersonalGeodatabaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem remotaDatabaseWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addShapefileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geoDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterSpatialReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表对象类和要素类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建要素类ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem featureDataset对象ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNetworkDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDataSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建表ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 创建对象类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建当前图层要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOWObject和Feature对象ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据转换ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem connectingAFilepersonalGeodatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关系与关系类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看关系类属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 拷贝数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

