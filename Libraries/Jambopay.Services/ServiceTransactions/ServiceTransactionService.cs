
using System;
using System.Collections.Generic;
using System.Linq;
using Jambopay.Core.Domain.ServiceTransactions;
using Jambopay.Data.Infrastructure;

namespace Jambopay.Services.ServiceTransactions
{
    /// <summary>
    /// Represents the ServiceTransaction Service interface
    /// </summary>
    public class ServiceTransactionService : IServiceTransactionService
    {
		#region Fields
		
		private readonly IRepository<ServiceTransaction> _serviceTransactionRepository;
		
		#endregion
		
		#region Ctor
		
		public ServiceTransactionService(IRepository<ServiceTransaction> serviceTransactionRepository)
		{
		 this._serviceTransactionRepository = serviceTransactionRepository;
		}
		#endregion
		
        #region Methods

        /// <summary>
        /// Creates a ServiceTransaction
        /// </summary>
        /// <param name="serviceTransaction">ServiceTransaction</param>
        public void InsertServiceTransaction(ServiceTransaction serviceTransaction)
		{
			if (serviceTransaction == null)
                throw new ArgumentNullException(nameof(ServiceTransaction));

            _serviceTransactionRepository.Insert(serviceTransaction);
		}
		
		/// <summary>
        /// Updates a ServiceTransaction
        /// </summary>
        /// <param name="serviceTransaction">ServiceTransaction</param>
        public void UpdateServiceTransaction(ServiceTransaction serviceTransaction)
		{
			if (serviceTransaction == null)
                throw new ArgumentNullException(nameof(ServiceTransaction));

            _serviceTransactionRepository.Update(serviceTransaction);
		}
		
		/// <summary>
        /// Deletes a ServiceTransaction
        /// </summary>
        /// <param name="serviceTransaction">ServiceTransaction</param>
        public void DeleteServiceTransaction(ServiceTransaction serviceTransaction)
		{
			if (serviceTransaction == null)
                throw new ArgumentNullException(nameof(ServiceTransaction));

            _serviceTransactionRepository.Delete(serviceTransaction);
		}
		
		
		/// <summary>
        /// Get ServiceTransaction by identifier
        /// </summary>
        /// <param name="serviceTransactionId">ServiceTransactionId</param>
        public ServiceTransaction GetServiceTransactionById(int serviceTransactionId)
		{
			if (serviceTransactionId == 0)
                throw new ArgumentNullException(nameof(ServiceTransaction));

            return _serviceTransactionRepository.GetById(serviceTransactionId);
		}		
		
		/// <summary>
        /// Get ServiceTransactions
        /// </summary>
		/// <returns>ServiceTransactions</returns>
		public IList<ServiceTransaction> GetServiceTransactions()
		{
			return _serviceTransactionRepository.Table.ToList();
		}

		/// <summary>
		/// Gets the service transactions by Ambassador identifiers
		/// </summary>
		/// <param name="ambassadorId">Ambassador identifier</param>
		/// <returns>Service transactions</returns>
        public IList<ServiceTransaction> GetServiceTransactionsByAmbassadorId(int ambassadorId)
        {
			return _serviceTransactionRepository.Table
				.Where(serviceTransaction => serviceTransaction.AmbassadorId == ambassadorId)
				.ToList();
        }

        #endregion
    }
}
