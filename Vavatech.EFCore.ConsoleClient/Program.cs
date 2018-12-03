using System;
using Vavatech.EFCore.Generator;

namespace Vavatech.EFCore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var customers = SeedData.GetCustomers(100);

            Display(customers);

            MyContext context = new MyContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Customers.AddRange(customers);
            context.SaveChanges();


            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

        private static void Display(System.Collections.Generic.IList<Models.Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
        }
    }
}
