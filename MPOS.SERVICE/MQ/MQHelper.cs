using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using MPOS.SERVICE;
using MPOS.SERVICE.DB;
using Newtonsoft.Json;
using System.Threading;

namespace MPOS.SERVICE.MQ
{
    public class MQHelper
    {
        private IConnectionFactory factory = null; 
        private IConnection conn = null; 

        private static MQHelper instance;
        private static String queue;
        private MQHelper(String shopCode,String posCode,String mqAddr,String queues)
        {
           factory = new ConnectionFactory(mqAddr);
           conn = factory.CreateConnection();
            queue = queues;
            conn.ClientId ="CLIENT:P_"+ shopCode + "_" + posCode +"_"+ Guid.NewGuid().ToString("N");
        }

        public static MQHelper getInstance()
        {
            SystemConfigService service = new SystemConfigService();
            Dictionary<String,Object> configs = service.getConfigs();
            try
            {
                String shopcode = configs["shopcode"].ToString();
                String poscode = configs["poscode"].ToString();
                String queues = configs["queues"].ToString();
                String mqaddr = configs["mqaddr"].ToString();
                return getInstance(shopcode, poscode, mqaddr, queues);
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
     
        }

        public static MQHelper getInstance(String shopCode, String posCode, String mqAddr,String queues)
        {
            if (shopCode == null || "".Equals(shopCode) || posCode == null || "".Equals(posCode) || mqAddr == null || "".Equals(mqAddr))
            {
                throw new Exception();
            }
            if (instance == null)
            {
                instance = new MQHelper(shopCode,posCode,mqAddr,queues);
            }
            return instance;
        }
        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="message">发送的消息体</param>
        public void asyncSendMessage(Object message)
        {
            ParameterizedThreadStart ParStart = new ParameterizedThreadStart(ThreadMethod);
            Thread t = new Thread(ParStart);
            t.Start(message);
        }


        public Boolean sendMessage (Object messageObj) 
        {
            ISession session = null;
            try
            {
                session = conn.CreateSession();
            }catch(Exception e)
            {
                return false;
            }
            if (session == null) return false;
                    IMessageProducer prod = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(queue));
                    //创建一个发送的消息对象
                    ITextMessage message = prod.CreateTextMessage();
                    //给这个对象赋实际的消息
            
                    message.Text = JsonConvert.SerializeObject(messageObj);
                    //设置消息对象的属性，这个很重要哦，是Queue的过滤条件，也是P2P消息的唯一指定属性
                    message.Properties.SetString("filter", "demo");
                    //生产者把消息发送出去，几个枚举参数MsgDeliveryMode是否长链，MsgPriority消息优先级别，发送最小单位，当然还有其他重载
                    prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                    prod.Close();
                    session.Close();                    
            
            return true;
        }

        private void ThreadMethod(Object message)
        {
            sendMessage(message);
        }



    }
}
