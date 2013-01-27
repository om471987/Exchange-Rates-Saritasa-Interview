using System;
using System.Collections.Generic;

namespace ExchangeRates
{
    public interface IManager
    {
        ChartModel GetData(DateTime startDate, DateTime endDate, int list1, int list2);

        IDictionary<int, string> GetCurrencies();
    }
}
