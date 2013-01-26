using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ExchangeRates
{
    public class OpenExchangeRatesService
    {
        private const string HistoryUrl = "http://openexchangerates.org/api/historical/";
        private const string Api = "d12f21ee93c541d1afca88163aa2eb3f";

        public JsonTemplate GetAndStore(object dateObj)
        {
            JsonTemplate output;
            using (var client = new WebClient())
            {
                var url = BuildString((DateTime) dateObj);
                var data = client.OpenRead(url);

                var reader = new StreamReader(data);
                var data1 = reader.ReadToEnd();
                output = JsonConvert.DeserializeObject(data1, typeof (JsonTemplate)) as JsonTemplate;
            }
            return output;
        }

        private string BuildString(DateTime date)
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

    public class ChartModel
    {
        public List<string> Dates { get; set; }

        public List<double> Rates { get; set; }
    }
}
