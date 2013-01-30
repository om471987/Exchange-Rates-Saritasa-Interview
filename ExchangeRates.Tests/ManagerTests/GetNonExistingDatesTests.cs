using System;
using ExchangeRates.DataService;
using NUnit.Framework;
using ExchangeRates.DataService.IoC;
using Microsoft.Practices.Unity;

namespace ExchangeRates.Tests
{
    [TestFixture]
    public class GetNonExistingDatesTests
    {
        private IManager _manager;

        public GetNonExistingDatesTests() : this(null)
        {
        }

        public GetNonExistingDatesTests(IManager manager)
        {
            _manager = manager ?? ModelContainer.Instance.Resolve<IManager>();
        }

        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private int _rub;
        private int _usd;

        [SetUp]
        public void Setup()
        {
            _startDateTime = DateTime.Now.AddDays(-4);
            _endDateTime = DateTime.Now;
            _rub = 1;
            _usd = 3;
        }

        [Test]
        public void GetCurrenciesNotNull()
        {
            var currencyList = _manager.GetCurrencies();
            Assert.IsNotNull(currencyList.Count);
        }

        [Test]
        public void GetCurrenciesNotEmpty()
        {
            var currencyList = _manager.GetCurrencies();
            Assert.IsNotEmpty(currencyList);
            Assert.Greater(currencyList.Count, 1);
        }

        [Test]
        public void GetRateCollectionIsNotEmptyForValidDates()
        {
            var chartModel = _manager.GetRateCollection(_startDateTime,_endDateTime, _rub, _usd);

            Assert.IsNotEmpty(chartModel.Dates);
            Assert.IsNotEmpty(chartModel.Rates);
        }
    }
}
