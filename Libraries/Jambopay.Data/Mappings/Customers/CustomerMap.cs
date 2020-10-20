using Jambopay.Core.Domain.CommissionWithdrawals;
using Jambopay.Core.Domain.Customers;
using Jambopay.Core.Domain.ServiceTransactions;
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

            builder.HasMany<ServiceTransaction>()
                .WithOne()
                .HasForeignKey(serviceTransaction => serviceTransaction.SupporterId);

            builder.HasMany<ServiceTransaction>()
                .WithOne()
                .HasForeignKey(serviceTransaction => serviceTransaction.AmbassadorId);

            builder.HasMany<CommissionWithdrawal>()
                .WithOne()
                .HasForeignKey(commissionWithdrawal => commissionWithdrawal.CustomerId);
        }
    }
}
