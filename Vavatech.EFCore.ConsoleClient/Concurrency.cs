using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vavatech.EFCore.ConsoleClient
{
    class Concurrency
    {
        public static void Test()
        {
            ConcurrencyTest();
        }

        private static void ConcurrencyTest()
        {
            using (var context1 = new MyContext())
            using (var context2 = new MyContext())
            {
                var customer1 = context1.Customers.First();
                customer1.FirstName = "Marcin";


                var customer2 = context2.Customers.First();
                customer2.FirstName = "Bartek";
                context2.SaveChanges();

                try
                {
                    context1.SaveChanges();
                }
                catch(DbUpdateConcurrencyException e)
                {
                    Console.WriteLine("Wystąpił konflikt!");
                }
            }
        }
    }
}
