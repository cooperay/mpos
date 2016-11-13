using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using MPOS.SERVICE.DB;
using MPOS.SERVICE.Entity;
using Newtonsoft.Json;

namespace MPOS.utils
{
    public class MQCustomer
    {
        
        private IConnectionFactory factory=null;
        private IConnection connection=null;
        private static MQCustomer instance;
        private String QueuerCustomer ="defalult";
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MQCustomer));
        private MQCustomer(String shopCode,String posCode,String mqAddr)
        {
            QueuerCustomer = "QUEUER:_D_" + shopCode+ "_" + posCode;
            factory = new ConnectionFactory(mqAddr);
            connection = factory.CreateConnection();
            connection.ClientId = "CLIENT:C_" + shopCode + "_" + posCode+"_" + Guid.NewGuid().ToString("N");
            SystemInfo.MQ_STATE = true;
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
                logger.Debug("Get MQCustomer error:"+e);   
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
                consumer.Listener += new Apache.NMS.MessageListener(consumer_Listener);
            }
            catch (Exception e)
            {
                logger.Debug("Start MQCustomer listener error:" + e);
            }
        }

        void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;
            //异步调用下，否则无法回归主线程
            if(message != null)
            {
                try
                {
                    DownMessage dm  =   Newtonsoft.Json.JsonConvert.DeserializeObject<DownMessage>(msg.Text);
                    if (dm != null)
                    {
                        switch (dm.actionKey) {
                            case "ordersync":
                                SaleOrderService orderService = new SaleOrderService();
                                orderService.updateState(dm.objKey,OrderState.Synced.ToString());
                                break;
                        }

                    }
                }
                catch (JsonReaderException e)
                {
                    logger.Debug("MQCustomer listener parse JSON error:" + msg.Text);
                }
            }
        }

        void interrupted_Listener()
        {
            logger.Debug("MQCustomer listener connection lost");
            SystemInfo.MQ_STATE = false;
        }

        void resum_Listener()
        {
            logger.Debug("MQCustomer listener connection resum");
            SystemInfo.MQ_STATE = true;
        }

        


    }
}
