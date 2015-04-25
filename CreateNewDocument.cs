using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;

namespace SpatialDataManagement
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("d94cebc6-e820-4dc5-86d9-006166d29d28")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialDataManagement.CreateNewDocument")]
    public sealed class CreateNewDocument : BaseCommand
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
        IMapControl3 mapControl = null;



        public CreateNewDocument()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "�ļ�����";
            base.m_caption = "�½���ͼ�ĵ�";
            base.m_message = "�½���ͼ�ĵ�";
            base.m_toolTip = "�½���ͼ�ĵ�";
            base.m_name = "CreateNewDocument";

   

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();

            m_hookHelper.Hook = hook;
            //mAV = m_hookHelper.ActiveView;

            //get the MapControl from the hook in case the container is a ToolbatControl
            if (m_hookHelper.Hook is IToolbarControl)
            {
                mapControl = (IMapControl3)((IToolbarControl)m_hookHelper.Hook).Buddy;
            }
            //In case the container is MapControl
            else if (m_hookHelper.Hook is IMapControl3)
            {
                mapControl = (IMapControl3)m_hookHelper.Hook;
            }
            else
            {
                MessageBox.Show("Active control must be MapControl!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

         
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add CreateNewDocument.OnClick implementation
            DialogResult res = MessageBox.Show("Would you like to save the current document?", "AoView", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //launch the save command (why work hard!?)
                ICommand command = new ControlsSaveAsDocCommandClass();
                command.OnCreate(m_hookHelper.Hook);
                command.OnClick();
            }

            //craete a new Map
            IMap map = new MapClass();
            map.Name = "Map";

            //assign the new map to the MapControl
            mapControl.DocumentFilename = string.Empty;
            mapControl.Map = map;
        }

        #endregion
    }
}
