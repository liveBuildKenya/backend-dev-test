using Jambopay.Core.Domain.Services;
using Jambopay.Core.Domain.ServiceTransactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Jambopay.Data.Mappings.Services
{
    /// <summary>
    /// Represents a service
    /// </summary>
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(nameof(Service));
            builder.HasKey(service => service.Id);
            builder.Property(service => service.Name).IsRequired();

            builder.HasMany<ServiceTransaction>()
                .WithOne()
                .HasForeignKey(serviceTransaction => serviceTransaction.ServiceId);
        }
    }
}
