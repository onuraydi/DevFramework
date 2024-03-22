using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.DataAccess.Tests.EntityFramework.Tests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_All_Returns_All_Products()
        {
            EfProductDal productDal = new EfProductDal();  // normal şartlarda newleme yapılmaz (kodun kalitesi için)
                                                           // ancak şuan test yaptığımız için yaptık
            var result = productDal.GetAll();

            Assert.AreEqual(78, result.Count);
        }

        [TestMethod]

        public void Get_All_With_Parameter_Returns_Filtered_Products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetAll(p=> p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
