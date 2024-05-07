using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.Nhibernate;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.Nhibernate;
using DevFramework.Northwind.DataAccess.Nhibernate.Helpers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{

    //ARayüz bu sınıf vasitası ile iletişime geçecektir
    public class BusinessModule : NinjectModule // bu classtan inharite ettik soyut bir classtır
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();  // bu normalde her aramada newlenir
                                                                              // biz bunu InSingletonScope yaparak
                                                                              // performans artışı sağladık
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();  // entityFramework ile çalıştığımız için bunu kullandık
                                                     // daha sonra başka teknolojiye geçerken burayı değiştirmeliyiz


            // core katmanında query tanımlamıştık onu kullanmıyoruz ancak olurda kullanmak istersek diye bir 
            // bind işlemi de onun için yapalım

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();

            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
