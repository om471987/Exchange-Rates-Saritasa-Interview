using System;

namespace ExchangeRates
{
    public interface IOpenExchangeRatesService
    {
        JsonTemplate GetHistoricalExchangeRate(DateTime? dateObj);
    }
}
