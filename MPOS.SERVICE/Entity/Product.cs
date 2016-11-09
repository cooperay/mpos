using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPOS.SERVICE.Entity
{
    class Product
    {
        private Int32 id;
        private String barcode;
        private String name;
        private String spec;
        private String unit;
        private String tintype;
        private String midtype;
        private String bigtype;
        private String classtype;
        private String depttype;
        private Decimal price;

        public int Id
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

        public string Barcode
        {
            get
            {
                return barcode;
            }

            set
            {
                barcode = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Spec
        {
            get
            {
                return spec;
            }

            set
            {
                spec = value;
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

        public string Tintype
        {
            get
            {
                return tintype;
            }

            set
            {
                tintype = value;
            }
        }

        public string Midtype
        {
            get
            {
                return midtype;
            }

            set
            {
                midtype = value;
            }
        }

        public string Bigtype
        {
            get
            {
                return bigtype;
            }

            set
            {
                bigtype = value;
            }
        }

        public string Classtype
        {
            get
            {
                return classtype;
            }

            set
            {
                classtype = value;
            }
        }

        public string Depttype
        {
            get
            {
                return depttype;
            }

            set
            {
                depttype = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }
}
