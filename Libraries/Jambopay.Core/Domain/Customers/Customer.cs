using System;

namespace Jambopay.Core.Domain.Customers
{
    /// <summary>
    /// Represents a Customer
    /// </summary>
    public class Customer : BaseEntity
    {
        public Customer()
        {
            CustomerGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the customer GUID
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }
    }
}
