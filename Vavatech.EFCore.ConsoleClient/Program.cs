using Microsoft.EntityFrameworkCore;
using System;
using Vavatech.EFCore.Generator;

namespace Vavatech.EFCore.ConsoleClient
{
    class Program
    {
        delegate void Print(string message);

        private static void SendSms(string content)
        {
            Console.WriteLine(content);
        }

        private static void SendEmail(string body)
        {
            Console.WriteLine(body);
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World");

           // Tasks.Test();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();


            DropAndCreateDatabase();

            Concurrency.Test();

            Transactions.Test();

            RawSqlQueries.Test();

            // DelegatesTest();

            //Display(customers);

           

            Querying.Test();

            Saving.Test();



            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

        private static void DropAndCreateDatabase()
        {
            MyContext context = new MyContext();
           // context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            context.Database.Migrate();


            //context.Customers.AddRange(SeedData.GetCustomers(100));
            //context.Products.AddRange(SeedData.GetProducts(50));
            //context.SaveChanges();
        }

        private static void DelegatesTest()
        {
            Print print = SendSms;
            print += SendEmail;
            print += delegate (string input)
            {
                Console.WriteLine(input);
            };

            print += input => Console.WriteLine(input);

            print("Hello .NET Core");
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
