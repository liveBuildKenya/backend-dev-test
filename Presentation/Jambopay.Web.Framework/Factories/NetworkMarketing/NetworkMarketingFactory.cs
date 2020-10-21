using Jambopay.Core;
using Jambopay.Core.Domain.Customers;
using Jambopay.Core.Domain.Services;
using Jambopay.Core.Domain.ServiceTransactions;
using Jambopay.Services.Customers;
using Jambopay.Services.Services;
using Jambopay.Services.ServiceTransactions;
using Jambopay.Web.Framework.Authentication;
using Jambopay.Web.Framework.Extensions;
using Jambopay.Web.Framework.Models;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambopay.Web.Framework.Factories.NetworkMarketing
{
    /// <summary>
    /// Represents the network marketing factory service
    /// </summary>
    public class NetworkMarketingFactory : INetworkMarketingFactory
    {
        #region Fields

        private readonly IServiceService _serviceService;
        private readonly ICustomerService _customerService;
        private readonly IServiceTransactionService _serviceTransactionService;
        private readonly IJsonWebTokenService _jsonWebTokenService;
        private readonly IDataProtector _dataProtector;

        #endregion

        #region Ctor

        public NetworkMarketingFactory(IServiceService serviceService,
            ICustomerService customerService,
            IServiceTransactionService serviceTransactionService,
            IJsonWebTokenService jsonWebTokenService,
            IDataProtectionProvider dataProtectionProvider)
        {
            this._serviceService = serviceService;
            this._customerService = customerService;
            this._serviceTransactionService = serviceTransactionService;
            this._jsonWebTokenService = jsonWebTokenService;
            this._dataProtector = dataProtectionProvider.CreateProtector("Amount Protector");
        }

        #endregion

        #region Utilities

        public decimal ComputeAmbassadorCommission(decimal amount, decimal commissionRate)
        {
            return amount * commissionRate;
        }

        #endregion

        #region Methods

        public void InstallData()
        {
            var dateCreated = DateTime.UtcNow;

            var electricityService = new Service
            {
                Name = "Electricity",
                AmbassadorCommissionRate = 0.02m,
                CreatedOn = dateCreated
            };

            var service = _serviceService.GetServiceByName(electricityService.Name);

            if (service == null)
            {
                _serviceService.InsertService(electricityService);
            }

            var waterService = new Service
            {
                Name = "Water",
                AmbassadorCommissionRate = 0.03m,
                CreatedOn = dateCreated
            };

            service = _serviceService.GetServiceByName(waterService.Name);

            if (service == null)
            {
                _serviceService.InsertService(waterService);
            }

            var airtimeService = new Service
            {
                Name = "Airtime",
                AmbassadorCommissionRate = 0.05m,
                CreatedOn = dateCreated
            };

            service = _serviceService.GetServiceByName(airtimeService.Name);

            if (service == null)
            {
                _serviceService.InsertService(airtimeService);
            }
        }

        public CreateTransactionViewModel PrepareCreateTransactionModel()
        {
            return new CreateTransactionViewModel
            {
                AvailableService = _serviceService.GetServices()
            };
        }

        public CustomerViewModel RegisterAmbassador(RegisterAmbassadorViewModel registerAmbassadorViewModel)
        {
            var customer = _customerService.GetCustomerByEmail(registerAmbassadorViewModel.Email);

            if (customer == null)
            {
                var salt = CustomerAuthenticationExtensions.GenerateSalt();

                customer = new Customer
                {
                    Name = registerAmbassadorViewModel.Name,
                    Email = registerAmbassadorViewModel.Email,
                    PhoneNumber = registerAmbassadorViewModel.PhoneNumber,
                    Salt = salt,
                    Password = CustomerAuthenticationExtensions.HashPassword(registerAmbassadorViewModel.Password, salt),
                    Active = true,
                    CreatedOn = DateTime.UtcNow
                };

                _customerService.InsertCustomer(customer);
            }

            return new CustomerViewModel
            {
                Id = customer.Id,
                CustomerGuid = customer.CustomerGuid,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AmbassadorId = customer.AmbassadorId,
                Token = _jsonWebTokenService.GenerateJSONWebToken(customer)
        };
        }

        public CustomerViewModel RegisterSupporter(RegisterSupporterViewModel registerSupporterViewModel)
        {
            var customer = _customerService.GetCustomerByEmail(registerSupporterViewModel.Email);

            if (customer == null)
            {
                var salt = CustomerAuthenticationExtensions.GenerateSalt();

                customer = new Customer
                {
                    Name = registerSupporterViewModel.Name,
                    Email = registerSupporterViewModel.Email,
                    PhoneNumber = registerSupporterViewModel.PhoneNumber,
                    Salt = salt,
                    Password = CustomerAuthenticationExtensions.HashPassword(registerSupporterViewModel.Password, salt),
                    Active = true,
                    AmbassadorId = registerSupporterViewModel.AmbassadorId,
                    CreatedOn = DateTime.UtcNow
                };

                _customerService.InsertCustomer(customer);
            }

            return new CustomerViewModel
            {
                Id = customer.Id,
                CustomerGuid = customer.CustomerGuid,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AmbassadorId = customer.AmbassadorId,
                Token = _jsonWebTokenService.GenerateJSONWebToken(customer)
            };
        }

        public async Task<TransactResponseViewModel> Transact(TransactViewModel transactViewModel)
        {
            var supporter = _customerService.GetCustomerById(transactViewModel.SupporterId);
            var ambassador = _customerService.GetCustomerById(supporter.AmbassadorId);
            var service = _serviceService.GetServiceById(transactViewModel.ServiceId);
            var commission = ComputeAmbassadorCommission(transactViewModel.Amount, service.AmbassadorCommissionRate);

            if (supporter != null && service != null)
            {
                var newServiceTransaction = new ServiceTransaction
                {
                    ServiceId = transactViewModel.ServiceId,
                    AmbassadorId = supporter.AmbassadorId,
                    SupporterId = transactViewModel.SupporterId,
                    Amount = _dataProtector.Protect(transactViewModel.Amount.ToString()),
                    CommissionAmount = _dataProtector.Protect(commission.ToString()),
                    CreatedOn = DateTime.UtcNow
                };

                await _serviceTransactionService.InsertServiceTransactionAsync(newServiceTransaction);

                if (ambassador.CommissionBalance == null)
                {
                    ambassador.CommissionBalance = newServiceTransaction.CommissionAmount;
                }
                else
                {
                    var ambassadorCommissionBalance = Convert.ToDecimal(_dataProtector.Unprotect(ambassador.CommissionBalance)) + commission;
                    ambassador.CommissionBalance = _dataProtector.Protect(ambassadorCommissionBalance.ToString());
                }

                _customerService.UpdateCustomer(ambassador);
            }

            return new TransactResponseViewModel
            {
                ServicePaid = service.Name,
                Amount = transactViewModel.Amount,
                PaidBy = supporter.Name,
                CommissionPaidTo = ambassador.Name
            };
        }

        public AmbassadorCommissionBalanceViewModel ViewAmbassadorCommissionBalance(int ambassadorId)
        {
            var ambassador = _customerService.GetCustomerById(ambassadorId);

            var ambassadorCommissionBalanceViewModel = new AmbassadorCommissionBalanceViewModel
            {
                CommissionBalanace = Convert.ToDecimal(_dataProtector.Unprotect(ambassador.CommissionBalance))
            };

            return ambassadorCommissionBalanceViewModel;
        }

        public int GetSupporterIdByEmail(string supporterEmail)
        {
            var customer = _customerService.GetCustomerByEmail(supporterEmail);

            return customer.Id;
        }

        public IPagedList<TransactionViewModel> ViewTransactions(PagingViewModel pagingViewModel)
        {
            var query = _serviceTransactionService.GetQueryableServiceTransaction()
                        .Join(_serviceService.GetQueryableService(), serviceTransaction => serviceTransaction.ServiceId, service=>service.Id,
                        (serviceTransaction, service) => new { ServiceTransaction = serviceTransaction, Service = service })
                        .Join(_customerService.GetQueryableCustomer(), serviceTransaction => serviceTransaction.ServiceTransaction.SupporterId, customer => customer.Id,
                         (serviceTransaction, customer) => new TransactionViewModel {
                             Name = customer.Name,
                             SupporterEmail = customer.Email,
                             Amount = Convert.ToDecimal(_dataProtector.Unprotect(serviceTransaction.ServiceTransaction.Amount)),
                             Service = serviceTransaction.Service.Name
                         })
                        .ToList();

            return new PagedList<TransactionViewModel>(query, pagingViewModel.PageIndex, pagingViewModel.PageSize);

        }

        public CustomerViewModel Login(LoginViewModel loginViewModel)
        {
            var customer = _customerService.GetCustomerByEmail(loginViewModel.Email);
            var customerViewModel = new CustomerViewModel
            {
                Id = customer.Id,
                CustomerGuid = customer.CustomerGuid,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AmbassadorId = customer.AmbassadorId
            };

            string providedPasswordHash = CustomerAuthenticationExtensions.HashPassword(loginViewModel.Password, customer.Salt);
            var passwordValid = (providedPasswordHash == customer.Password);

            if (passwordValid)
            {
                customerViewModel.Token = _jsonWebTokenService.GenerateJSONWebToken(customer);
                customerViewModel.PasswordValid = true;
            }
            else
            {
                customerViewModel.PasswordValid = false;
            }

            return customerViewModel;
        }

        #endregion
    }
}
