using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using MLMPOS.Service;

namespace MPOS.SERVICE.MQ
{
    public class MQHelper
    {
        private IConnectionFactory factory = null; 
        private IConnection conn = null; 

        private static MQHelper instance;
        private MQHelper()
        {
           factory = new ConnectionFactory(config.MQ_ADDR);
           conn = factory.CreateConnection();
            conn.ClientId ="CLIENT:p_"+ config.SHOP_CODE + "_" + config.POS_CODE +"_"+ Guid.NewGuid().ToString("N");
        }

        public static MQHelper getInstance()
        {
            if(instance == null)
            {
                instance = new MQHelper();
            }
            return instance;
        }
        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="message">发送的消息体</param>
        public void asyncSendMessage(String message)
        {

        }


        public Boolean sendMessage (String messageText) 
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
                    IMessageProducer prod = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(config.SALE_ORDER_QUEUES));
                    //创建一个发送的消息对象
                    ITextMessage message = prod.CreateTextMessage();
                    //给这个对象赋实际的消息
                    message.Text = messageText;
                    //设置消息对象的属性，这个很重要哦，是Queue的过滤条件，也是P2P消息的唯一指定属性
                    message.Properties.SetString("filter", "demo");
                    //生产者把消息发送出去，几个枚举参数MsgDeliveryMode是否长链，MsgPriority消息优先级别，发送最小单位，当然还有其他重载
                    prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                    prod.Close();
                    session.Close();                    
            
            return true;
        }


        
    }
}
