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


            Print print;

            print = SendSms;
            print += SendEmail;
            print += delegate (string input)
            {
                Console.WriteLine(input);
            };

            print += input => Console.WriteLine(input);

            print("Hello .NET Core");



            

            //var customers = SeedData.GetCustomers(100);

            //Display(customers);

            //MyContext context = new MyContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //context.Customers.AddRange(customers);
            //context.SaveChanges();

            Querying.Test();


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
