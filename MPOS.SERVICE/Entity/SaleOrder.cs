using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPOS.SERVICE.Entity
{
   public class SaleOrder
    {
      
        public String orderid;
        public String ordercode;
        public String shopcode;
        public String poscode;
        public String cashier;
        public String amount;
        public String count;
        public String disamount;
        public String createdate;
        public String updatedate;
        public String state;
        public DataTable list;
        public DataTable accountlist;
        
    }
}
