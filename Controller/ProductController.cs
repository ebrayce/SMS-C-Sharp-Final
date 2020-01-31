using NHibernate;
using SMS.Helpers;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controller
{
    class ProductController : Product
    {
        public static Product createProduct(Product product)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                session.Save(product);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return product;

        }

        public static Product updateProduct(Product product)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                session.Update(product);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return product;

        }

        public static Product deleteProduct(Product product)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                session.Delete(product);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return product;

        }


        public static IList<Product> listOfAllProduct()
        {
            IList<Product> products;
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                products =  session.CreateCriteria<Product>().List<Product>();

               
            }
            finally
            {
                session.Close();
            }
            return products;
        }
    }
}
