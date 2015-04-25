using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;

namespace SpatialDataManagement
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("28a91291-f3b1-4246-9034-86598eb78cca")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialDataManagement.LayerPropertiesCmd")]
    public sealed class LayerPropertiesCmd : BaseCommand
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMapControl3 m_mapcontrol = null;
        IFeatureLayer currentLayer = null;

        public LayerPropertiesCmd()
        {
            base.m_category = "通用工具";
            base.m_caption = "图层属性";
            base.m_message = "图层属性";
            base.m_toolTip = "图层属性";
            base.m_name = "LayerPropertiesCmd";
            base.m_enabled = true;

            try
            {
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无效位图！！" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;           
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            if (m_hookHelper.Hook is IToolbarControl)
            {
                IToolbarControl toolbarControl = m_hookHelper.Hook as IToolbarControl;
                m_mapcontrol = (IMapControl3)toolbarControl.Buddy;
            }
            if (m_hookHelper.Hook is IMapControl3)
            {
                m_mapcontrol = m_hookHelper.Hook as IMapControl3;
            }
            if (m_mapcontrol != null)
            {
                currentLayer = m_mapcontrol.CustomProperty as IFeatureLayer;
                m_activeView = m_mapcontrol.ActiveView;
            }

            if (currentLayer == null) return;
            SetupFeaturePropertySheet(currentLayer);
        }

        #endregion
        private bool SetupFeaturePropertySheet(ILayer layer)
        {
            if (layer == null) return false;
            try
            {
                ESRI.ArcGIS.Framework.IComPropertySheet pComPropSheet;
                pComPropSheet = new ESRI.ArcGIS.Framework.ComPropertySheetClass();
                pComPropSheet.Title = layer.Name + "- 属性";

                ESRI.ArcGIS.esriSystem.UID pPPUID = new ESRI.ArcGIS.esriSystem.UIDClass();
                pComPropSheet.AddCategoryID(pPPUID);

                // General....
                ESRI.ArcGIS.Framework.IPropertyPage pGenPage = new ESRI.ArcGIS.CartoUI.GeneralLayerPropPageClass();
                pComPropSheet.AddPage(pGenPage);

                // Source
                ESRI.ArcGIS.Framework.IPropertyPage pSrcPage = new ESRI.ArcGIS.CartoUI.FeatureLayerSourcePropertyPageClass();
                pComPropSheet.AddPage(pSrcPage);

                // Selection...
                ESRI.ArcGIS.Framework.IPropertyPage pSelectPage = new ESRI.ArcGIS.CartoUI.FeatureLayerSelectionPropertyPageClass();
                pComPropSheet.AddPage(pSelectPage);

                // Display....
                ESRI.ArcGIS.Framework.IPropertyPage pDispPage = new ESRI.ArcGIS.CartoUI.FeatureLayerDisplayPropertyPageClass();
                pComPropSheet.AddPage(pDispPage);

                // Symbology....
                ESRI.ArcGIS.Framework.IPropertyPage pDrawPage = new ESRI.ArcGIS.CartoUI.LayerDrawingPropertyPageClass();
                pComPropSheet.AddPage(pDrawPage);

                // Fields... 
                ESRI.ArcGIS.Framework.IPropertyPage pFieldsPage = new ESRI.ArcGIS.CartoUI.LayerFieldsPropertyPageClass();
                pComPropSheet.AddPage(pFieldsPage);

                // Definition Query... 
                ESRI.ArcGIS.Framework.IPropertyPage pQueryPage = new ESRI.ArcGIS.CartoUI.LayerDefinitionQueryPropertyPageClass();
                pComPropSheet.AddPage(pQueryPage);

                // Labels....
                ESRI.ArcGIS.Framework.IPropertyPage pSelPage = new ESRI.ArcGIS.CartoUI.LayerLabelsPropertyPageClass();
                pComPropSheet.AddPage(pSelPage);

                // Joins & Relates....
                ESRI.ArcGIS.Framework.IPropertyPage pJoinPage = new ESRI.ArcGIS.ArcMapUI.JoinRelatePageClass();
                pComPropSheet.AddPage(pJoinPage);

                // Setup layer link
                ESRI.ArcGIS.esriSystem.ISet pMySet = new ESRI.ArcGIS.esriSystem.SetClass();
                pMySet.Add(layer);
                pMySet.Reset();

                // make the symbology tab active
                pComPropSheet.ActivePage = 4;

                // show the property sheet
                bool bOK = pComPropSheet.EditProperties(pMySet, 0);

                m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
                return (bOK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
