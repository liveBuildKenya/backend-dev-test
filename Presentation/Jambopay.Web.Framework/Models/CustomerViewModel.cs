using System;

namespace Jambopay.Web.Framework.Models
{
    /// <summary>
    /// Represents the customer view model
    /// </summary>
    public class CustomerViewModel: BaseEntityViewModel
    {
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the customer guid
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the affiliate identifier
        /// </summary>
        public int AffiliateId { get; set; }
    }
}
