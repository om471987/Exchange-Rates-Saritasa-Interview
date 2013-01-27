using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates
{
    public class Manager : IManager
    {
        private readonly IDatabaseWrapper _databaseWrapper;
        private readonly IOpenExchangeRatesService _openExchangeRatesService;

        public Manager(IDatabaseWrapper databaseWrapper, IOpenExchangeRatesService openExchangeRatesService)
        {
            _databaseWrapper = databaseWrapper;
            _openExchangeRatesService = openExchangeRatesService;
        }

        public ChartModel GetData(DateTime startDate, DateTime endDate, int list1, int list2)
        {
            var range = (endDate - startDate).Days + 1;

            var dates = _databaseWrapper.GetNonExistingDates(startDate, range);
            var dateTimes = dates as IList<DateTime?> ?? dates.ToList();

            if (dateTimes.Any())
            {
                var c = new ConcurrentDictionary<DateTime?, JsonTemplate>();

                Parallel.ForEach(dateTimes, t =>
                    {
                        c.TryAdd(t, _openExchangeRatesService.GetHistoricalExchangeRate(t));
                    });

                _databaseWrapper.SaveJsonTemplate(c);
            }
            return _databaseWrapper.GetRate(startDate, endDate, list1, list2);
        }

        public IDictionary<int,string> GetCurrencies()
        {
            return _databaseWrapper.GetCurrencies();
        }
    }
}
