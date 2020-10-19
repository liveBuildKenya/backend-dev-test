namespace Jambopay.Core.Domain.Services
{
    /// <summary>
    /// Represents a service for payment
    /// </summary>
    public class Service : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ambassador commission rate
        /// </summary>
        public decimal AmbassadorCommissionRate { get; set; }
    }
}
