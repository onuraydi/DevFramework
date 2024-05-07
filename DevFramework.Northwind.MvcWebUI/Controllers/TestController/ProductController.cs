using DevFramework.Northwind.Business.Abstract;
using DevFramework.Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }
        
        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductID = 19,
                ProductName = "Test",
                QuantityPerUnit = "test2",
                UnitPrice = 25000
            });
            return "Added!";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductID = 19,
                ProductName = "Test",
                QuantityPerUnit = "test",
                UnitPrice = 25000
            },new Product
            {
                CategoryId = 1,
                ProductID = 19,
                ProductName = "Test2",
                QuantityPerUnit = "test2",
                UnitPrice = 25000
            });
            return "Done";
        }
    }
}