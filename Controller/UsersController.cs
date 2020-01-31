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
    class UsersController
    {
        public static User createUser(User user)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(user);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return user;

        }
        public static IList<User> listOfAllUser()
        {
            IList<User> users;
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                users = session.CreateCriteria<User>().List<User>();

            }
            finally
            {
                session.Close();
            }
            return users;
        }

        public static User updateUser(User user)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                session.Update(user);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return user;

        }

        public static User deleteUser(User user)
        {
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {

                session.Delete(user);
                transaction.Commit();
            }
            finally
            {
                session.Close();
            }

            return user;

        }


    }
}
