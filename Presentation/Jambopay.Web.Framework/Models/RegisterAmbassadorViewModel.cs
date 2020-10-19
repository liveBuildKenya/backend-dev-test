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
        [EmailAddress]
        public string Email { get; set; }
    }
}
