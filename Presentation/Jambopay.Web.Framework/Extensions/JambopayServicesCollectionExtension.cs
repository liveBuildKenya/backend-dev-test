using Jambopay.Core;
using Jambopay.Core.Infrastructure;
using Jambopay.Data;
using Jambopay.Data.Infrastructure;
using Jambopay.Services.Customers;
using Jambopay.Services.Services;
using Jambopay.Services.ServiceTransactions;
using Jambopay.Web.Framework.Factories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jambopay.Web.Framework.Extensions
{
    /// <summary>
    /// Represents the Jambopay service extensions
    /// </summary>
    public static class JambopayServicesCollectionExtension
    {
        public static void ConfigureJambopayServices(this IServiceCollection services, IWebHostEnvironment webHostEnvironment)
        {
            #region Repository

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            #endregion

            #region File Provider

            CommonHelper.DefaultFileProvider = new JambopayFileProvider(webHostEnvironment);

            #endregion

            #region Data Provider
            
            var dataSettings = DataSettingsManager.LoadSettings();
            services.AddDbContext<IJambopayDataProvider, JambopayDataProvider>(options => options.UseSqlServer(dataSettings.ConnectionString));

            #endregion

            #region Services

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServiceTransactionService, ServiceTransactionService>();

            #endregion

            #region Factories

            services.AddTransient<INetworkMarketingFactory, NetworkMarketingFactory>();
            
            #endregion
        }
    }
}
