using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Carto;

namespace SpatialDataManagement
{
   
    public  class ScaleThreSholds : BaseCommand,ICommandSubType
    {

        private IMapControl3 m_mapControl;
        private long m_subType;

        public ScaleThreSholds()
		{

		}
        

      
      
        public override void OnCreate(object hook)
        {
             if(hook is IMapControl3)
                m_mapControl = (IMapControl3)hook;
        }

        public override void OnClick()
        {
            if (m_mapControl == null) return;
			ILayer layer = (ILayer) m_mapControl.CustomProperty;
			if (m_subType == 1) layer.MaximumScale = m_mapControl.MapScale;
			if (m_subType == 2) layer.MinimumScale = m_mapControl.MapScale;
			if (m_subType == 3)
			{
				layer.MaximumScale = 0;
				layer.MinimumScale = 0;
			}
			m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography,null,null);
        }

       public int GetCount()
		{
			return 3;
		}
	
		public void SetSubType(int SubType)
		{
			m_subType = SubType;
		}
	
		public override string Caption
		{
			get
			{
				if (m_subType == 1) return "Set Maximum Scale";
				else if (m_subType == 2) return "Set Minimum Scale";
				else return "Remove Scale Thresholds";
			}
		}

        public override bool Enabled
        {
            get
            {
                bool enabled = true;
                ILayer layer = (ILayer)m_mapControl.CustomProperty;

                if (m_subType == 3)
                {
                    if ((layer.MaximumScale == 0) & (layer.MinimumScale == 0)) enabled = false;
                }
                return enabled;
            }
        }
    }
}
