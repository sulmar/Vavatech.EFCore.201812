using Bogus;
using System;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.Generator
{

    // PM> Install-Package Bogus
    public class CustomerFaker : Faker<Customer>
    {
        // ctor
        public CustomerFaker()
        {
            Ignore(p => p.Id);
            RuleFor(p => p.FirstName, f => f.Name.FirstName());
            RuleFor(p => p.LastName, f => f.Name.LastName());
            RuleFor(p => p.Gender, f => f.PickRandom<Gender>());
            RuleFor(p => p.IsDeleted, f => f.Random.Bool(0.8f));

            FinishWith((f, customer) 
                => Console.WriteLine($"Customer was created {customer.FirstName} {customer.LastName}"));

        }
    }
}
