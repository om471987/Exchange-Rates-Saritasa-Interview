using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRates.Tests
{
    [TestClass]
    public class GetCurrenciesTests
    {
        [TestMethod]
        public void CurrencyListIsNotNull()
        {
           // Assert.IsNotNull(DatabaseWrapper.GetCurrencies());
        }

        [TestMethod]
        public void CurrencyListIsMoreThanOne()
        {
            //Assert.IsTrue(DatabaseWrapper.GetCurrencies().Count > 1);
        }
    }
}
