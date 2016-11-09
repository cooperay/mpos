using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPOS.SERVICE.Entity
{
    public class Account
    {
        private String id;
        private String ordercode;
        private String type;
        private DateTime date;

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

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
    }
}
