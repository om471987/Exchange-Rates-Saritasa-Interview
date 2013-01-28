using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ExchangeRates.DataService
{
    public class OpenExchangeRatesService : IOpenExchangeRatesService
    {
        private const string HistoryUrl = "http://openexchangerates.org/api/historical/";
        private const string Api = "76ff8a4dec2e45bebcf5646b3d517187";

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
            url.Append(date.Year);
            url.Append("-");
            url.Append(date.Month < 10 ? "0" : "");
            url.Append(date.Month);
            url.Append("-");
            url.Append(date.Day < 10 ? "0" : "");
            url.Append(date.Day);
            url.Append(".json?app_id=");
            url.Append(Api);
            return url.ToString();
        }
    }
}
