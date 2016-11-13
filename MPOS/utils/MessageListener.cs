using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MPOS.utils
{
    public class MessageListener
    {
        private static MessageListener instance;
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MessageListener));
        private MessageListener()
        {
            
        }

        public static MessageListener getInstance()
        {
            if (instance == null)
            {
                instance = new MessageListener();
            }
            return instance;
        }

        public void startListener()
        {
            logger.Debug("MessageListener start");
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
        }

        public void ThreadMethod()
        {
            MQCustomer.getInstance(SystemInfo.getConfig(SystemInfo.SHOP_CODE).ToString(), SystemInfo.getConfig(SystemInfo.POS_CODE).ToString(), SystemInfo.getConfig(SystemInfo.MQ_ADDRESS).ToString()).listenerMessage();
            logger.Debug("MessageListener start success");
        }
    }
}
