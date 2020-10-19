using Jambopay.Web.Framework.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jambopay.Web.Framework.Tests
{
    [TestClass]
    public class NetworkMarketingFactory_Should
    {

        [TestMethod]
        public void CalculateAmbassadorCommission()
        {
            var networkMaketingFactory = new NetworkMarketingFactory(null, null, null, null);

            var transactionAmount = 100m;
            var commissionRate = .05m;

            var ambassadorCommission = networkMaketingFactory.ComputeAmbassadorCommission(transactionAmount, commissionRate);

            Assert.AreEqual(5m, ambassadorCommission);
        }
    }
}
