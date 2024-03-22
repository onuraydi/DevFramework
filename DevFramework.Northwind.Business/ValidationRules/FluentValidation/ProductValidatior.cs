using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nortwind.Entities.Concrete;
using FluentValidation;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior:AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p=> p.ProductID).NotEmpty();
            RuleFor(p=> p.ProductName).Length(2,25);
            RuleFor(p=> p.QuantityPerUnit).NotEmpty();
            RuleFor(p=> p.UnitPrice).GreaterThan(0);

        }
    }
}
