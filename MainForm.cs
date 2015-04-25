using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using CoordinateTransformation;
using ESRI.ArcGIS.ArcMapUI;

namespace SpatialDataManagement
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        IMapDocument m_MapDocument = new MapDocumentClass();


        //布局视图
        private IPageLayoutControl3 m_pageLayoutControl = null;
        private ControlsSynchronizer m_controlsSynchronizer = null;


        IToolbarMenu m_TocLayerMenu = new ToolbarMenuClass();
        IToolbarMenu m_TocNetworkLayerMenu = new ToolbarMenuClass();
        IToolbarMenu m_TocMapMenu = new ToolbarMenuClass();
        IToolbarMenu m_toolbarMenu = new ToolbarMenuClass();
        IToolbarMenu m_toolbarMenu2 = new ToolbarMenuClass();
        //  IToolbarPalette m_ToolbarPalette = new ToolbarPaletteClass();


        // Reference to NAWindow.  Need to hold on to reference for events to work.


        ICustomizeDialog m_CustomizeDialog = new CustomizeDialogClass();
        ICustomizeDialogEvents_OnStartDialogEventHandler startDialogE;
        ICustomizeDialogEvents_OnCloseDialogEventHandler closeDialogE;


        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;
            m_pageLayoutControl = (IPageLayoutControl3)axPageLayoutControl1.Object;
            menuSaveDoc.Enabled = false;

            //同步类初始化
            m_controlsSynchronizer = new ControlsSynchronizer(m_mapControl, m_pageLayoutControl);
            m_controlsSynchronizer.BindControls(true);

            //为同步添加控件
            m_controlsSynchronizer.AddFrameworkControl(basicToolbarControl.Object);
            m_controlsSynchronizer.AddFrameworkControl(this.axMapControl1.Object);

            // 添加打开命令按钮到工具条(这这是个自己定义的Command命令类，可以在打开时就同步Map和PageLayout)
            OpenNewMapDocument openMapDoc = new OpenNewMapDocument(m_controlsSynchronizer);
            //

            basicToolbarControl.AddItem(new CreateNewDocument(), 0, 0, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            basicToolbarControl.AddItem(openMapDoc, 0, 1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            //TOCControl图层右键菜单
            m_TocLayerMenu.AddItem(new OpenAttributeTableCmd(), 0, 0, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocLayerMenu.AddItem(new RemoveLayerCmd(), 0, 1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocLayerMenu.AddItem(new ScaleThreSholds(), 1, 2, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new ScaleThreSholds(), 2, 3, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new ScaleThreSholds(), 3, 4, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new LayerSelectable(), 1, 5, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new LayerSelectable(), 2, 6, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocLayerMenu.AddItem(new ZoomToLayerCmd(), 0, 7, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocLayerMenu.AddItem(new LayerPropertiesCmd(), 0, 8, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocLayerMenu.SetHook(axMapControl1);
            m_TocNetworkLayerMenu.AddItem(new ScaleThreSholds(), 1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocNetworkLayerMenu.AddItem(new ScaleThreSholds(), 2, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocNetworkLayerMenu.AddItem(new ScaleThreSholds(), 3, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_TocNetworkLayerMenu.AddItem(new ZoomToLayerCmd(), 0, 3, true, esriCommandStyles.esriCommandStyleIconAndText);

            //TOCControlMap右键菜单
            m_TocMapMenu.AddItem(new ControlsAddDataCommandClass(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new TurnAllLayersOnCmd(), 0, -1, true, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new TurnAllLayersOffCmd(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new SetReferenceScaleCmd(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new ClearReferenceScaleCmd(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.AddItem(new ZoomToReferenceScaleCmd(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_TocMapMenu.SetHook(axMapControl1);

            //axMapControl控件中右键菜单

            m_toolbarMenu.AddItem(new ClearCurrentTool(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_toolbarMenu.AddItem(new ClearFeatureSelection(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_toolbarMenu.AddItem(new ZoomIn3X(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_toolbarMenu.AddItem(new Refresh(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            // m_toolbarMenu.AddItem("esriControls.ControlsEditingSketchContextMenu", 0, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_toolbarMenu.SetHook(axMapControl1);

            //axPageLayoutControl右键菜单
            m_toolbarMenu2.AddItem(new ClearCurrentTool(), 0, -1, false, esriCommandStyles.esriCommandStyleIconAndText);
            m_toolbarMenu2.SetHook(m_pageLayoutControl);

            CreateCustomizeDialog();
        }

        private void CreateCustomizeDialog()
        {
            // Set the customize dialog box events.
            ICustomizeDialogEvents_Event pCustomizeDialogEvent = m_CustomizeDialog as ICustomizeDialogEvents_Event;
            startDialogE = new ICustomizeDialogEvents_OnStartDialogEventHandler(OnStartDialogHandler);
            pCustomizeDialogEvent.OnStartDialog += startDialogE;
            closeDialogE = new ICustomizeDialogEvents_OnCloseDialogEventHandler(OnCloseDialogHandler);
            pCustomizeDialogEvent.OnCloseDialog += closeDialogE;
            // Set the title.
            m_CustomizeDialog.DialogTitle = "定制工具条";
            // Set the ToolbarControl that new items will be added to.
            m_CustomizeDialog.SetDoubleClickDestination(basicToolbarControl);
        }
        private void OnStartDialogHandler()
        {
            basicToolbarControl.Customize = true;

        }
        private void OnCloseDialogHandler()
        {
            basicToolbarControl.Customize = false;
            chkCustomize.Checked = false;
        }
        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();

        }
        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            OpenNewMapDocument openMapDoc = new OpenNewMapDocument(m_controlsSynchronizer);
            openMapDoc.OnCreate(m_controlsSynchronizer.MapControl.Object);
            openMapDoc.OnClick();
            menuSaveDoc.Enabled = true;
        }
        private void menuSaveDoc_Click(object sender, EventArgs e)
        {

            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }

        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }
        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //CopyAndOverwriteMap();
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //if (e.button == 1)
            //{
            //    axMapControl1.Extent = axMapControl1.TrackRectangle();
            //    axMapControl1.Refresh();
            //}
            if (e.button == 2)
            {
                if (e.button == 2) m_toolbarMenu.PopupMenu(e.x, e.y, axMapControl1.hWnd);
            }
        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {

        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            //IActiveView pActiveView = (IActiveView)axPageLayoutControl1.ActiveView.FocusMap;
            //IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
            //displayTransformation.VisibleBounds = axMapControl1.Extent;
            //axPageLayoutControl1.ActiveView.Refresh();

        }

        private void axMapControl1_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        {
            axTOCControl1.Update();
        }

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {

            }
            if (e.button == 2)
            {
                //Open the palette.
                //  m_ToolbarPalette.PopupPalette(e.x, e.y, axPageLayoutControl1.hWnd);
                m_toolbarMenu2.PopupMenu(e.x, e.y, axPageLayoutControl1.hWnd);

            }
        }

        public IColor getRGB(int yourRed, int yourGreen, int yourBlue)
        {
            IRgbColor pRGB = new RgbColorClass();
            pRGB.Red = yourRed;
            pRGB.Green = yourGreen;
            pRGB.Blue = yourBlue;
            pRGB.UseWindowsDithering = true;
            return pRGB;
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            IBasicMap map = new MapClass();
            // ILayer layer = new FeatureLayerClass();
            ILayer layer = null;
            object other = new object();
            object index = new object();
            esriTOCControlItem item = new esriTOCControlItem();

            //Determine what kind of item has been clicked on
            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

            if (e.button == 1)
            {
                //QI to IFeatureLayer and IGeoFeatuerLayer interface
                if (layer == null) return;
                IFeatureLayer featureLayer = layer as IFeatureLayer;
                if (featureLayer == null) return;
                IGeoFeatureLayer geoFeatureLayer = (IGeoFeatureLayer)featureLayer;

                ILegendClass legendClass = new LegendClassClass();
                ISymbol symbol = null;
                if (other is ILegendGroup && (int)index != -1)
                {
                    legendClass = ((ILegendGroup)other).get_Class((int)index);
                    symbol = legendClass.Symbol;
                }
                if (symbol == null) return;

                symbol = GetSymbolByControl(symbol);
                //symbol = GetSymbolBySymbolSelector(symbol);
                if (symbol == null) return;
                legendClass.Symbol = symbol;
                this.Activate();
                //Fire contents changed event that the TOCControl listens to
                axMapControl1.ActiveView.ContentsChanged();
                //Refresh the display
                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                axTOCControl1.Update();
            }
            if (e.button == 2)
            {
                if (item == esriTOCControlItem.esriTOCControlItemMap)
                {
                    m_mapControl.CustomProperty = map;
                    m_TocMapMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
                }
                else if (layer is IFeatureLayer)
                {
                    m_mapControl.CustomProperty = layer;
                    m_TocLayerMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
                }
                else if (layer is INALayer)
                {
                    m_mapControl.CustomProperty = layer;
                    m_TocLayerMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);

                    if (item == esriTOCControlItem.esriTOCControlItemLayer)
                    {

                        ITOCControl toc = axTOCControl1.Object as ITOCControl;
                        toc.Update();
                    }
                }
                else if (layer is INetworkLayer)
                {
                    m_mapControl.CustomProperty = layer;
                    m_TocLayerMenu.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
                }
            }
        }

        private ISymbol GetSymbolByControl(ISymbol symbolType)
        {
            ISymbol symbol = null;
            IStyleGalleryItem styleGalleryItem = null;
            esriSymbologyStyleClass styleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
            if (symbolType is IMarkerSymbol)
            {
                styleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
            }
            if (symbolType is ILineSymbol)
            {
                styleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
            }
            if (symbolType is IFillSymbol)
            {
                styleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
            }
            GetSymbol symbolForm = new GetSymbol(styleClass);
            symbolForm.ShowDialog();
            styleGalleryItem = symbolForm.m_styleGalleryItem;
            if (styleGalleryItem == null) return null;
            symbol = styleGalleryItem.Item as ISymbol;
            symbolForm.Dispose();
            this.Activate();
            return symbol;
        }

        private void chkCustomize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomize.Checked == false)
            {
                m_CustomizeDialog.CloseDialog();
            }
            else
            {
                m_CustomizeDialog.StartDialog(basicToolbarControl.hWnd);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                m_controlsSynchronizer.ActivateMap();
            }
            else
            {
                m_controlsSynchronizer.ActivatePageLayout();
            }
        }

        private void axPageLayoutControl1_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0} {1} {2}", e.pageX.ToString("###.##"), e.pageY.ToString("###.##"), axPageLayoutControl1.Page.Units.ToString().Substring(4));
        }

        private void personalGeoDatabaeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "personal Geodatabase(*.mdb)|*.mdb";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string database = dialog.FileNames.ToString();
                IPropertySet propertySet = new PropertySetClass();
                propertySet.SetProperty("DATABASE", database);
                IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
                workspaceFactory.Open(propertySet, 0);
            }

        }

        private void creatingAFileGeodatabaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                IWorkspace workspace = null;
                IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
                string gdbName = "MyFileGeodatabase.gdb";
                string newGDBDirectory = folderBrowserDialog1.SelectedPath;
                string gdbFullPath = System.IO.Path.Combine(newGDBDirectory, gdbName);

                IWorkspaceName workspaceName = workspaceFactory.Create(newGDBDirectory, gdbName, null, 0);
                IName name = (ESRI.ArcGIS.esriSystem.IName)workspaceName;
                workspace = (IWorkspace)name.Open();
                MessageBox.Show("已在" + newGDBDirectory + "中创建了数据库MyFileGeodatabase.gdb！");
            }
        }

        private void creatingAPersonalGeodatabaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                IWorkspace workspace = null;
                IWorkspaceFactory workspaceFactory = new AccessWorkspaceFactoryClass();
                string gdbName = "MyPersonalGeodatabase.mdb";
                string newGDBDirectory = folderBrowserDialog1.SelectedPath;
                string gdbFullPath = System.IO.Path.Combine(newGDBDirectory, gdbName);

                IWorkspaceName workspaceName = workspaceFactory.Create(newGDBDirectory, gdbName, null, 0);
                IName name = (ESRI.ArcGIS.esriSystem.IName)workspaceName;
                workspace = (IWorkspace)name.Open();
                MessageBox.Show("已在" + newGDBDirectory + "中创建了数据库MyPersonalGeodatabase.mdb！");
            }
        }

        private void creatingAConnectionFileToAnEnterpriseArcSDEGeodatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CreateConnectionFile();
        }

        public static IWorkspaceName CreateConnectionFile(String path, String server, String instance, String user, String password, String database, String version)
        {
            IPropertySet propertySet = new PropertySetClass();
            propertySet.SetProperty("SERVER", server);
            propertySet.SetProperty("INSTANCE", instance);
            propertySet.SetProperty("DATABASE", database);
            propertySet.SetProperty("USER", user);
            propertySet.SetProperty("PASSWORD", password);
            propertySet.SetProperty("VERSION", version);

            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.SdeWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            return workspaceFactory.Create(path, "Sample.sde", propertySet, 0);
        }

        private void connectingToEnterpriseArcSDEGeodatabasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //IPropertySet propertySet = new PropertySetClass();
            //propertySet.SetProperty("SERVER", server);
            //propertySet.SetProperty("INSTANCE", instance);
            //propertySet.SetProperty("DATABASE", "");
            //propertySet.SetProperty("USER", "SCOTT");
            //propertySet.SetProperty("PASSWORD", "tiger");
            //propertySet.SetProperty("VERSION", version);

            //Type factoryType = Type.GetTypeFromProgID(
            //    "esriDataSourcesGDB.SdeWorkspaceFactory");
            //IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
            //    (factoryType);
            //return workspaceFactory.Open(propertySet, 0);
        }
        // For example, server = "Kona".
        // Database = "SDE" or "" if Oracle.
        // Instance = "5151".
        // User = "vtest".
        // Password = "go".
        // Version = "SDE.DEFAULT".
        public static IWorkspace ConnectToTransactionalVersion(String server, String
            instance, String user, String password, String database, String version)
        {
            IPropertySet propertySet = new PropertySetClass();
            propertySet.SetProperty("SERVER", server);
            propertySet.SetProperty("INSTANCE", instance);
            propertySet.SetProperty("DATABASE", database);
            propertySet.SetProperty("USER", user);
            propertySet.SetProperty("PASSWORD", password);
            propertySet.SetProperty("VERSION", version);

            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.SdeWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            return workspaceFactory.Open(propertySet, 0);
        }

        private void addShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Use the OpenFileDialog Class to choose which shapefile to load.
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Shapefiles (*.shp)|*.shp";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // The returned string will be the full path, filename and file-extension for the chosen shapefile. Example: "C:\test\cities.shp"
                string shapefileLocation = openFileDialog.FileName;
                if (shapefileLocation != "")
                {
                    // Create a new ShapefileWorkspaceFactory CoClass to create a new workspace
                    IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactoryClass();

                    // System.IO.Path.GetDirectoryName(shapefileLocation) returns the directory part of the string. Example: "C:\test\"
                    IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(shapefileLocation), 0); // Explicit Cast

                    // System.IO.Path.GetFileNameWithoutExtension(shapefileLocation) returns the base filename (without extension). Example: "cities"
                    IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(System.IO.Path.GetFileNameWithoutExtension(shapefileLocation));

                    IFeatureLayer featureLayer = new FeatureLayerClass();
                    featureLayer.FeatureClass = featureClass;
                    featureLayer.Name = featureClass.AliasName;
                    featureLayer.Visible = true;
                    IActiveView activeView = axMapControl1.ActiveView;
                    activeView.FocusMap.AddLayer(featureLayer);

                    // Zoom the display to the full extent of all layers in the map
                    activeView.Extent = activeView.FullExtent;
                    activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
                else
                {
                    // The user did not choose a shapefile.
                    // Do whatever remedial actions as necessary
                    System.Windows.Forms.MessageBox.Show("No shapefile chosen", "No Choice #1",
                                                        System.Windows.Forms.MessageBoxButtons.OK,
                                                        System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
            //else
            //{
            // The user did not choose a shapefile. They clicked Cancel or closed the dialog by the "X" button.
            // Do whatever remedial actions as necessary.
            // System.Windows.Forms.MessageBox.Show("No shapefile chosen", "No Choice #2",
            //                                      System.Windows.Forms.MessageBoxButtons.OK,
            //                                      System.Windows.Forms.MessageBoxIcon.Exclamation);
            //}
            //}
        }

        private void openNetworkDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialDataManagement.空间数据管理.NetworkDatasetfrom frm = new SpatialDataManagement.空间数据管理.NetworkDatasetfrom(axMapControl1.Object);
            frm.Show();
        }

        private void alterSpatialReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialDataManagement.空间数据管理.Alter_SpatialReference frm = new SpatialDataManagement.空间数据管理.Alter_SpatialReference(axMapControl1.Object);
            frm.Show();

        }

        private void setDataSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialDataManagement.空间数据管理.Set_Data_Source form = new SpatialDataManagement.空间数据管理.Set_Data_Source(axMapControl1.Object);
            form.Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialDataManagement.空间数据管理.CreateFeatureClassForm form = new 空间数据管理.CreateFeatureClassForm();
            form.Show();
        }

        private void 创建表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SpatialDataManagement.空间数据管理.Create_Table form = new 空间数据管理.Create_Table();
            form.Show();
        }

        private void 创建对象类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialDataManagement.空间数据管理.ObjectClassForm form = new 空间数据管理.ObjectClassForm();
            form.Show();
        }

        private void 创建点要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 创建当前图层要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand tool = new SpatialDataManagement.空间数据管理.CreateFeature();
            tool.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = tool as ITool;
        }

        private void 更新要素ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ICommand tool = new SpatialDataManagement.空间数据管理.UpdateFeature();
            tool.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = tool as ITool;
        }

        private void 数据转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialDataManagement.空间数据管理.ConvertShapefileToFeatClass form = new 空间数据管理.ConvertShapefileToFeatClass();
            form.Show();
        }

        private void connectingAFilepersonalGeodatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialDataManagement.空间数据管理.ConnectGBDForm form = new 空间数据管理.ConnectGBDForm();
            form.Show();
        }

        private void 查看关系类属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            空间数据管理.RelationshipClassForm form = new 空间数据管理.RelationshipClassForm();
            form.Show();
        }

        private void 拷贝数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand cmd = new GDB2GDBCmd();
            cmd.OnCreate(axMapControl1.Object);
            cmd.OnClick();

        }

        public static IWorkspace WorkgroupArcSdeWorkspaceFromPropertySet(String server, String instance, String authenticationMode, String database, String version)
        {
            IPropertySet propertySet = new PropertySetClass();
            propertySet.SetProperty("SERVER", server);
            propertySet.SetProperty("INSTANCE", instance);
            propertySet.SetProperty("DATABASE", database);
            propertySet.SetProperty("AUTHENTICATION_MODE", authenticationMode);
            propertySet.SetProperty("VERSION", version);

            Type factoryType = Type.GetTypeFromProgID("esriDataSourcesGDB.SdeWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance(factoryType);
            return workspaceFactory.Open(propertySet, 0);
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + @"\空间数据管理.chm");
        }

        private void menuAddData_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsAddDataCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

    }
}











