using System;

namespace ExchangeRates.DataService
{
    /// <summary>
    /// Consumes web service of exchange rates
    /// </summary>
    public interface IExchangeRatesService
    {
        /// <summary>
        /// It finds and parses json from open exchange rates and converts to C# object
        /// </summary>
        /// <param name="dateObj"></param>
        /// <returns></returns>
        JsonTemplate GetHistoricalExchangeRate(DateTime? dateObj);
    }
}
