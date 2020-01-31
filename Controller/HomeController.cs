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
    class HomeController : HibernateHelper
    {
        public  static User logIn(String username,String password)
        {
            User user;
            ISession session = HibernateHelper.GetSessionFactory().OpenSession();
            ITransaction transaction = session.BeginTransaction();

            user = (User) session.CreateQuery("From User u where u.Username = :username and u.Password = :password").SetParameter("username",username).SetParameter("password",password).UniqueResult();
            
            if(user != null )
            {
                
                    Console.WriteLine("Password Match " + user.Password);
                    return user;
                
                
            }
            
                user = null;
                return user;
            
            
        }
    }
}
