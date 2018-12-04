using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.ConsoleClient
{
    class Querying
    {
        public static void Test()
        {
            AnyTest();

            // ZipTest();

            GroupByTest();

            SelectTest();

            FilterTest();
        }

        private static void AnyTest()
        {
            MyContext context = new MyContext();

            bool result = context.Customers
                            .All(c => c.Gender == Gender.Man);


            bool woman = context.Customers
                            .Any(c => c.Gender == Gender.Female);

            // zła praktyka
            //if (context.Customers.Count()>0)
            //{

            //}

            // dobra praktyka
            if (context.Customers.Any())
            {

            }

        }

        private static void ZipTest()
        {
            throw new NotImplementedException();
        }

        private static void ExtensionMethodsTest()
        {
            MyContext context = new MyContext();

            var customers = context.Customers
                    .Where(c => c.IsDeleted)
                    .OrderBy(c => c.FirstName)
                    .ThenBy( c => c.LastName)
                    .ToList();
        }

        private static void ExpressionTest()
        {
            MyContext context = new MyContext();

            var customers = (from c in context.Customers
                            where c.IsDeleted
                            orderby c.FirstName, c.LastName
                            select c).ToList();
        }


        private static void GroupByTest()
        {
            MyContext context = new MyContext();

            var customers = context.Customers
                .GroupBy(c => c.Gender)
                .Select(g => new { Gender = g.Key, Qty = g.Count()})
                .ToList();
        }

        private static void SelectTest()
        {
            MyContext context = new MyContext();
            var customers = context.Customers.ToList();

            Display(customers);
        }

        private static void NoLinqTest()
        {
            MyContext context = new MyContext();

            var customers = context.Customers
                .ToList();

            var results = new List<Customer>();

            foreach (var customer in customers)
            {
                if (!customer.IsDeleted)
                {
                    results.Add(customer);
                }
            }



            Display(customers);
        }

        private static void FilterTest()
        {
            bool isSorted = false;

            MyContext context = new MyContext();

            //List<Customer> customers = context.Customers
            //    .Where(customer => !customer.IsDeleted)
            //    .ToList();

            // Wyrażenie (Expression)
            IQueryable<Customer> query = context.Customers
               .Where(customer => !customer.IsDeleted);
               
            if (isSorted)
            {
                query = query
                    .OrderBy(customer => customer.FirstName)
                    .ThenBy(customer => customer.LastName)
                    ;
            }

            // Materializacja
            List<Customer> customers = query.ToList();


            Display(customers);
        }


        // http://www.albahari.com/nutshell/predicatebuilder.aspx
        private static void DynamicQuery(string field)
        {

        }

        private static bool IsFilter(Customer bla)
        {
            return !bla.IsDeleted;
        }

        private static void Display(List<Models.Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
        }
    }
}
