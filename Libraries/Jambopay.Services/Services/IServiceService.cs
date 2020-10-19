
using Jambopay.Core.Domain.Services;
using System.Collections.Generic;

namespace Jambopay.Services.Services
{
    /// <summary>
    /// Represents the Service Service interface
    /// </summary>
    public interface IServiceService
    {
        #region Methods

        /// <summary>
        /// Creates a Service
        /// </summary>
        /// <param name="service">Service</param>
        void InsertService(Service service);
		
		/// <summary>
        /// Updates a Service
        /// </summary>
        /// <param name="service">Service</param>
        void UpdateService(Service service);
		
		/// <summary>
        /// Deletes a Service
        /// </summary>
        /// <param name="service">Service</param>
        void DeleteService(Service service);
		
		/// <summary>
        /// Get Service by identifier
        /// </summary>
        /// <param name="serviceId">ServiceId</param>
        Service GetServiceById(int serviceId);
		
		/// <summary>
        /// Get Services
        /// </summary>
		/// <returns>Services</returns>
		IList<Service> GetServices();

        /// <summary>
        /// Gets a service by name
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <returns>Service</returns>
        Service GetServiceByName(string serviceName);
        #endregion
    }
}
