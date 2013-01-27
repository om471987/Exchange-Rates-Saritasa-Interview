using System;
using System.Collections.Generic;

namespace ExchangeRates
{
    public interface IDatabaseWrapper
    {
        IEnumerable<DateTime?> GetNonExistingDates(DateTime date, int range);

        void SaveJsonTemplate(IDictionary<DateTime?, JsonTemplate> input);

        ChartModel GetRate(DateTime startDate, DateTime endDate, int first, int second);

        IDictionary<int, string> GetCurrencies();
    }
}
