using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.EFCore.DbServices.Configurations;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.DbServices
{
    // PM> Install-Package Microsoft.EntityFrameworkCore
    public class ShopContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
             : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
             .ApplyConfiguration(new CustomerConfiguration())
             .ApplyConfiguration(new OrderConfiguration());
        }
    }
}
