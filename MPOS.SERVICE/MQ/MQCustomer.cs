using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using MPOS.SERVICE.DB;


namespace MPOS.SERVICE.MQ
{
    public class MQCustomer
    {
        private IConnectionFactory factory=null;
        private IConnection connection=null;
        private static MQCustomer instance;
        private String QueuerCustomer ="defalult";
        private MQCustomer(String shopCode,String posCode,String mqAddr)
        {
            QueuerCustomer = "QUEUER:_D_" + shopCode+ "_" + posCode;
            factory = new ConnectionFactory(mqAddr);
            connection = factory.CreateConnection();
            connection.ClientId = "CLIENT:C_" + shopCode + "_" + posCode+"_" + Guid.NewGuid().ToString("N");
        }

        public static MQCustomer getInstance()
        {
            SystemConfigService service = new SystemConfigService();
            Dictionary<String, Object> configs = service.getConfigs();
            try
            {
                String shopcode = configs["shopcode"].ToString();
                String poscode = configs["poscode"].ToString();
                String mqaddr = configs["mqaddr"].ToString();
                return getInstance(shopcode, poscode, mqaddr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public static MQCustomer getInstance(String shopCode,String posCode,String mqAddr)
        {
            if(shopCode==null || "".Equals(shopCode) || posCode == null || "".Equals(posCode) || mqAddr == null || "".Equals(mqAddr))
            {
                throw new Exception();
            }
            if(instance == null)
            {
                instance = new MQCustomer(shopCode,posCode,mqAddr);
            }
            return instance;
        }

        public void listenerMessage()
        {
            try
            {
                connection.ConnectionInterruptedListener += new ConnectionInterruptedListener(interrupted_Listener);
                connection.ConnectionResumedListener += new ConnectionResumedListener(resum_Listener);
                //启动连接，监听的话要主动启动连接
                connection.Start();
                ISession session = connection.CreateSession();
                //通过会话创建一个消费者，这里就是Queue这种会话类型的监听参数设置
                IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue(QueuerCustomer));
                //注册监听事件
                consumer.Listener += new MessageListener(consumer_Listener);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            //异步调用下，否则无法回归主线程
            Console.WriteLine(message.ToString());

        }

        void interrupted_Listener()
        {
            Console.WriteLine("连接断开");

        }

        void resum_Listener()
        {
            Console.WriteLine("连接恢复");
        }

        


    }
}
