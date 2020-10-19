
using System;
using System.Collections.Generic;
using System.Linq;
using Jambopay.Core.Domain.Services;
using Jambopay.Data.Infrastructure;

namespace Jambopay.Services.Services
{
    /// <summary>
    /// Represents the Service Service interface
    /// </summary>
    public class ServiceService : IServiceService
    {
		#region Fields
		
		private readonly IRepository<Service> _serviceRepository;
		
		#endregion
		
		#region Ctor
		
		public ServiceService(IRepository<Service> serviceRepository)
		{
		 this._serviceRepository = serviceRepository;
		}
		#endregion
		
        #region Methods

        /// <summary>
        /// Creates a Service
        /// </summary>
        /// <param name="service">Service</param>
        public void InsertService(Service service)
		{
			if (service == null)
                throw new ArgumentNullException(nameof(Service));

            _serviceRepository.Insert(service);
		}
		
		/// <summary>
        /// Updates a Service
        /// </summary>
        /// <param name="service">Service</param>
        public void UpdateService(Service service)
		{
			if (service == null)
                throw new ArgumentNullException(nameof(Service));

            _serviceRepository.Update(service);
		}
		
		/// <summary>
        /// Deletes a Service
        /// </summary>
        /// <param name="service">Service</param>
        public void DeleteService(Service service)
		{
			if (service == null)
                throw new ArgumentNullException(nameof(Service));

            _serviceRepository.Delete(service);
		}
		
		
		/// <summary>
        /// Get Service by identifier
        /// </summary>
        /// <param name="serviceId">ServiceId</param>
        public Service GetServiceById(int serviceId)
		{
			if (serviceId == 0)
                throw new ArgumentNullException(nameof(Service));

            return _serviceRepository.GetById(serviceId);
		}		
		
		/// <summary>
        /// Get Services
        /// </summary>
		/// <returns>Services</returns>
		public IList<Service> GetServices()
		{
			return _serviceRepository.Table.ToList();
		}

		/// <summary>
		/// Gets a service by name
		/// </summary>
		/// <param name="serviceName">Service name</param>
		/// <returns>Service</returns>
        public Service GetServiceByName(string serviceName)
        {
			return _serviceRepository.Table
				.Where(service => service.Name == serviceName)
				.FirstOrDefault();
        }


        #endregion
    }
}
