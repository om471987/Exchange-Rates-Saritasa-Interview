using System;
using ExchangeRates.DataService;
using NUnit.Framework;

namespace ExchangeRates.Tests
{
    [TestFixture]
    public class GetNonExistingDatesTests
    {
        private ResolveType _resolveType;
        private IManager _manager;

        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private int _rub;
        private int _usd;

        [SetUp]
        public void Setup()
        {
            _resolveType = ResolveType.GetInstance();
            _manager = _resolveType.Manager();
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
