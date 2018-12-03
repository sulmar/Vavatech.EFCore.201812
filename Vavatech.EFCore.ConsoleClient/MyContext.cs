using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.EFCore.ConsoleClient.Configurations;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.ConsoleClient
{
    // PM: Install-Package Microsoft.EntityFrameworkCore
    // CLI: dotnet add package Microsoft.EntityFrameworkCore
    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        
        public MyContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // PM: Install-Package  Microsoft.EntityFrameworkCore.Sqlite
            //string connectionString = "Filename=./mydb.sqlite";
            //optionsBuilder.UseSqlite(connectionString);

            // PM: Install-Package Microsoft.EntityFrameworkCore.SqlServer

            string connectionString = "Server=(local)\\SQLEXPRESS;Database=mydb;Integrated Security=true";
            optionsBuilder.UseSqlServer(connectionString);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja Fluent Api
            modelBuilder
                .ApplyConfiguration(new CustomerConfiguration())
                .ApplyConfiguration(new OrderConfiguration());
          

        }
    }
}
