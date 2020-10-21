namespace Jambopay.Core.Domain.ServiceTransactions
{
    /// <summary>
    /// Represents a service transaction
    /// </summary>
    public class ServiceTransaction : BaseEntity
    {
        /// <summary>
        /// Gets or sets the supporter identifier
        /// </summary>
        public int SupporterId { get; set; }

        /// <summary>
        /// Gets or sets the ambassador identifier
        /// </summary>
        public int AmbassadorId { get; set; }

        /// <summary>
        /// Gets or sets the service identifier
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the amount
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Gets or sets the commission amount
        /// </summary>
        public string CommissionAmount { get; set; }
    }
}
