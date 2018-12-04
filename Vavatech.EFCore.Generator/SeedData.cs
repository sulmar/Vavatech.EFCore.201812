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


        public static IList<Product> GetProducts(int count)
        {
            ProductFaker productFaker = new ProductFaker();
            return productFaker.Generate(count);
        
        }
    }
}
