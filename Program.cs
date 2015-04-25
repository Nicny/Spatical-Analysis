using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS;

namespace SpatialDataManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!RuntimeManager.Bind(ProductCode.Desktop))
            {
                MessageBox.Show("缺少ESRI ArcObjects许可，将不支持相关组件,部分功能会提示检索COM组件失败.");
                if (!RuntimeManager.Bind(ProductCode.Engine))
                {
                    MessageBox.Show("缺少ESRI ArcObjects和ArcEngine许可，将不支持相关组件. 应用程序将自动关闭.");
                    return;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}