using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.Generator
{
    public class SeedData
    {

        public static IList<Customer> GetCustomers(int count)
        {
            CustomerFaker customerFaker = new CustomerFaker();

            return customerFaker.Generate(count);
        }
    }
}
