using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.EFCore.Generator;
using Vavatech.EFCore.IServices;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.FakeServices
{
    public class FakeProductsService : IProductsService
    {
        private IList<Product> products;

        public FakeProductsService()
        {
            products = SeedData.GetProducts(50);
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Delete(int id)
        {
            products.Remove(Get(id));
        }

        public IList<Product> Get()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.SingleOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
