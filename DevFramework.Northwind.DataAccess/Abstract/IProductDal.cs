using DevFramework.Core.DataAccess;
using DevFramework.Nortwind.Entities.ComplexTypes;
using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        // Burada IProductDal'a yani ürüne yeni özellik ekleme imza ekleme gibi işlemleri yapabiliriz
        // mesela join atmak gibi 
        // join işlemi
        // Buraya bunu yazdıktan sonra EfproductDal ve NhProductDal'a uğrayıp bunu implemente ettik
        List<ProductDetail> GetProductDetails();
    }
}
