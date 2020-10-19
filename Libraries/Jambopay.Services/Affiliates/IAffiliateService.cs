
using Jambopay.Core.Domain.Affiliates;
using System.Collections.Generic;

namespace Jambopay.Services.Affiliates
{
    /// <summary>
    /// Represents the Affiliate Service interface
    /// </summary>
    public interface IAffiliateService
    {
        #region Methods

        /// <summary>
        /// Creates a Affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        void InsertAffiliate(Affiliate affiliate);
		
		/// <summary>
        /// Updates a Affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        void UpdateAffiliate(Affiliate affiliate);
		
		/// <summary>
        /// Deletes a Affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        void DeleteAffiliate(Affiliate affiliate);
		
		/// <summary>
        /// Get Affiliate by identifier
        /// </summary>
        /// <param name="affiliateId">AffiliateId</param>
        Affiliate GetAffiliateById(int affiliateId);
		
		/// <summary>
        /// Get Affiliates
        /// </summary>
		/// <returns>Affiliates</returns>
		IList<Affiliate> GetAffiliates();
        
        /// <summary>
        /// Get affiliate by customer identifier
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <returns>Affiliate</returns>
        Affiliate GetAffiliateByCustomerId(int customerId);
        #endregion
    }
}
