using Jambopay.Core.Domain.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jambopay.Web.Framework.Models
{
    /// <summary>
    /// Represents the create transaction view model
    /// </summary>
    public class CreateTransactionViewModel
    {
        /// <summary>
        /// Gets or sets the available service
        /// </summary>
        public IList<Service> AvailableService { get; set; }

        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the supporter email
        /// </summary>
        public string SupporterEmail { get; set; }

        /// <summary>
        /// Gets or sets the amount
        /// </summary>
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage ="Amount may contain up to two decimal places")]
        [Range(0, double.MaxValue, ErrorMessage = "Only positive numbers accepted")]
        public decimal Amount { get; set; }
    }
}
