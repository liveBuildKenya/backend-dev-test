
using Jambopay.Core.Domain.ServiceTransactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambopay.Services.ServiceTransactions
{
    /// <summary>
    /// Represents the ServiceTransaction Service interface
    /// </summary>
    public interface IServiceTransactionService
    {
        #region Methods

        /// <summary>
        /// Creates a ServiceTransaction
        /// </summary>
        /// <param name="serviceTransaction">ServiceTransaction</param>
        Task InsertServiceTransactionAsync(ServiceTransaction serviceTransaction);
		
		/// <summary>
        /// Updates a ServiceTransaction
        /// </summary>
        /// <param name="serviceTransaction">ServiceTransaction</param>
        void UpdateServiceTransaction(ServiceTransaction serviceTransaction);
		
		/// <summary>
        /// Deletes a ServiceTransaction
        /// </summary>
        /// <param name="serviceTransaction">ServiceTransaction</param>
        void DeleteServiceTransaction(ServiceTransaction serviceTransaction);
		
		/// <summary>
        /// Get ServiceTransaction by identifier
        /// </summary>
        /// <param name="serviceTransactionId">ServiceTransactionId</param>
        ServiceTransaction GetServiceTransactionById(int serviceTransactionId);
		
		/// <summary>
        /// Get ServiceTransactions
        /// </summary>
		/// <returns>ServiceTransactions</returns>
		IList<ServiceTransaction> GetServiceTransactions();

        /// <summary>
        /// Gets queryable service transactions
        /// </summary>
        /// <returns></returns>
        IQueryable<ServiceTransaction> GetQueryableServiceTransaction();

        /// <summary>
        /// Gets the service Transactions
        /// </summary>
        /// <param name="ambassadorId">Ambassador identifier</param>
        /// <returns>Service transactions</returns>
        IList<ServiceTransaction> GetServiceTransactionsByAmbassadorId(int ambassadorId);
        #endregion
    }
}
