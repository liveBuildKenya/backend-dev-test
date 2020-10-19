using Jambopay.Core.Domain.Affiliates;
using Jambopay.Core.Domain.Customers;
using Jambopay.Core.Domain.Services;
using Jambopay.Core.Domain.ServiceTransactions;
using Jambopay.Services.Affiliates;
using Jambopay.Services.Customers;
using Jambopay.Services.Services;
using Jambopay.Services.ServiceTransactions;
using Jambopay.Web.Framework.Models;
using System.Linq;

namespace Jambopay.Web.Framework.Factories
{
    /// <summary>
    /// Represents the network marketing factory service
    /// </summary>
    public class NetworkMarketingFactory : INetworkMarketingFactory
    {
        #region Fields

        private readonly IServiceService _serviceService;
        private readonly ICustomerService _customerService;
        private readonly IAffiliateService _affiliateService;
        private readonly IServiceTransactionService _serviceTransactionService;

        #endregion

        #region Ctor

        public NetworkMarketingFactory(IServiceService serviceService,
            ICustomerService customerService,
            IAffiliateService affiliateService,
            IServiceTransactionService serviceTransactionService)
        {
            this._serviceService = serviceService;
            this._customerService = customerService;
            this._affiliateService = affiliateService;
            this._serviceTransactionService = serviceTransactionService;
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

            var electricityService = new Service
            {
                Name = "Electricity",
                AmbassadorCommissionRate = 0.02m
            };

            var service = _serviceService.GetServiceByName(electricityService.Name);

            if (service == null)
            {
                _serviceService.InsertService(electricityService);
            }

            var waterService = new Service
            {
                Name = "Water",
                AmbassadorCommissionRate = 0.03m
            };

            service = _serviceService.GetServiceByName(waterService.Name);

            if (service == null)
            {
                _serviceService.InsertService(waterService);
            }

            var airtimeService = new Service
            {
                Name = "Airtime",
                AmbassadorCommissionRate = 0.05m
            };

            service = _serviceService.GetServiceByName(airtimeService.Name);

            if (service == null)
            {
                _serviceService.InsertService(airtimeService);
            }
        }

        public CustomerViewModel RegisterAmbassador(RegisterAmbassadorViewModel registerAmbassadorViewModel)
        {
            var customer = _customerService.GetCustomerByEmail(registerAmbassadorViewModel.Email);

            if (customer == null)
            {
                customer = new Customer
                {
                    Email = registerAmbassadorViewModel.Email
                };

                _customerService.InsertCustomer(customer);
            }

            var affiliate = _affiliateService.GetAffiliateByCustomerId(customer.Id);

            var newAmbassador = new Affiliate
            {
                CustomerId = customer.Id,
                Deleted = false,
                Active = true
            };

            if (affiliate == null)
                _affiliateService.InsertAffiliate(newAmbassador);

            return new CustomerViewModel
            {
                Id = customer.Id,
                AffiliateId = newAmbassador.Id,
                CustomerGuid = customer.CustomerGuid,
                Email = customer.Email
            };
        }

        public CustomerViewModel RegisterSupporter(RegisterSupporterViewModel registerSupporterViewModel)
        {
            var customer = _customerService.GetCustomerByEmail(registerSupporterViewModel.Email);

            if (customer == null)
            {
                customer = new Customer
                {
                    Email = registerSupporterViewModel.Email
                };

                _customerService.InsertCustomer(customer);
            }

            var affiliate = _affiliateService.GetAffiliateByCustomerId(customer.Id);

            var newSupporter = new Affiliate
            {
                CustomerId = customer.Id,
                Deleted = false,
                Active = true,
                AmbassadorId = registerSupporterViewModel.AmbassadorId
            };

            if (affiliate == null)
                _affiliateService.InsertAffiliate(newSupporter);

            return new CustomerViewModel
            {
                Id = customer.Id,
                AffiliateId = newSupporter.Id,
                CustomerGuid = customer.CustomerGuid,
                Email = customer.Email
            };
        }

        public void Transact(TransactViewModel transactViewModel)
        {
            var supporter = _affiliateService.GetAffiliateById(transactViewModel.SupporterId);
            var service = _serviceService.GetServiceById(transactViewModel.ServiceId);

            var newTransaction = new ServiceTransaction()
            {
                AmbassadorId = supporter.AmbassadorId,
                Amount = transactViewModel.Amount,
                CommissionAmount = ComputeAmbassadorCommission(transactViewModel.Amount, service.AmbassadorCommissionRate),
                ServiceId = service.Id,
                SupporterId = supporter.Id
            };

            _serviceTransactionService.InsertServiceTransaction(newTransaction);
        }

        public AmbassadorCommissionBalanceViewModel ViewAmbassadorCommissionBalance(int ambassadorId)
        {
            var ambassadorTransactions = _serviceTransactionService.GetServiceTransactionsByAmbassadorId(ambassadorId);
            var ambassadorCommissionBalanceViewModel = new AmbassadorCommissionBalanceViewModel
            {
                Transactions = new System.Collections.Generic.List<TransactionViewModel>(),
                CommissionBalanace = ambassadorTransactions.Sum(ambassadorTransaction => ambassadorTransaction.CommissionAmount)
            };

            foreach (var ambassadorTransaction in ambassadorTransactions)
            {
                var affiliate = _affiliateService.GetAffiliateById(ambassadorTransaction.SupporterId);

                ambassadorCommissionBalanceViewModel.Transactions.Add(new TransactionViewModel
                {
                    SupporterEmail = (_customerService.GetCustomerById(affiliate.CustomerId)).Email,
                    Amount = ambassadorTransaction.Amount,
                    CommissionAmount = ambassadorTransaction.CommissionAmount
                });
            }

            return ambassadorCommissionBalanceViewModel;
        }

        #endregion
    }
}
