using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates
{
    public class Manager
    {
        public ChartModel GetData(DateTime startDate, DateTime endDate, int list1, int list2)
        {
            var range = (endDate - startDate).Days + 1;
            var dates = DatabaseWrapper.GetNonExistingDates(startDate, range);
            var dateTimes = dates as IList<DateTime?> ?? dates.ToList();

            if (dateTimes.Any())
            {
                var b = new OpenExchangeRatesService();
                var c = new ConcurrentDictionary<DateTime?, JsonTemplate>();
                Parallel.ForEach(dateTimes, t =>
                    {
                        c.TryAdd(t, b.GetAndStore(t));
                    });
                DatabaseWrapper.SaveJsonTemplate(c);
            }
            return DatabaseWrapper.GetRate(startDate, endDate, list1, list2);
        }
    }
}
