
using Jambopay.Core.Domain.Customers;
using System.Collections.Generic;

namespace Jambopay.Services.Customers
{
    /// <summary>
    /// Represents the Customer Service interface
    /// </summary>
    public interface ICustomerService
    {
        #region Methods

        /// <summary>
        /// Creates a Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        void InsertCustomer(Customer customer);
		
		/// <summary>
        /// Updates a Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        void UpdateCustomer(Customer customer);
		
		/// <summary>
        /// Deletes a Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        void DeleteCustomer(Customer customer);
		
		/// <summary>
        /// Get Customer by identifier
        /// </summary>
        /// <param name="customerId">CustomerId</param>
        Customer GetCustomerById(int customerId);
		
		/// <summary>
        /// Get Customers
        /// </summary>
		/// <returns>Customers</returns>
		IList<Customer> GetCustomers();

        /// <summary>
        /// Gets a customer by email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Customer</returns>
        Customer GetCustomerByEmail(string email);
        #endregion
    }
}
