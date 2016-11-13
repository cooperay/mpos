using MPOS.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MPOS.SERVICE.DB;
using System.Data;
using MPOS.component;
namespace MPOS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            if(!SystemInfo.Init())
            {
                MessageBox.Show("系统未初始化，请联系管理员！");
                return;
            }
            Application.Run(new LoginInitForm());
        }
    }
}
