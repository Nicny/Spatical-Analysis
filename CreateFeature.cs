using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace SpatialDataManagement.空间数据管理
{
    /// <summary>
    /// Summary description for CreateFeature.
    /// </summary>
    [Guid("55e1245d-9bbb-4f76-8523-c065c925211e")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialDataManagement.空间数据管理.CreateFeature")]
    public sealed class CreateFeature : BaseTool
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
        IMapControl4 mapcontrol4;
        IMap map;
        IActiveView activeview;
        IEngineEditProperties eep;
        IFeatureLayer featurelayer;
        INewPolygonFeedback npfb;
        INewLineFeedback nlfb;
        bool strStartEdit = true;
        private IHookHelper m_hookHelper = null;

        public CreateFeature()
        {
            eep = new EngineEditorClass();

            base.m_category = "SpatialDataManagement";  
            base.m_caption = "创建要素";   
            base.m_message = "创建要素";  
            base.m_toolTip = "创建要素";  
            base.m_name = "CreateFeature";   
            try
            {
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }     
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            mapcontrol4 = m_hookHelper.Hook as IMapControl4;
            map = m_hookHelper.FocusMap;
            activeview = m_hookHelper.ActiveView;
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add CreateFeature.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {

            IPoint pt = activeview.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

            featurelayer = eep.TargetLayer as IFeatureLayer;
            if (featurelayer == null)
            {
                 strStartEdit = false ;
                MessageBox.Show("请先启动编辑！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
            }
            if (featurelayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
            { createFeature(pt as IGeometry); }

            if (featurelayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                if (npfb == null)
                {
                    npfb = new NewPolygonFeedbackClass();
                    npfb.Display = activeview.ScreenDisplay;
                    npfb.Start(pt);
                }
                else { npfb.AddPoint(pt); }
            }
            if (featurelayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                if (nlfb == null)
                {
                    nlfb = new NewLineFeedbackClass();
                    nlfb.Display = activeview.ScreenDisplay;
                    nlfb.Start(pt);
                }
                else { nlfb.AddPoint(pt); }
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            if (strStartEdit == true)
            {
                //if (featurelayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint) { return; }
                IPoint pPt = activeview.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                if (npfb != null) npfb.MoveTo(pPt);
                if (nlfb != null) nlfb.MoveTo(pPt);
            }
        }

        public override void OnDblClick()
        {
            if (strStartEdit == true)
            {
                IGeometry pgeo = null;
                if (featurelayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    pgeo = npfb.Stop(); createFeature(pgeo);

                }
                if (featurelayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                { pgeo = nlfb.Stop(); createFeature(pgeo); }
                //if (featurelayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint) { return; }
                //mapcontrol4.CurrentTool = null;
                mapcontrol4.CurrentTool = null;
            }
        }
        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add CreateFeature.OnMouseUp implementation
        }
        #endregion
        private void createFeature(IGeometry pGeom)
        {
            featurelayer = eep.TargetLayer as IFeatureLayer;
            if (featurelayer == null)
            {
                MessageBox.Show("请先启动编辑！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ; return;
            }

            IDataset ds = featurelayer.FeatureClass as IDataset;
            IWorkspaceEdit pwe = ds.Workspace as IWorkspaceEdit;
            pwe.StartEditOperation();
            IFeatureClass pFeatureClass = featurelayer.FeatureClass;
            pwe.StartEditOperation();
            IFeature pFeature = pFeatureClass.CreateFeature();
            pFeature.Shape = pGeom;
            pFeature.Store();
            pwe.StopEditOperation();
            CreateFeatureForm form = new CreateFeatureForm(pFeature);
            form.Show();

            activeview.Refresh();
        }
    }
}
