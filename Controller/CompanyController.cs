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
    class CompanyController
    {
        public static Company createCompany(Company model)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(model);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return model;

        }
        public static IList<Company> listOfAllCompany()
        {
            IList<Company> model;
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                model = session.CreateCriteria<Company>().List<Company>();

            }
            finally
            {
                session.Close();
            }

            return model;
        }

        public static Company updateCompany(Company model)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                session.Update(model);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return model;

        }

        //public static User deleteUser(User user)
        //{
        //    ISession session = HibernateHelper.GetSessionFactory().OpenSession();
        //    ITransaction transaction = session.BeginTransaction();
        //    try
        //    {

        //        session.Delete(user);
        //        transaction.Commit();
        //    }
        //    finally
        //    {
        //        session.Close();
        //    }

        //    return user;

        //}


    }
}
