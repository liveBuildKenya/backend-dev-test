using Jambopay.Core.Domain.Customers;

namespace Jambopay.Web.Framework.Models
{
    /// <summary>
    /// Represents the transact response view model
    /// </summary>
    public class TransactResponseViewModel
    {
        /// <summary>
        /// Gets or sets the service paid
        /// </summary>
        public string ServicePaid { get; set; }

        /// <summary>
        /// Gets or sets the amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the person that paid the service
        /// </summary>
        public string PaidBy { get; set; }

        /// <summary>
        /// Gets or sets the name of person paid the commission
        /// </summary>
        public string CommissionPaidTo { get; internal set; }
    }
}
