using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.DbServices.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
               .HasKey(p => p.Id);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();

            // Filtr globalny
            builder
                .HasQueryFilter(p => !p.IsDeleted);

            // Konwerter Enum-String
            //builder.Property(p => p.Gender)
            //    .HasConversion(
            //        value => value.ToString(),
            //        value => (Gender) Enum.Parse(typeof(Gender), value)
            //    );

            // Użycie wbudowanego konwertera (value-conversions)
            // var converter = new EnumToStringConverter<Gender>();

            //builder.Property(p => p.Gender)
            //    .HasConversion(converter);

            builder.Property(p => p.Gender)
                .HasConversion<string>();

            builder.Property(p => p.HomeAddress)
                .HasConversion(
                    value => JsonConvert.SerializeObject(value),
                    value => JsonConvert.DeserializeObject<Address>(value)
                    );
        }
    }
}
