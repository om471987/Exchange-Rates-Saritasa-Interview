using System.Collections.Generic;

namespace ExchangeRates.Web.Models
{
    public class ChartModel
    {
        public IEnumerable<string> Dates { get; set; }

        public IEnumerable<string> Rates { get; set; }
    }
}