using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.ConsoleClient.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
               .HasKey(p => p.Id);

            builder
                .Property(p => p.FirstName)
                // .IsConcurrencyToken()   // token współbieżności
                .HasMaxLength(50);

            builder
                .Property(p => p.LastName)
                // .IsConcurrencyToken()
                .HasMaxLength(50)
                .IsRequired();


            builder
                .Property(p => p.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        }
    }
}
