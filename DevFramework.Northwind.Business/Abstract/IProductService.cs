using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace DevFramework.Northwind.Business.Abstract
{
    [ServiceContract]
    public interface IProductService
    {
        // Bıu operasyonları Managers Klasörüne bağımlı tutmadan buraya koyuyoruz çünkü (mesela) wcf'yi entegre ettiğimizde
        // sistemi wcf üzerinden de servis edebilecek bir program yazmaktır
        [OperationContract]
        List<Product> GetAll();
        [OperationContract]
        Product GetById(int id);
        [OperationContract]
        Product Add(Product product);
        [OperationContract]
        Product Update(Product product);


        // Bu kısım ninject'ten sonra yazıldı
        [OperationContract]
        void TransactionalOperation(Product product1, Product product2);
    }
}
