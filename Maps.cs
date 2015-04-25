using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using ESRI.ArcGIS.Carto;


namespace SpatialDataManagement
{
    public class Maps : IMaps,IDisposable
    {
        private ArrayList m_array = null;

        public Maps()
        {
            m_array = new ArrayList();
        }
        public void Dispose()
        {
            if (m_array != null)
            {
                m_array.Clear();
                m_array = null;
            }
        }
        
        //在给定的索引处移除对象
        public void RemoveAt(int Index)
        {
            if (Index > m_array.Count || Index < 0)
                throw new Exception("Maps::RemoveAt:\r\nIndex is out of range!");

            m_array.RemoveAt(Index);
        }

        //重置ArrayList数组
        public void Reset()
        {
            m_array.Clear();
        }
        
        //获得集合中地图的个数
        public int Count
        {
            get
            {
                return m_array.Count;
            }
        }
        
        //返回给定索引处的地图
        public IMap get_Item(int Index)
        {
            if (Index > m_array.Count || Index < 0)
                throw new Exception("Maps::get_Item:\r\nIndex is out of range!");

            return m_array[Index] as IMap;
        }

        //移除所给地图实例
        public void Remove(IMap Map)
        {
            m_array.Remove(Map);
        }

        //创建一个新地图
        public IMap Create()
        {
            IMap newMap = new MapClass();
            m_array.Add(newMap);
            return newMap;
        }

        //添加所给地图到集合中
        public void Add(IMap Map)
        {
            if (Map == null)
                throw new Exception("Maps::Add:\r\nNew Map is mot initialized!");

            m_array.Add(Map);
        }
    }
}
