using DevFramework.Nortwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Nhibernate.Mappings  // burayı düzeltmek gerekebilir Nhibernate klasörü için genel olarak
{ 
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap() 
        {
            Table(@"Categories");
            LazyLoad();
            Id(x => x.CategoryId).Column("CategoryId");
            Map(x => x.CategoryName).Column("CategoryName");

        }
    }
}
