using Jambopay.Core;
using Jambopay.Core.Domain.ServiceTransactions;
using Jambopay.Web.Framework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambopay.Web.Framework.Factories.NetworkMarketing
{
    /// <summary>
    /// Represents the network marketing factory
    /// </summary>
    public interface INetworkMarketingFactory
    {
        void InstallData();
        CustomerViewModel RegisterAmbassador(RegisterAmbassadorViewModel registerAmbassadorViewModel);
        CustomerViewModel RegisterSupporter(RegisterSupporterViewModel registerSupporterViewModel);
        Task<TransactResponseViewModel> Transact(TransactViewModel transactViewModel);
        AmbassadorCommissionBalanceViewModel ViewAmbassadorCommissionBalance(int ambassadorId);
        CreateTransactionViewModel PrepareCreateTransactionModel();
        int GetSupporterIdByEmail(string supporterEmail);
        IPagedList<TransactionViewModel> ViewTransactions(PagingViewModel pagingViewModel);
        CustomerViewModel Login(LoginViewModel loginViewModel);
    }
}
