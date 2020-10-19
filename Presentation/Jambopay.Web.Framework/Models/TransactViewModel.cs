using System.ComponentModel.DataAnnotations;

namespace Jambopay.Web.Framework.Models
{
    /// <summary>
    /// Represents the transact view model
    /// </summary>
    public class TransactViewModel
    {
        /// <summary>
        /// Gets or sets the service identifier
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the supporter identifier
        /// </summary>
        public int SupporterId { get; set; }

        /// <summary>
        /// Gets or sets the amount
        /// </summary>
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage ="Amount may contain up to two decimal places")]
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers accepted")]
        public decimal Amount { get; set; }
    }
}
