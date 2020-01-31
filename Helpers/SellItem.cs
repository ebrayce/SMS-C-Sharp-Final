using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Helpers
{
    class SellItem
    {
        public int ID { get; set; }
        public String NAME { get; set; }
        public double UNIT_PRICE { get; set; }
        public double SUB_TOTAL { get; set; }
        public int QUANTITY { get; set; }

        public Product Product { get; set; }
        public SellItem(int iD, string nAME, double uNIT_PRICE, int qUANTITY,double sub_Total,Product product)
        {
            ID = iD;
            NAME = nAME;
            UNIT_PRICE = uNIT_PRICE;
            QUANTITY = qUANTITY;
            SUB_TOTAL = sub_Total;
            Product = product;
        }




    }
}
