
using System;
using System.Collections.Generic;
using System.Linq;
using Jambopay.Core.Domain.Affiliates;
using Jambopay.Data.Infrastructure;

namespace Jambopay.Services.Affiliates
{
    /// <summary>
    /// Represents the Affiliate Service interface
    /// </summary>
    public class AffiliateService : IAffiliateService
    {
		#region Fields
		
		private readonly IRepository<Affiliate> _affiliateRepository;
		
		#endregion
		
		#region Ctor
		
		public AffiliateService(IRepository<Affiliate> affiliateRepository)
		{
		 this._affiliateRepository = affiliateRepository;
		}
		#endregion
		
        #region Methods

        /// <summary>
        /// Creates a Affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public void InsertAffiliate(Affiliate affiliate)
		{
			if (affiliate == null)
                throw new ArgumentNullException(nameof(Affiliate));

            _affiliateRepository.Insert(affiliate);
		}
		
		/// <summary>
        /// Updates a Affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public void UpdateAffiliate(Affiliate affiliate)
		{
			if (affiliate == null)
                throw new ArgumentNullException(nameof(Affiliate));

            _affiliateRepository.Update(affiliate);
		}
		
		/// <summary>
        /// Deletes a Affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public void DeleteAffiliate(Affiliate affiliate)
		{
			if (affiliate == null)
                throw new ArgumentNullException(nameof(Affiliate));

            _affiliateRepository.Delete(affiliate);
		}
		
		
		/// <summary>
        /// Get Affiliate by identifier
        /// </summary>
        /// <param name="affiliateId">AffiliateId</param>
        public Affiliate GetAffiliateById(int affiliateId)
		{
			if (affiliateId == 0)
                throw new ArgumentNullException(nameof(Affiliate));

            return _affiliateRepository.GetById(affiliateId);
		}		
		
		/// <summary>
        /// Get Affiliates
        /// </summary>
		/// <returns>Affiliates</returns>
		public IList<Affiliate> GetAffiliates()
		{
			return _affiliateRepository.Table.ToList();
		}

		/// <summary>
		/// Get affiliate by customer identifier
		/// </summary>
		/// <param name="customerId">Customer identifier</param>
		/// <returns>Affiliate</returns>
        public Affiliate GetAffiliateByCustomerId(int customerId)
        {
			return _affiliateRepository.Table
				.Where(affiliate => affiliate.CustomerId == customerId)
				.FirstOrDefault();
        }

        #endregion
    }
}
