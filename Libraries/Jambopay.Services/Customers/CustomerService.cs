
using System;
using System.Collections.Generic;
using System.Linq;
using Jambopay.Core.Domain.Customers;
using Jambopay.Data.Infrastructure;

namespace Jambopay.Services.Customers
{
    /// <summary>
    /// Represents the Customer Service interface
    /// </summary>
    public class CustomerService : ICustomerService
    {
		#region Fields
		
		private readonly IRepository<Customer> _customerRepository;
		
		#endregion
		
		#region Ctor
		
		public CustomerService(IRepository<Customer> customerRepository)
		{
		 this._customerRepository = customerRepository;
		}
		#endregion
		
        #region Methods

        /// <summary>
        /// Creates a Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void InsertCustomer(Customer customer)
		{
			if (customer == null)
                throw new ArgumentNullException(nameof(Customer));

            _customerRepository.Insert(customer);
		}
		
		/// <summary>
        /// Updates a Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void UpdateCustomer(Customer customer)
		{
			if (customer == null)
                throw new ArgumentNullException(nameof(Customer));

            _customerRepository.Update(customer);
		}
		
		/// <summary>
        /// Deletes a Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void DeleteCustomer(Customer customer)
		{
			if (customer == null)
                throw new ArgumentNullException(nameof(Customer));

            _customerRepository.Delete(customer);
		}
		
		
		/// <summary>
        /// Get Customer by identifier
        /// </summary>
        /// <param name="customerId">CustomerId</param>
        public Customer GetCustomerById(int customerId)
		{
			if (customerId == 0)
                throw new ArgumentNullException(nameof(Customer));

            return _customerRepository.GetById(customerId);
		}		
		
		/// <summary>
        /// Get Customers
        /// </summary>
		/// <returns>Customers</returns>
		public IList<Customer> GetCustomers()
		{
			return _customerRepository.Table.ToList();
		}

		/// <summary>
		/// Gets a customer by email
		/// </summary>
		/// <param name="email">customer email</param>
		/// <returns>Customer</returns>
        public Customer GetCustomerByEmail(string email)
        {
			return _customerRepository.Table
				.Where(customer => customer.Email == email)
				.FirstOrDefault();
        }
        #endregion
    }
}
