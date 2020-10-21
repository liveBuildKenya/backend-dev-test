using System.ComponentModel.DataAnnotations;

namespace Jambopay.Web.Framework.Models
{
    /// <summary>
    /// Represents register ambassador view model
    /// </summary>
    public class RegisterAmbassadorViewModel
    {
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        [Required]
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
