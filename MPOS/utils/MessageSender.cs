using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MPOS.SERVICE.MQ;
using Newtonsoft.Json;

namespace MPOS.utils
{
    public class MessageSender
    {
        private static MessageSender instance;
        private Int32 tempCount = 0 ;
        private MessageSender()
        {

        }

        public static MessageSender getInstance()
        {
            if(instance == null)
            {
                instance = new MessageSender();
            }
            return instance;
        }

     
        /// <summary>
        /// 同步发送消息，如果mq队列存在问题会一直等待。
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        public void sendMessage(Object message)
        {
            MQHelper mqhelper = MQHelper.getInstance(SystemInfo.getConfig(SystemInfo.SHOP_CODE).ToString(), SystemInfo.getConfig(SystemInfo.POS_CODE).ToString(), SystemInfo.getConfig(SystemInfo.MQ_ADDRESS).ToString(), SystemInfo.getConfig(SystemInfo.ORDER_QUEUE).ToString());
            mqhelper.sendMessage(JsonConvert.SerializeObject(message));
        }


        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="message">发送的消息体</param>
        public void asyncSendMessage(Object message)
        {
            ParameterizedThreadStart ParStart = new ParameterizedThreadStart(sendMessage);
            Thread t = new Thread(ParStart);
            t.Start(message);
        }

    }
}
