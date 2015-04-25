using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;

namespace SpatialDataManagement
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("abcfec82-c217-46b8-9210-ead1694833f6")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialDataManagement.ZoomToLayerCmd")]
    public sealed class ZoomToLayerCmd : BaseCommand
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
        IMapControl3 m_mapcontrol = null;
        ILayer currentLayer = null;
        IActiveView m_activeView = null;

        public ZoomToLayerCmd()
        {
            base.m_category = "通用工具";
            base.m_caption = "缩放到当前图层范围";
            base.m_message = "缩放到当前图层范围";
            base.m_toolTip = "缩放到当前图层范围";
            base.m_name = "ZoomToLayerCmd";

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
            if (m_hookHelper.Hook is IMapControl3)
            {
                m_mapcontrol = m_hookHelper.Hook as IMapControl3;
               // currentLayer = m_mapcontrol.CustomProperty as IFeatureLayer;
                currentLayer = m_mapcontrol.CustomProperty as ILayer;
                m_activeView = m_mapcontrol.ActiveView;
            }
            if (m_activeView == null) return;
            m_activeView.Extent = ((IGeoDataset)currentLayer).Extent;
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, currentLayer, m_activeView.Extent);
        }

        #endregion
    }
}
