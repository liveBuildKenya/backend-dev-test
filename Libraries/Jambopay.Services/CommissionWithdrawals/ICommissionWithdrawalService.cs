
using Jambopay.Core.Domain.CommissionWithdrawals;
using System.Collections.Generic;

namespace Jambopay.Services.CommissionWithdrawals
{
    /// <summary>
    /// Represents the CommissionWithdrawal Service interface
    /// </summary>
    public interface ICommissionWithdrawalService
    {
        #region Methods

        /// <summary>
        /// Creates a CommissionWithdrawal
        /// </summary>
        /// <param name="commissionWithdrawal">CommissionWithdrawal</param>
        void InsertCommissionWithdrawal(CommissionWithdrawal commissionWithdrawal);
		
		/// <summary>
        /// Updates a CommissionWithdrawal
        /// </summary>
        /// <param name="commissionWithdrawal">CommissionWithdrawal</param>
        void UpdateCommissionWithdrawal(CommissionWithdrawal commissionWithdrawal);
		
		/// <summary>
        /// Deletes a CommissionWithdrawal
        /// </summary>
        /// <param name="commissionWithdrawal">CommissionWithdrawal</param>
        void DeleteCommissionWithdrawal(CommissionWithdrawal commissionWithdrawal);
		
		/// <summary>
        /// Get CommissionWithdrawal by identifier
        /// </summary>
        /// <param name="commissionWithdrawalId">CommissionWithdrawalId</param>
        CommissionWithdrawal GetCommissionWithdrawalById(int commissionWithdrawalId);
		
		/// <summary>
        /// Get CommissionWithdrawals
        /// </summary>
		/// <returns>CommissionWithdrawals</returns>
		IList<CommissionWithdrawal> GetCommissionWithdrawals();
        #endregion
    }
}
