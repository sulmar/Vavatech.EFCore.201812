using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task AddAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
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
            // return context.Products.ToList();

            // wyłączenie filtru globalnego
            return context.Products
                .IgnoreQueryFilters()
                .ToList();
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public async Task<IList<Product>> GetAsync()
        {
            return await context.Products.ToListAsync();
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
