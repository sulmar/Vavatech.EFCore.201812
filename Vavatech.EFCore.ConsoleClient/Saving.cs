using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vavatech.EFCore.Generator;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.ConsoleClient
{
    class Saving
    {

        public static void Test()
        {
            AddOrderTest();

            AddTest();

            UpdateTest();
        }

        private static void AddOrderTest()
        {
            using (var context = new MyContext())
            {
                Customer customer = context.Customers.Find(1);
                Product product1 = context.Products.Find(1);
                Product product2 = context.Products.Find(20);

                Order order = new Order
                {
                    OrderNumber = "ZAM 001",
                    Customer = customer,
                };

                var orderDetail1 = new OrderDetail
                {
                    Product = product1,
                    Quantity = 10,
                    UnitPrice = 9.99m
                };

                var orderDetail2 = new OrderDetail
                {
                    Product = product2,
                    Quantity = 5,
                    UnitPrice = 100m
                };

                order.Details.Add(orderDetail1);
                order.Details.Add(orderDetail2);

                context.Orders.Add(order);

                var entries = context.ChangeTracker.Entries()
                    .Select(e => new { e.Entity, e.State })
                    .ToList();
                    ;

                context.SaveChanges();


            }
            
        }

        private static void UpdateTest()
        {
            Customer customer1;

            using (MyContext context1 = new MyContext())
            {
                customer1 = context1.Customers.First();
                customer1.FirstName = "Marcin";
            }

            Customer customer2 = new Customer
            {
                Id = customer1.Id,
                FirstName = customer1.FirstName,
                LastName = customer1.LastName,
                Gender = customer1.Gender,
                IsDeleted = customer1.IsDeleted
            };


            using (MyContext context2 = new MyContext())
            {
                customer2.Id = 9999;

                Console.WriteLine(context2.Entry(customer2).State);

                //context2.Attach(customer2);
                //context2.Entry(customer2).State = EntityState.Modified;

                context2.Update(customer2);

                Console.WriteLine(context2.Entry(customer2).State);

                context2.SaveChanges();

                Console.WriteLine(context2.Entry(customer2).State);
            }
        }

        private static void AddTest()
        {
            Customer customer = SeedData.GetCustomers(1).Single();

            using (MyContext context = new MyContext())
            {
                Console.WriteLine(context.Entry(customer).State);

                context.Customers.Add(customer);

                Console.WriteLine(context.Entry(customer).State);

                context.SaveChanges();

                Console.WriteLine(context.Entry(customer).State);

                customer.IsDeleted = !customer.IsDeleted;

                Console.WriteLine(context.Entry(customer).State);

                context.SaveChanges();

                Console.WriteLine(context.Entry(customer).State);

                customer.FirstName = "Marcin";

                context.Entry(customer).State = EntityState.Unchanged;

                Console.WriteLine(context.Entry(customer).State);

                context.SaveChanges();


            }

        }
    }
}
