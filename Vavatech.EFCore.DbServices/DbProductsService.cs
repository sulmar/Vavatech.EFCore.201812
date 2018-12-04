using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.EFCore.IServices;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.DbServices
{
    public class DbProductsService : IProductsService
    {
        private ShopContext context;

        public DbProductsService(ShopContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            // context.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = new Product { Id = id };
            context.Attach(product);
            context.Remove(product);
            context.SaveChanges();

           // context.Products.Remove(Get(id));
        }

        public IList<Product> Get()
        {
            return context.Products.ToList();
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
