using DevFramework.Core.DataAccess.Nhibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Nhibernate.Helpers
{
    // bizim enjekte edeceğimiz nesne NhibernateHelper'dan türediği için sqlserverhelper'i bundan türettik
    public class SqlServerHelper : NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()  //referanclarla ilgili sıkıntı çıkabilir
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012   //burada da sıkıntı çıkabilir
                .ConnectionString(C=>C.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t=>t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).BuildSessionFactory();  
                // bu kısım için DataAccess kısmına fluentNhibernate adında paket kuruldu
        }
    }
}
