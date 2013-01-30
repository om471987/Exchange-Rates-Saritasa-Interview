using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.DataService
{
    public class Manager : IManager
    {
        private readonly IDatabaseWrapper _databaseWrapper;
        private readonly IExchangeRatesService _openExchangeRatesService;

        /// <summary>
        /// This constructor is invoked by Unity IoC
        /// </summary>
        /// <param name="databaseWrapper"></param>
        /// <param name="openExchangeRatesService"></param>
        public Manager(IDatabaseWrapper databaseWrapper, IExchangeRatesService openExchangeRatesService)
        {
            _databaseWrapper = databaseWrapper;
            _openExchangeRatesService = openExchangeRatesService;
        }

        /// <summary>
        /// It return data to plot graph
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="currency1"></param>
        /// <param name="currrency2"></param>
        /// <returns></returns>
        public ChartModel GetRateCollection(DateTime startDate, DateTime endDate, int currency1, int currrency2)
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
            return _databaseWrapper.GetRate(startDate, endDate, currency1, currrency2);
        }

        /// <summary>
        /// Returns currencies
        /// </summary>
        /// <returns></returns>
        public IDictionary<int,string> GetCurrencies()
        {
            return _databaseWrapper.GetCurrencies();
        }
    }
}
