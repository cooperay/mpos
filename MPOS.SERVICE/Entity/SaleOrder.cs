using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLMPOS.Service.Entity
{
   public class SaleOrder
    {
        private String id;
        private String ordercode;
        private String shopcode;
        private String cashier;
        private Decimal amount;
        private Decimal count;
        private Decimal disamount;
        private DateTime createdate;
        private DateTime updatedate;
        private Boolean issync;

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

        public decimal Amount
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

        public decimal Count
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

        public decimal Disamount
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

        public DateTime Createdate
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

        public DateTime Updatedate
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

        public bool Issync
        {
            get
            {
                return issync;
            }

            set
            {
                issync = value;
            }
        }
    }
}
