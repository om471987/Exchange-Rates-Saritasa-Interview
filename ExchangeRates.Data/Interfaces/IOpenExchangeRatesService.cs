using System;

namespace ExchangeRates.DataService
{
    public interface IOpenExchangeRatesService
    {
        JsonTemplate GetHistoricalExchangeRate(DateTime? dateObj);
    }
}
