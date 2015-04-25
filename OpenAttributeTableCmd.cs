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
    [Guid("1cfb388e-e77e-4c6a-a489-d79cfc0992ec")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialDataManagement.OpenAttributeTableCmd")]
    public sealed class OpenAttributeTableCmd : BaseCommand
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
        IFeatureLayer currentLayer = null;

        public OpenAttributeTableCmd()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "通用工具";
            base.m_caption = "打开图层属性表";
            base.m_message = "打开图层属性表";
            base.m_toolTip = "打开图层属性表";
            base.m_name = "OpenAttributeTableCmd";   

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
            IMap map = null;
            if (m_hookHelper.Hook is IMapControl3)
            {
                m_mapcontrol = m_hookHelper.Hook as IMapControl3;
                currentLayer = m_mapcontrol.CustomProperty as IFeatureLayer;
                if (currentLayer == null) return;
                map = m_mapcontrol.Map;
            }
            if (map == null) return;
            SpatialDataManagement.AttributesContextMenu layerAttributeTable = new SpatialDataManagement.AttributesContextMenu(map, currentLayer);
            layerAttributeTable.Show(m_hookHelper as System.Windows.Forms.IWin32Window);
            //LayerAttributes  layerAttributeTable = new  LayerAttributes(map, currentLayer);
            //layerAttributeTable.Show(m_hookHelper as System.Windows.Forms.IWin32Window);
        }

        #endregion
    }
}
