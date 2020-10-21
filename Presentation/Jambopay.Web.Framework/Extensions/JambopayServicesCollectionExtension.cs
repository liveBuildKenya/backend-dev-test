using Jambopay.Core;
using Jambopay.Core.Infrastructure;
using Jambopay.Data;
using Jambopay.Data.Infrastructure;
using Jambopay.Services.CommissionWithdrawals;
using Jambopay.Services.Customers;
using Jambopay.Services.Services;
using Jambopay.Services.ServiceTransactions;
using Jambopay.Web.Framework.Authentication;
using Jambopay.Web.Framework.Factories.NetworkMarketing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Jambopay.Web.Framework.Extensions
{
    /// <summary>
    /// Represents the Jambopay service extensions
    /// </summary>
    public static class JambopayServicesCollectionExtension
    {
        public static void ConfigureJambopayServices(this IServiceCollection services, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            #region Authentication

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["Jwt:Issuer"],
                            ValidAudience = configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                        };
                    });

            #endregion

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
            services.AddTransient<ICommissionWithdrawalService, CommissionWithdrawalService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServiceTransactionService, ServiceTransactionService>();

            #endregion

            #region Factories

            services.AddTransient<IJsonWebTokenService, JsonWebTokenService>();

            services.AddTransient<INetworkMarketingFactory, NetworkMarketingFactory>();
            
            #endregion
        }
    }
}
