using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

// mapping işlemi veritabanı ve nesnemizin bağlantısını sağlar.Daha doğrusu karşılaştırılmasını ilişkilendirilmesini
// sağlar. veritabanı nesneleri ile oluşturduğumuz nesnelerin adı aynı ise gerek yoktur. ancak Defensive programming
// için kullanmak daha iyi olur.

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", "dbo"); // veritabanı tablo adı ve uzantısı
            HasKey(x => x.ProductID);

            Property(x => x.ProductID).HasColumnName("ProductID");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");
            // isimler değiştiğinde bu bizi kurtaracaktır
        }
    }
}
