using DevFramework.Nortwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Nhibernate.Mappings  // burayı düzeltmek gerekebilir Nhibernate klasörü için genel olarak
{ 
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap() 
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.ProductID).Column("ProductID");
            Map(x => x.CategoryId).Column("CategoryId");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");

        }
    }
}
