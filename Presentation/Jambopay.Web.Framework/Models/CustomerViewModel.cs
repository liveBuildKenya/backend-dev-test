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
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the ambassador id
        /// </summary>
        public int AmbassadorId { get; internal set; }
        public string Token { get; internal set; }
        public bool PasswordValid { get; internal set; }
    }
}
