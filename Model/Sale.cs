using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Model
{
    public class Sale
    {
        public virtual Guid Id { get; set; }
        public virtual  double Total { get; set; }

        public virtual DateTime Date { get; set; }
        public virtual IList<SaleItem> Items  { get; set; }



       
    }
}
