using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// EntityRepository -> IProductDal -> product 
// EntityRepository'ye Where koşulu yazdık o yüzden bu'nu IEntity'den implemente etmeliyiz.

// Bu kısım Veritabanındaki tablolara göre oluşturulacak
// Bunları elle yazmak yerine Code generator yazabiliriz ya da hazır Reverse Engineer Tools'lar var onları kullanabiliriz.
// EntityFramwork için powertools diye birşey var
namespace DevFramework.Nortwind.Entities.Concrete
{
    public class Product:IEntity
    {
        public virtual int ProductID { get; set; }
        public virtual string ProductName { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string QuantityPerUnit { get; set; }
        public virtual Decimal UnitPrice { get; set; }
    }
}
