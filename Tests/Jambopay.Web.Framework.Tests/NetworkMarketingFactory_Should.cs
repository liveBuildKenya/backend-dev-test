using Jambopay.Services.Services;
using Jambopay.Web.Framework.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jambopay.Web.Framework.Tests
{
    [TestClass]
    public class NetworkMarketingFactory_Should
    {
        #region Fields

        private readonly INetworkMarketingFactory _networkMarketingFactory;

        private

        #endregion

        #region Constructor

        public NetworkMarketingFactory_Should()
        {
            this._networkMarketingFactory = new NetworkMarketingFactory(new ServiceService());
        }

        #endregion
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
