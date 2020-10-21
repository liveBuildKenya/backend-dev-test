using System.ComponentModel.DataAnnotations;

namespace Jambopay.Web.Framework.Models
{
    public class LoginViewModel
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
    }
}
