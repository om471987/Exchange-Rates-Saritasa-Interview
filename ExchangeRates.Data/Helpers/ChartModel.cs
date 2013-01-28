using System.Collections.Generic;

namespace ExchangeRates.DataService

{
    /// <summary>
    /// It stores dates and rates of x and y axis
    /// </summary>
    public class ChartModel
    {
        public List<string> Dates { get; set; }

        public List<double> Rates { get; set; }
    }

    /// <summary>
    /// It is a templates to grab data from Json
    /// </summary>
    public class JsonTemplate
    {
        public string Base { get; set; }
        public Rates Rates { get; set; }
    }

    public class Rates
    {
        public double Usd { get; set; }
        public double Gbp { get; set; }
        public double Rub { get; set; }
        public double Eur { get; set; }
        public double Jpy { get; set; }
    }
}