using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace MLMPOS.Service
{
   public class config
    {
        public static string DB_FILE = "Data Source ="+Environment.CurrentDirectory + ConfigurationSettings.AppSettings["dbfile"];
        public static string SHOP_CODE = ConfigurationSettings.AppSettings["shopcode"];
        public static string POS_CODE =ConfigurationSettings.AppSettings["poscode"];
    }
}
