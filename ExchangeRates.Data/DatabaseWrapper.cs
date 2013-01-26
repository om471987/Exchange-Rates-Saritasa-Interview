using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRates
{
    public static class DatabaseWrapper
    {
        public static IEnumerable<DateTime?> GetNonExistingDates(DateTime date, int range)
        {
            var db = new dbEntities();
            var nonExistingDates = db.GetNonExistingDates(date, range).ToList();
            return nonExistingDates;
        }

        public static void SaveJsonTemplate(IDictionary<DateTime?, JsonTemplate> input)
        {
            var imports = new List<ExchangeRate>();
            
            using (var db = new dbEntities())
            {
                foreach (var t in input)
                {
                    if (t.Key != null)
                    {
                        var rub = new ExchangeRate
                        {
                            Id = Guid.NewGuid(),
                            Currency_Id = 1,
                            BaseCurrency_Id = 3,
                            Rate = t.Value.Rates.Rub,
                            CurrencyDate = (DateTime) t.Key
                        };

                        imports.Add(rub);

                        var eur = new ExchangeRate
                        {
                            Id = Guid.NewGuid(),
                            Currency_Id = 2,
                            BaseCurrency_Id = 3,
                            Rate = t.Value.Rates.Eur,
                            CurrencyDate = (DateTime) t.Key
                        };

                        imports.Add(eur);

                        var usd = new ExchangeRate
                        {
                            Id = Guid.NewGuid(),
                            Currency_Id = 3,
                            BaseCurrency_Id = 3,
                            Rate = t.Value.Rates.Usd,
                            CurrencyDate = (DateTime) t.Key
                        };

                        imports.Add(usd);

                        var gbp = new ExchangeRate
                        {
                            Id = Guid.NewGuid(),
                            Currency_Id = 4,
                            BaseCurrency_Id = 3,
                            Rate = t.Value.Rates.Gbp,
                            CurrencyDate = (DateTime) t.Key
                        };

                        imports.Add(gbp);

                        var jpy = new ExchangeRate
                        {
                            Id = Guid.NewGuid(),
                            Currency_Id = 5,
                            BaseCurrency_Id = 3,
                            Rate = t.Value.Rates.Jpy,
                            CurrencyDate = (DateTime) t.Key
                        };
                        imports.Add(jpy);
                    }
                }
                Helper.BulkInsert(db.Database.Connection.ConnectionString, "ExchangeRate", imports); 
            }
        }

        public static ChartModel GetRate(DateTime startDate, DateTime endDate, int first, int second)
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

        public static IDictionary<int,string> GetCurrencies()
        {
            var db = new dbEntities();
            var currencies = db.Currencies.ToDictionary(t=>t.Id,t=>t.Name);
            return currencies;

        }
    }
}
