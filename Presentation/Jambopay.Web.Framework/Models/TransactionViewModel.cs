namespace Jambopay.Web.Framework.Models
{
    /// <summary>
    /// Represents the transactions view model
    /// </summary>
    public class TransactionViewModel
    {
        /// <summary>
        /// Gets or sets the supporters email
        /// </summary>
        public string SupporterEmail { get; set; }

        /// <summary>
        /// Gets or sets the amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the commission Ammount
        /// </summary>
        public decimal CommissionAmount { get; set; }
        public string Name { get; internal set; }
        public string Service { get; internal set; }
    }
}
