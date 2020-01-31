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
    class SaleItemController
    {
        public static SaleItem createSaleItem(SaleItem saleItem)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                session.SaveOrUpdate(saleItem);
                //transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return saleItem;

        }
    }
}
