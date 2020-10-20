namespace Jambopay.Core.Domain.CommissionWithdrawals
{
    /// <summary>
    /// Represents a commission withdrawal
    /// </summary>
    public class CommissionWithdrawal : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the amount
        /// </summary>
        public decimal Amount { get; set; }
    }
}
