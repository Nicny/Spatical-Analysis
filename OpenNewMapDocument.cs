using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace SpatialDataManagement
{
    /// <summary>
    ///打开地图文档
    /// </summary>
    [Guid("34df9bdd-122a-479f-a53e-f383f38ce5c7")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialDataManagement.OpenNewMapDocument")]
    public sealed class OpenNewMapDocument : BaseCommand
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
        private ControlsSynchronizer m_controlsSynchronizer = null;
        private string m_sDocumentPath = string.Empty;

        private string documentFileName = string.Empty;
        public OpenNewMapDocument(ControlsSynchronizer controlsSynchronizer)
        {
            base.m_category = "打开地图文档";
            base.m_caption = "打开地图文档";
            base.m_message = "打开地图文档";
            base.m_toolTip = "打开地图文档";
            base.m_name = "打开地图文档";
            try
            {

                base.m_bitmap = new Bitmap(GetApplicationPath.ApplicationPath + "ControlsSynchronizer\\open_16.png");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
            m_controlsSynchronizer = controlsSynchronizer;
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

            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            // TODO:  Add other initialization code
        }

        /// <summary>
        ///打开地图文档
        /// </summary>
        public override void OnClick()
        {
            //运行一个新文件窗口
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "地图文档 (*.mxd)|*.mxd";
            dlg.Multiselect = false;
            dlg.Title = "打开地图文档";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_sDocumentPath = dlg.FileName;
                IMapDocument mapDoc = new MapDocumentClass();
                if (mapDoc.get_IsPresent(m_sDocumentPath) && !mapDoc.get_IsPasswordProtected(m_sDocumentPath))
                {
                    mapDoc.Open(m_sDocumentPath, string.Empty);
                    IMap map = mapDoc.get_Map(0);
                    m_controlsSynchronizer.ReplaceMap(map);
                    mapDoc.Close();
                }
            }
        }

        #endregion

        //文档路径
        public string DocumentPath
        {
            get { return m_sDocumentPath; }
        }
        //文档文件名
        public string DocumentFileName
        {
            get
            {
                int index = DocumentPath.LastIndexOf("\\");
                documentFileName = DocumentPath.Substring(index + 1);
                return documentFileName;
            }
        }

    }
}
