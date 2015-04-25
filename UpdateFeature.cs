using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace SpatialDataManagement.空间数据管理
{
    /// <summary>
    /// Summary description for UpdateFeature.
    /// </summary>
    [Guid("f3db778d-c76a-4473-9201-435bc2d5fcdb")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("SpatialDataManagement.空间数据管理.UpdateFeature")]
    public sealed class UpdateFeature : BaseTool
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
        IMapControl4 mapcontrol4;
        IMap map;
        IActiveView activeview;
        IEngineEditProperties eep;
        IFeatureLayer featurelayer;
  
        bool strStartEdit = true;

        public UpdateFeature()
        {
            base.m_category = "SpatialDataManagement";  
            base.m_caption = "更新要素";
            base.m_message = "更新要素";
            base.m_toolTip = "更新要素";
            base.m_name = "UpdateFeature";   
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

            eep = new EngineEditorClass();
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
            // TODO: Add UpdateFeature.OnClick implementation
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
          
            //点选法获取要素
            featurelayer = eep.TargetLayer as IFeatureLayer;
            
            if (featurelayer == null)
            {
                strStartEdit = false;
                MessageBox.Show("请先启动编辑！！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
            }
            IFeatureClass featureclass = featurelayer.FeatureClass;
            //点击点
            IPoint pt = activeview.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            //对点对象做缓冲区运算
            ITopologicalOperator pTopo;
            pTopo =pt as ITopologicalOperator ;
            IGeometry  pBuffer;
            pBuffer =pTopo.Buffer (4);
            IGeometry pGeometry=pBuffer.Envelope ;
            //新建一个空间过滤器
            ISpatialFilter pSpatialFilter;
            pSpatialFilter =new SpatialFilterClass ();
            pSpatialFilter.Geometry =pGeometry ;
            //依据被选择的要素类的类型不同，设置不同的空间过滤关系
            switch (featureclass .ShapeType )
            {
                case esriGeometryType.esriGeometryPoint:
                    pSpatialFilter .SpatialRel =esriSpatialRelEnum.esriSpatialRelContains ;
                    break ;
                case esriGeometryType.esriGeometryPolyline :
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
                case esriGeometryType.esriGeometryPolygon :
                    pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
            }
            IFeatureSelection pFeatureSelection;
            pFeatureSelection =featurelayer as IFeatureSelection ;
            pFeatureSelection .SelectFeatures (pSpatialFilter ,esriSelectionResultEnum.esriSelectionResultNew ,false );

            ISelectionSet pFeatSet;
            pFeatSet =pFeatureSelection.SelectionSet ;
            ICursor pcursor;
            pFeatSet .Search (null ,true ,out pcursor );
            IFeatureCursor pFeatureCursor=pcursor as IFeatureCursor ;
            IFeature pfeature=pFeatureCursor .NextFeature ();
            //获取要素属性
               UpdateFeatureForm form = new UpdateFeatureForm(pfeature );
               form.Show();
           if(pfeature !=null )
            {
                string fieldname,value;
                for(int i=0;i<pfeature.Fields.FieldCount ;i++)
                {
                    fieldname =pfeature.Fields.get_Field (i).Name .ToString ();
                    int index=pfeature .Fields .FindField (fieldname );
                    value =pfeature.get_Value (index ).ToString ();
                    form.getdataview.Rows.Add(fieldname , value );
                }

            }
                for (int j = 1; j < form.getdataview.Rows.Count-1 ; j++)
                {
                    if (form.getdataview.Rows[j].Cells[0].Value.ToString() == "ObjectID" || form.getdataview.Rows[j].Cells[0].Value.ToString() == "FID")
                    {
                        form.getdataview.Rows[j].Cells[1].ReadOnly = true ;
                    }
                }

            }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add UpdateFeature.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add UpdateFeature.OnMouseUp implementation
        }
        #endregion
    }
}
