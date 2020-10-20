using Jambopay.Core.Domain.CommissionWithdrawals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Jambopay.Data.Mappings.CommissionWithdrawals
{
    /// <summary>
    /// Represents the commission withdrawal map
    /// </summary>
    public class CommissionWithdrawalMap : IEntityTypeConfiguration<CommissionWithdrawal>
    {
        public void Configure(EntityTypeBuilder<CommissionWithdrawal> builder)
        {
            builder.ToTable(nameof(CommissionWithdrawal));
            builder.HasKey(commissionWithdrawal => commissionWithdrawal.Id);
            builder.Property(commissionWithdrawal => commissionWithdrawal.CreatedOn).HasDefaultValue(DateTime.UtcNow);
        }
    }
}
