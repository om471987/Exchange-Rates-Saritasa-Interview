namespace ExchangeRates
{
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
