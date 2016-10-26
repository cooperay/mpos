using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMPOS
{
   public static class SystemInfo
    {
        public static String ShopCode = "1001";
        public static String ShopName = "豫港大道广场店";
        public static String cashierCode = "1002";
        public static String cashier = "收银员";
        public static String PosCode = "01";
        public static String Sq = "00001";
        public static String CurrentOrderId;
        public static String CurrentOrderCode;

        public static String LastOrderId;
        public static String LastOrderCode;


        //当前订单金额静态变量
        public static Decimal CurrentOrderAmount = 0;
        public static Decimal CurrentOrderMinus = 0;

    }
}
