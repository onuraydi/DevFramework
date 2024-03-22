using DevFramework.Northwind.DataAccess.Concrete.Nhibernate;
using DevFramework.Northwind.DataAccess.Nhibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.DataAccess.Tests.Nhibernate.Tests
{
    [TestClass]
    public class NhibernateTest
    {
        [TestMethod]
        public void Get_All_Returns_All_Products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetAll();

            Assert.AreEqual(78, result.Count);
        }

        [TestMethod]

        public void Get_All_with_Parameter_Returns_Filtered_Products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetAll(p=> p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
