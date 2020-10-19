using Jambopay.Core.Domain.Affiliates;
using Jambopay.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Jambopay.Data.Mappings.Affiliates
{
    /// <summary>
    /// Represents an affiliate map
    /// </summary>
    public class AffiliateMap : IEntityTypeConfiguration<Affiliate>
    {
        public void Configure(EntityTypeBuilder<Affiliate> builder)
        {
            builder.ToTable(nameof(Affiliate));
            builder.HasKey(affiliate => affiliate.Id);
            builder.Property(affiliate => affiliate.CreatedOn).HasDefaultValue(DateTime.UtcNow);
            builder.HasOne<Customer>()
                .WithOne()
                .HasForeignKey<Affiliate>(affiliate => affiliate.CustomerId);
        }
    }
}
