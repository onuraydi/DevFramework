using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Nortwind.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DevFramework.Business.Tests
{
    //Burada Product manager'ı test ederken newlersek içine ıProductDal'Da göndermek zorundayız ancak bu entegrasyon
    // testine girer. o yüzden Moq framework'ü kullanıyoruz
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))] // bir hata beklediğimiz için 
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product()); // validation hatası vermeli çünkü tanımladığımız kurallara göre bir ürün 
                                                // göndermiyoruz yani bu testten bilinçli olarak bir hata bekliyoruz

            // Tabi beklediğimiz hatayı söylediğimiz için program testten geçecektir
        }
    }
}
