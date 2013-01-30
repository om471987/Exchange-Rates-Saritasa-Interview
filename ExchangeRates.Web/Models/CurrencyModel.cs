using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace ExchangeRates.Web.Models
{
    public class CurrencyModel
    {
        public CurrencyModel(IEnumerable<KeyValuePair<int, string>> currencies)
        {
            Currencies = (from t in currencies select new SelectListItem { Text = t.Value,Value = t.Key.ToString(CultureInfo.InvariantCulture)}).AsEnumerable();
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<SelectListItem> Currencies;
    }
}