using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevFramework.Northwind.Business.Abstract
{
    public interface IProductService
    {
        // Bıu operasyonları Managers Klasörüne bağımlı tutmadan buraya koyuyoruz çünkü (mesela) wcf'yi entegre ettiğimizde
        // sistemi wcf üzerinden de servis edebilecek bir program yazmaktır
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
    }
}
