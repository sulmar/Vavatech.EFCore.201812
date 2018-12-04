using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.Generator
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            Ignore(p => p.Id);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()));

            FinishWith((f, p) 
                => Console.WriteLine($"Product created {p.Name} {p.UnitPrice}"));
        }
    }
}
