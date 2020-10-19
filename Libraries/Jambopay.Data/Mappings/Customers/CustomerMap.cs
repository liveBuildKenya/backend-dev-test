using Jambopay.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Jambopay.Data.Mappings.Customers
{
    /// <summary>
    /// Represents a customer map
    /// </summary>
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.CreatedOn).HasDefaultValue(DateTime.UtcNow);
            builder.Property(customer => customer.Email).IsRequired();
        }
    }
}
