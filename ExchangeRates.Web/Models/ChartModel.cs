using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRates.Web.Models
{
    public class ChartModel
    {
        public IEnumerable<string> Dates { get; set; }

        public IEnumerable<string> Rates { get; set; }
    }
}