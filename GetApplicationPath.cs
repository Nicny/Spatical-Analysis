using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpatialDataManagement
{
    /// <summary>
    /// 应用程序路径
    /// </summary>
    public class GetApplicationPath
    {
        private static string applicationPath;
        public static string ApplicationPath
        {
            get
            {
                string tpath = Application.StartupPath;
                int index = tpath.LastIndexOf("bin");
                applicationPath = tpath.Substring(0, index);
                return applicationPath;
            }
        }
    }
}
