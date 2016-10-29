using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MLMPOS.Service.Entity
{
   public class SaleOrder
    {
        private String id;
        private String ordercode;
        private String shopcode;
        private String poscode;
        private String cashier;
        private String amount;
        private String count;
        private String disamount;
        private String createdate;
        private String updatedate;
        private String state;
        private DataTable list;
        private DataTable accountlist;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Ordercode
        {
            get
            {
                return ordercode;
            }

            set
            {
                ordercode = value;
            }
        }

        public string Shopcode
        {
            get
            {
                return shopcode;
            }

            set
            {
                shopcode = value;
            }
        }

        public string Poscode
        {
            get
            {
                return poscode;
            }

            set
            {
                poscode = value;
            }
        }

        public string Cashier
        {
            get
            {
                return cashier;
            }

            set
            {
                cashier = value;
            }
        }

        public string Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public string Disamount
        {
            get
            {
                return disamount;
            }

            set
            {
                disamount = value;
            }
        }

        public string Createdate
        {
            get
            {
                return createdate;
            }

            set
            {
                createdate = value;
            }
        }

        public string Updatedate
        {
            get
            {
                return updatedate;
            }

            set
            {
                updatedate = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public DataTable List
        {
            get
            {
                return list;
            }

            set
            {
                list = value;
            }
        }

        public DataTable Accountlist
        {
            get
            {
                return accountlist;
            }

            set
            {
                accountlist = value;
            }
        }
    }
}
