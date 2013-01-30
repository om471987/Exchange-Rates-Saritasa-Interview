using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Configuration;
using System.Globalization;

namespace ExchangeRates.DataService
{
    public class OpenExchangeRatesService : IExchangeRatesService
    {
        private const string HistoryUrl = "http://openexchangerates.org/api/historical/";
        private static readonly string _api = ConfigurationManager.AppSettings["OpenExchangeRateId"].ToString();
        /// <summary>
        /// It finds and parses json from open exchange rates and converts to C# object
        /// </summary>
        /// <param name="dateObj"></param>
        /// <returns></returns>
        public JsonTemplate GetHistoricalExchangeRate(DateTime? dateObj)
        {
            JsonTemplate output = null;
            using (var client = new WebClient())
            {
                var url = BuildUrl((DateTime)dateObj);
                try
                {
                    var data = client.OpenRead(url);
                    if (data != null)
                    {
                        var reader = new StreamReader(data);
                        var data1 = reader.ReadToEnd();
                        output = JsonConvert.DeserializeObject(data1, typeof(JsonTemplate)) as JsonTemplate;
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }

            }
            return output;
        }

        /// <summary>
        /// Builds url
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static string BuildUrl(DateTime date)
        {
            var url = new StringBuilder(HistoryUrl);
            url.Append(date.ToString("yyyy-MM-dd"));
            url.Append(".json?app_id=");
            url.Append(_api);
            return url.ToString();
        }
    }
}
