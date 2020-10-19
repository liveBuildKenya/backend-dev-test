using Jambopay.Web.Framework.Factories;
using Jambopay.Web.Framework.Models;
using Microsoft.AspNetCore.Mvc;

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
        public void Transact([FromBody] TransactViewModel transactViewModel)
        {
            _networkMarketingFactory.Transact(transactViewModel);
        }

        [HttpGet("{ambassadorId}")]
        public AmbassadorCommissionBalanceViewModel ViewAmbassadorCommissionBalance(int ambassadorId)
        {
            return _networkMarketingFactory.ViewAmbassadorCommissionBalance(ambassadorId);
        }
    }
}
