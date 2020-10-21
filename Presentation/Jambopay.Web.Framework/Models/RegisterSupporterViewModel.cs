using System.ComponentModel.DataAnnotations;

namespace Jambopay.Web.Framework.Models
{
    /// <summary>
    /// Register supporter view model
    /// </summary>
    public class RegisterSupporterViewModel
    {
        /// <summary>
        /// Gets or sets the ambassador identifier
        /// </summary>
        public int AmbassadorId { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }


        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
