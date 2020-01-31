using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Helpers
{
    class HibernateHelper
    {
        private static Configuration getConfiguration()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly("SMS");

            new SchemaUpdate(cfg).Execute(true, true);
            return cfg;
        }




        public static ISessionFactory GetSessionFactory()
        {
            ISessionFactory sessionFactory = getConfiguration().BuildSessionFactory();
            return sessionFactory;
        }
        
    }
}
