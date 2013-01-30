using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRates.DataService
{
    public class DatabaseWrapper : IDatabaseWrapper
    {
        /// <summary>
        /// This invokes a stored procedure which returns dates from the range which are not present
        /// </summary>
        /// <param name="date"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public IEnumerable<DateTime?> GetNonExistingDates(DateTime date, int range)
        {
            var db = new dbEntities();
            var nonExistingDates = db.GetNonExistingDates(date, range).ToList();
            return nonExistingDates;
        }

        /// <summary>
        /// It parses json and stores into database
        /// </summary>
        /// <param name="input"></param>
        public void SaveJsonTemplate(IDictionary<DateTime?, JsonTemplate> input)
        {
            var imports = new List<ExchangeRate>();
            
            using (var db = new dbEntities())
            {
                foreach (var t in input)
                {
                    var rateCollection = SaveRatesForADay((DateTime) t.Key, t.Value);
                    if (rateCollection != null)
                    {
                        imports.AddRange(rateCollection);
                    }
                }
                imports.BulkInsert(db.Database.Connection.ConnectionString, "ExchangeRate"); 
            }
        }

        /// <summary>
        /// It gets final data and returns to display as a graph
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
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

        /// <summary>
        /// It returns list of valid currencies
        /// </summary>
        /// <returns></returns>
        public IDictionary<int,string> GetCurrencies()
        {
            var db = new dbEntities();
            var currencies = db.Currencies.ToDictionary(t=>t.Id,t=>t.Name);
            return currencies;

        }

        private IEnumerable<ExchangeRate> SaveRatesForADay(DateTime date, JsonTemplate input)
        {
            if (input == null)
            {
                return null;
            }
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
