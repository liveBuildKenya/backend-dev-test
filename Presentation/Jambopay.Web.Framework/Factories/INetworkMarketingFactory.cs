using Jambopay.Web.Framework.Models;

namespace Jambopay.Web.Framework.Factories
{
    /// <summary>
    /// Represents the network marketing factory
    /// </summary>
    public interface INetworkMarketingFactory
    {
        void InstallData();
        CustomerViewModel RegisterAmbassador(RegisterAmbassadorViewModel registerAmbassadorViewModel);
        CustomerViewModel RegisterSupporter(RegisterSupporterViewModel registerSupporterViewModel);
        void Transact(TransactViewModel transactViewModel);
        AmbassadorCommissionBalanceViewModel ViewAmbassadorCommissionBalance(int ambassadorId);
    }
}
