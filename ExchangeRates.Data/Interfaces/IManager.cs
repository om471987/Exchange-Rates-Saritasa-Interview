using System;
using System.Collections.Generic;

namespace ExchangeRates.DataService
{
    /// <summary>
    /// Manages database and web services.
    /// </summary>
    public interface IManager
    {
        ChartModel GetRateCollection(DateTime startDate, DateTime endDate, int list1, int list2);

        IDictionary<int, string> GetCurrencies();
    }
}
