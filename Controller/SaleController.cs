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
    class SaleController
    {
        public static Sale createSale(Sale sale)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                session.SaveOrUpdate(sale);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return sale;

        }


    }
}
