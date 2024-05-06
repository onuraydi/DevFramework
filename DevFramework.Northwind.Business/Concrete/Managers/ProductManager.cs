using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Nortwind.Entities.Concrete;
using PostSharp.Aspects.Dependencies;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DatabaseLogger = DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger.DatabaseLogger;

// Not Bu clasın içinde diyelimki efProductDal clasını newleyeceğiz ancak bunu newlemek şeklinde yaparsak programı
// EntityFramework'e bağlamış oluruz daha sonra başka bir teknoloji ile çalışacağımız zaman bu olay bizim başka teknolojiye
// geçme işimizi zorlaştıracaktır.
// Dolayısıyla böyle bir iletişim kuracaksak alt katmanın abstract nesneleri ile iletişim kurmalıyız

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productdal;

        public ProductManager(IProductDal productdal)  // Buraya gerekirse IQueryable ekleyebiliriz core katmanında oluşturmuştuk
        {
            _productdal = productdal;
        }

        // birbirini çok ekleyen ortamlar varsa bu ortamlarda cacheremoveaspect'e fazlaca ihtiyaç duyarız 
        // çünkü bizim için önemli derece performans artışı sağlar
        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {

            return _productdal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]    // Bizim için önemli bir metot olduğu için bunu bu şekilde kullandık ve parametreyi
        // daha da azalttık bu özel kullanıma örnektir.
        [SecuredOperation(Roles ="Admin,Editor")]  // bu metoda sadece admin rolüne sahip kişiler erişebilir.
        public List<Product> GetAll()
        {
            
            return _productdal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productdal.Get(p => p.ProductID == id);
        }
        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidatior))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productdal.Add(product1);
            // busines codes
            _productdal.Update(product2);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
 
            return _productdal.Update(product);
        }
    }
}
