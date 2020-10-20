
using System;
using System.Collections.Generic;
using System.Linq;
using Jambopay.Core.Domain.CommissionWithdrawals;
using Jambopay.Data.Infrastructure;

namespace Jambopay.Services.CommissionWithdrawals
{
    /// <summary>
    /// Represents the CommissionWithdrawal Service interface
    /// </summary>
    public class CommissionWithdrawalService : ICommissionWithdrawalService
    {
		#region Fields
		
		private readonly IRepository<CommissionWithdrawal> _commissionWithdrawalRepository;
		
		#endregion
		
		#region Ctor
		
		public CommissionWithdrawalService(IRepository<CommissionWithdrawal> commissionWithdrawalRepository)
		{
		 this._commissionWithdrawalRepository = commissionWithdrawalRepository;
		}
		#endregion
		
        #region Methods

        /// <summary>
        /// Creates a CommissionWithdrawal
        /// </summary>
        /// <param name="commissionWithdrawal">CommissionWithdrawal</param>
        public void InsertCommissionWithdrawal(CommissionWithdrawal commissionWithdrawal)
		{
			if (commissionWithdrawal == null)
                throw new ArgumentNullException(nameof(CommissionWithdrawal));

            _commissionWithdrawalRepository.Insert(commissionWithdrawal);
		}
		
		/// <summary>
        /// Updates a CommissionWithdrawal
        /// </summary>
        /// <param name="commissionWithdrawal">CommissionWithdrawal</param>
        public void UpdateCommissionWithdrawal(CommissionWithdrawal commissionWithdrawal)
		{
			if (commissionWithdrawal == null)
                throw new ArgumentNullException(nameof(CommissionWithdrawal));

            _commissionWithdrawalRepository.Update(commissionWithdrawal);
		}
		
		/// <summary>
        /// Deletes a CommissionWithdrawal
        /// </summary>
        /// <param name="commissionWithdrawal">CommissionWithdrawal</param>
        public void DeleteCommissionWithdrawal(CommissionWithdrawal commissionWithdrawal)
		{
			if (commissionWithdrawal == null)
                throw new ArgumentNullException(nameof(CommissionWithdrawal));

            _commissionWithdrawalRepository.Delete(commissionWithdrawal);
		}
		
		
		/// <summary>
        /// Get CommissionWithdrawal by identifier
        /// </summary>
        /// <param name="commissionWithdrawalId">CommissionWithdrawalId</param>
        public CommissionWithdrawal GetCommissionWithdrawalById(int commissionWithdrawalId)
		{
			if (commissionWithdrawalId == 0)
                throw new ArgumentNullException(nameof(CommissionWithdrawal));

            return _commissionWithdrawalRepository.GetById(commissionWithdrawalId);
		}		
		
		/// <summary>
        /// Get CommissionWithdrawals
        /// </summary>
		/// <returns>CommissionWithdrawals</returns>
		public IList<CommissionWithdrawal> GetCommissionWithdrawals()
		{
			return _commissionWithdrawalRepository.Table.ToList();
		}
        #endregion
    }
}
