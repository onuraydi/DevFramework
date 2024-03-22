using DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings;
using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

// Entity Framework kuruldu
// code first tekniği ile yaptık // önce kod sonra veritabanı bağlantısı
namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);  // hata vermemesi için parametre olarak null geçtik
        }

        public DbSet<Product> Products { get; set; }
        //biz burada products için oluşturduk. Diğer nesneler için de oluşturmak istersek ekleyebiliriz
        public DbSet<Category> Categories { get; set; }


        // bu kısım mapping işlemi yazıldıktan sonra yazıldı
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}
