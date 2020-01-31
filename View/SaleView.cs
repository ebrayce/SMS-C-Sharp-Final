using SMS.Controller;
using SMS.Helpers;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.View
{
    class SaleView
    {
        public static void saveSale(IList<SellItem> sellItems,double GrandTotal)
        {
            Sale sale = new Sale();
            sale.Total = GrandTotal;
            sale.Date = DateTime.Now;
            //sale = SaleController.createSale(sale);

            List<SaleItem> saleItems = new List<SaleItem>();

            foreach (SellItem sellItem in sellItems)
            {
                SaleItem item = new SaleItem {
                Product = sellItem.Product,
                Quantity = sellItem.QUANTITY,
                Total = sellItem.SUB_TOTAL,
                Sale = sale,
            };
                //item = SaleItemController.createSaleItem(item);

                saleItems.Add(item);

                //sale.Items.Add(item);
            }

            
            sale.Items = saleItems;
            //sale.Total = GrandTotal;
            //sale.Date = DateTime.Now;

            SaleController.createSale(sale);

            //foreach (SellItem item in sellItems)
            //{
            //    item.Product.InStock = item.Product.InStock - item.QUANTITY;
            //    ProductController.updateProduct(item.Product);
            //}

            
            //MessageBox.Show(Convert.ToString(sale.Id));



        }
    }
}
