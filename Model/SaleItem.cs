using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model
{
    public class SaleItem
    {
        public virtual Guid Id { get; set; }
        public virtual double Total { get; set; }

        public virtual Product Product { get; set; }

        public virtual Sale Sale { get; set; }

        public virtual  int Quantity { get; set; }

        

    }
}
