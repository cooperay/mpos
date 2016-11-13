using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPOS.SERVICE.DB;
using MPOS.SERVICE.Entity;
using MPOS.utils;
using System.Timers;
using System.Threading;
namespace MPOS.utils
{
    public class SyncBackUtil
    {
        private static SyncBackUtil instance;

        private SaleOrderService service;

        private int mill;

        private log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SyncBackUtil));

        public static Boolean isExit = false;
        private SyncBackUtil()
        {
            service = new SaleOrderService();
        }

        public static SyncBackUtil getInstance()
        {
            if(instance == null)
            {
                instance = new SyncBackUtil();
            }
            return instance;
        }

        /// <summary>
        /// 启动同步守护进程
        /// 指定同步间隔
        /// </summary>
        public void startSyncThread(int mill)
        {
            this.mill = mill;
           Thread thread = new Thread(ThreadMethod);
            thread.Name = "MposSync";
            thread.Start();
        }

        private void ThreadMethod()
        {
            logger.Debug("Back sync start");
            while (true)
            {
                if (isExit) return;
                Thread.Sleep(this.mill);
                logger.Debug("Sync Thread start sync ");
                List<SaleOrder> list = service.getUnSyncList();
                list.ForEach(l =>
                {
                    MessageSender.getInstance().sendMessage(l);
                });
                logger.Debug("Sync Thread send message count :"+list.Count);
              
            }
        }

        public void startSyncThread()
        {
            startSyncThread(1*60*1000);  //默认一分钟
        }

 


    }
}
