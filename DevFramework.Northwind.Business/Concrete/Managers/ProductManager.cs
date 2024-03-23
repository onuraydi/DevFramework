using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.CrossCutiingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Add(Product product)
        {

            return _productdal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productdal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productdal.Get(p => p.ProductID == id);
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
 
            return _productdal.Update(product);
        }
    }
}
