using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls ;
using System.Collections;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;

namespace SpatialDataManagement
{
    /// <summary>
    /// MapControl与PageLayoutControl同步
    /// </summary>
    public class ControlsSynchronizer
    {
        private IMapControl3 m_mapControl = null;
        private IPageLayoutControl2 m_pageLayoutControl = null;

        //控件信息记录
        private ITool m_mapActiveTool = null;
        private ITool m_pageLayoutActiveTool = null;
        private bool m_IsMapCtrlactive = true;

        private ArrayList m_frameworkControls = null;

        public ControlsSynchronizer()
        {
            //初始化ArrayList
            m_frameworkControls = new ArrayList();
        }

        public ControlsSynchronizer(IMapControl3 mapControl, IPageLayoutControl2 pageLayoutControl)
            : this()
        {
            this.m_mapControl = mapControl;
            this.m_pageLayoutControl = pageLayoutControl;
        }

        public IMapControl3 MapControl
        {
            get { return m_mapControl ; }
            set { m_mapControl = value; }
        }

        public IPageLayoutControl2 PageLayoutControl
        {
            get { return m_pageLayoutControl; }
            set { m_pageLayoutControl = value; }
        }

        //取得当前ActiveView的类型
        public string ActiveViewType
        {
            get
            {
                if (m_IsMapCtrlactive)
                    return "MapControl";
                else
                    return "PageLayoutControl";
            }

        }

        //取得当前活动对象
        public object ActiveControl
        {
            get
            {
                if (m_mapControl == null || m_pageLayoutControl == null)
                    throw new Exception("ControlsSynchronizer::ActiveControl:\r\nEither MapControl or PageLayoutControl are not initialized!");
                if (m_IsMapCtrlactive)
                    return m_mapControl.Object;
                else
                    return m_pageLayoutControl.Object;
            }
        }

        //激活 MapControl ，停用 PagleLayoutControl
        public void ActivateMap()
        {
            try
            {
                if (m_pageLayoutControl == null || m_mapControl == null)
                    throw new Exception("ControlsSynchronizer::ActivateMap:\r\nEither MapControl or PageLayoutControl are not initialized!");

                //缓存PageLayoutControl控件
                if (m_pageLayoutControl.CurrentTool != null) m_pageLayoutActiveTool = m_pageLayoutControl.CurrentTool;

                //停用PagleLayout
                m_pageLayoutControl.ActiveView.Deactivate();

                //激活MapControl
                m_mapControl.ActiveView.Activate(m_mapControl.hWnd);
                if (m_mapActiveTool != null) m_mapControl.CurrentTool = m_mapActiveTool;
                m_IsMapCtrlactive = true;
                this.SetBuddies(m_mapControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivateMap:\r\n{0}", ex.Message));
            }
        }

        // 激活PagleLayoutControl，停用MapCotrol
        public void ActivatePageLayout()
        {
            try
            {
                if (m_pageLayoutControl == null || m_mapControl == null)
                    throw new Exception("ControlsSynchronizer::ActivatePageLayout:\r\nEither MapControl or PageLayoutControl are not initialized!");

                //缓存MapControl控件
                if (m_mapControl.CurrentTool != null) m_mapActiveTool = m_mapControl.CurrentTool;

                //停用MapControl
                m_mapControl.ActiveView.Deactivate();

                //激活PagleLayout
                m_pageLayoutControl.ActiveView.Activate(m_pageLayoutControl.hWnd);
                if (m_pageLayoutActiveTool != null) m_pageLayoutControl.CurrentTool = m_pageLayoutActiveTool;
                m_IsMapCtrlactive = false;
                this.SetBuddies(m_pageLayoutControl.Object);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::ActivatePageLayout:\r\n{0}", ex.Message));
            }
        }

        //替换 PageLayoutControl 和 MapControl 的焦点地图
        public void ReplaceMap(IMap newMap)
        {
            if (newMap == null)
                throw new Exception("ControlsSynchronizer::ReplaceMap:\r\nNew map for replacement is not initialized!");

            if (m_pageLayoutControl == null || m_mapControl == null)
                throw new Exception("ControlsSynchronizer::ReplaceMap:\r\nEither MapControl or PageLayoutControl are not initialized!");

            //为PageLayout的需要新建一个Map实例
            IMaps maps = new Maps() as IMaps;
            maps.Add(newMap);
            bool bIsMapActive = m_IsMapCtrlactive;

            //替换地图
            this.ActivatePageLayout();
            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);

            m_mapControl.Map = newMap;
            m_pageLayoutActiveTool = null;
            m_mapActiveTool = null;

            //确保最后的工具为当前工具
            if (bIsMapActive)
            {
                this.ActivateMap();
                m_mapControl.ActiveView.Refresh();
            }
            else
            {
                this.ActivatePageLayout();
                m_pageLayoutControl.ActiveView.Refresh();
            }

        }

        //用一个新的焦点地图绑定 MapControl 和 PageLayoutControl 
        public void BindControls(IMapControl3 mapControl, IPageLayoutControl2 pageLayoutControl, bool activateMapFirst)
        {
            if (mapControl == null || pageLayoutControl == null)
                throw new Exception("ControlsSynchronizer::BindControls:\r\nEither MapControl or PageLayoutControl are not initialized!");

            m_mapControl = MapControl;
            m_pageLayoutControl = pageLayoutControl;

            this.BindControls(activateMapFirst);
        }

        public void BindControls(bool activateMapFirst)
        {
            if (m_pageLayoutControl == null || m_mapControl == null)                
                throw new Exception("ControlsSynchronizer::BindControls:\r\nEither MapControl or PageLayoutControl are not initialized!");
            IMap newMap = new MapClass();
            newMap.Name = "Map";

            IMaps maps = new Maps() as IMaps;
            maps.Add(newMap);

            m_pageLayoutControl.PageLayout.ReplaceMaps(maps);
            m_mapControl.Map = newMap;

            //重置当前工具
            m_pageLayoutActiveTool = null;
            m_mapActiveTool = null;

            if (activateMapFirst)
                this.ActivateMap();
            else
                this.ActivatePageLayout();
        }

        //添加
        public void AddFrameworkControl(object control)
        {
            if (control == null)
                throw new Exception("ControlsSynchronizer::AddFrameworkControl:\r\nAdded control is not initialized!");

            m_frameworkControls.Add(control);
        }

        //移除
        public void RemoveFrameworkControl(object control)
        {
            if (control == null)
                throw new Exception("ControlsSynchronizer::RemoveFrameworkControl:\r\nControl to be removed is not initialized!");

            m_frameworkControls.Remove(control);
        }

        //指定位置移除
        public void RemoveFrameworkControlAt(int index)
        {
            if (m_frameworkControls.Count < index)
                throw new Exception("ControlsSynchronizer::RemoveFrameworkControlAt:\r\nIndex is out of range!");

            m_frameworkControls.RemoveAt(index);
        }
        //设置伙伴控件
        private void SetBuddies(object buddy)
        {
            try
            {
                if (buddy == null)
                    throw new Exception("ControlsSynchronizer::SetBuddies:\r\nTarget Buddy Control is not initialized!");

                foreach (object obj in m_frameworkControls)
                {
                    if (obj is IToolbarControl)
                    {
                        ((IToolbarControl)obj).SetBuddyControl(buddy);
                    }
                    else if (obj is ITOCControl)
                    {
                        ((ITOCControl)obj).SetBuddyControl(buddy);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ControlsSynchronizer::SetBuddies:\r\n{0}", ex.Message));
            }
        }

    }
}
