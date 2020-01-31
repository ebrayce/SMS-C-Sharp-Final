using SMS.Controller;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.View
{
    class ProductView 
    {

        public static Product addProductView(String name, double price, int inStock,int minStock)
        {

            Product product = new Product
            {
                Name = name,
                Price = price,
                InStock = inStock,
                MinStock = minStock,
                BelowMinStock = inStock < minStock
            };

            product = ProductController.createProduct(product);

            return product;


        }

    }
}
