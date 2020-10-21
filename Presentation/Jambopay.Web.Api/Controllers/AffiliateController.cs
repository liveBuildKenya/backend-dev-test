using Jambopay.Core;
using Jambopay.Core.Domain.ServiceTransactions;
using Jambopay.Web.Framework.Factories.NetworkMarketing;
using Jambopay.Web.Framework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jambopay.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AffiliateController : ControllerBase
    {
        private readonly INetworkMarketingFactory _networkMarketingFactory;

        public AffiliateController(INetworkMarketingFactory networkMarketingFactory)
        {
            this._networkMarketingFactory = networkMarketingFactory;
        }

        [HttpPost]
        public void InstallData()
        {
            _networkMarketingFactory.InstallData();
        }

        [HttpPost]
        public CustomerViewModel Login([FromBody] LoginViewModel loginViewModel)
        {
            return _networkMarketingFactory.Login(loginViewModel);
        }

        [HttpPost]
        public CustomerViewModel RegisterAmbassador([FromBody] RegisterAmbassadorViewModel registerAmbassadorViewModel)
        {
            return _networkMarketingFactory.RegisterAmbassador(registerAmbassadorViewModel);
        }

        [HttpPost]
        public CustomerViewModel RegisterSupporter([FromBody] RegisterSupporterViewModel registerSupporterViewModel)
        {
            return _networkMarketingFactory.RegisterSupporter(registerSupporterViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<TransactResponseViewModel> Transact([FromBody] TransactViewModel transactViewModel)
        {
            return await _networkMarketingFactory.Transact(transactViewModel);
        }

        [HttpGet]
        [Authorize]
        public IPagedList<TransactionViewModel> ViewTransactions([FromQuery] PagingViewModel pagingViewModel)
        {
            return _networkMarketingFactory.ViewTransactions(pagingViewModel);
        }

        [HttpGet("{ambassadorId}")]
        public AmbassadorCommissionBalanceViewModel ViewAmbassadorCommissionBalance(int ambassadorId)
        {
            return _networkMarketingFactory.ViewAmbassadorCommissionBalance(ambassadorId);
        }
    }
}
