using Jambopay.Core.Domain.ServiceTransactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Jambopay.Data.Mappings.ServiceTransactions
{
    /// <summary>
    /// Represents a service transaction
    /// </summary>
    public class ServiceTransactionsMap : IEntityTypeConfiguration<ServiceTransaction>
    {
        public void Configure(EntityTypeBuilder<ServiceTransaction> builder)
        {
            builder.ToTable(nameof(ServiceTransaction));
            builder.HasKey(serviceTransaction => serviceTransaction.Id);
        }
    }
}
