using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MPOS.SERVICE.DB;
using System.Data;

namespace MPOS
{
   public class SystemInfo
    {
        public static String VERSION = "beta1";

        public static String CASHIER_CODE="cashiercode"; //收银员编号
        public static String CASHIER_NAME="cashiername"; //收银员名称
        public static String SHOP_NAME="shopname";
        public static String SHOP_CODE="shopcode";
        public static String POS_CODE="poscode";
        public static String POS_NAME="posname";
        public static String POS_ID = "posid";
        public static String MQ_ADDRESS ="mqaddr";
        public static String ORDER_QUEUE = "orderqueue";
        public static String SERVER_ADDRESS = "ServerAddress";


        public static String CurrentOrderId;
        public static String CurrentOrderCode;

        public static String LastOrderId;
        public static String LastOrderCode;

        //当前订单金额静态变量
        public static Decimal CurrentOrderAmount = 0;
        public static Decimal CurrentOrderMinus = 0;

        public static Boolean MQ_STATE = false;

        public static Boolean SERVER_STATE = false;


        private static Dictionary<String,Object> configs  = new Dictionary<String, Object>();

        public static Object getConfig(String key)
        {
            Object o = null;
            try
            {
               o =configs[key];
            }
            catch(Exception e)
            {

            }
            return o;
        }

        public static void setConfig(String key, Object value)
        {
           configs[key] = value;
        }

        public static Boolean Init()
        {
            SystemConfigService service = new SystemConfigService();
            Dictionary<String, Object> con = service.getConfigs();
            try
            {
                con[SHOP_CODE].ToString();
                con[SHOP_NAME].ToString();
                con[POS_CODE].ToString();
                con[POS_NAME].ToString();
                con[SERVER_ADDRESS].ToString();
                con[MQ_ADDRESS].ToString();
                con[ORDER_QUEUE].ToString();
                con[POS_ID].ToString();
                configs = con;
            }
            catch(Exception e)
            {
                return false;
            }
            
            return true;
        }

    }
}
