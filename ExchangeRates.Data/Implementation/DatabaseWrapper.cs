using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRates.DataService
{
    public class DatabaseWrapper : IDatabaseWrapper
    {
        public IEnumerable<DateTime?> GetNonExistingDates(DateTime date, int range)
        {
            var db = new dbEntities();
            var nonExistingDates = db.GetNonExistingDates(date, range).ToList();
            return nonExistingDates;
        }

        public void SaveJsonTemplate(IDictionary<DateTime?, JsonTemplate> input)
        {
            var imports = new List<ExchangeRate>();
            
            using (var db = new dbEntities())
            {
                foreach (var t in input)
                {
                    imports.AddRange(SDSD((DateTime) t.Key, t.Value));
                }
                imports.BulkInsert(db.Database.Connection.ConnectionString, "ExchangeRate"); 
            }
        }

        public ChartModel GetRate(DateTime startDate, DateTime endDate, int first, int second)
        {
            var db = new dbEntities();

            var output = new ChartModel
            {
                Dates = new List<string>(),
                Rates = new List<double>()
            };

            var rates = db.GetRates(startDate, endDate, first, second).AsEnumerable();
            foreach (var t in rates)
            {
                output.Dates.Add((t.CurrencyDate).ToString("yyyy-MM-dd"));
                output.Rates.Add(t.Rate);
            }
            return output;
        }

        public IDictionary<int,string> GetCurrencies()
        {
            var db = new dbEntities();
            var currencies = db.Currencies.ToDictionary(t=>t.Id,t=>t.Name);
            return currencies;

        }

        private IEnumerable<ExchangeRate> SDSD(DateTime date, JsonTemplate input)
        {
            var output = new List<ExchangeRate>();
            var rub = new ExchangeRate
            {
                Id = Guid.NewGuid(),
                Currency_Id = 1,
                BaseCurrency_Id = 3,
                Rate = input.Rates.Rub,
                CurrencyDate = date
            };

            output.Add(rub);

            var eur = new ExchangeRate
            {
                Id = Guid.NewGuid(),
                Currency_Id = 2,
                BaseCurrency_Id = 3,
                Rate = input.Rates.Eur,
                CurrencyDate = date
            };

            output.Add(eur);

            var usd = new ExchangeRate
            {
                Id = Guid.NewGuid(),
                Currency_Id = 3,
                BaseCurrency_Id = 3,
                Rate = input.Rates.Usd,
                CurrencyDate = date
            };

            output.Add(usd);

            var gbp = new ExchangeRate
            {
                Id = Guid.NewGuid(),
                Currency_Id = 4,
                BaseCurrency_Id = 3,
                Rate = input.Rates.Gbp,
                CurrencyDate = date
            };

            output.Add(gbp);

            var jpy = new ExchangeRate
            {
                Id = Guid.NewGuid(),
                Currency_Id = 5,
                BaseCurrency_Id = 3,
                Rate = input.Rates.Jpy,
                CurrencyDate = date
            };
            output.Add(jpy);
            return output;
        }
    }
}
