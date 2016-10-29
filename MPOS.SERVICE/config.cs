using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MLMPOS.Service
{
   public class config
    {
        public static string DB_FILE = "Data Source ="+Environment.CurrentDirectory + ConfigurationManager.AppSettings["dbfile"].ToString();
        public static string SHOP_CODE =ConfigurationManager.AppSettings["shopcode"].ToString();
        public static string POS_CODE = ConfigurationManager.AppSettings["poscode"].ToString();
        public static string MQ_ADDR = ConfigurationManager.AppSettings["MQAddr"].ToString();
        public static string SALE_ORDER_QUEUES = ConfigurationManager.AppSettings["MQSaleOrderSyncQueues"].ToString();
    }
}
