using CurrencyConverter.DataAccess;
using System.Collections.Generic;

namespace CurrencyConverter.BusinessLogic
{
    class CurrencyBusinessLogic
    {
        private readonly IRepository<Currency> _currencyRepository;
        private readonly IConverter _converter;

        public CurrencyBusinessLogic(IRepository<Currency> currencyRepository, IConverter converter)
        {
            _currencyRepository = currencyRepository;
            _converter = converter;
        }

        public decimal ConvertCurrency(decimal amount, string fromCurrencyId, string toCurrencyId)
        {
            Currency fromCurrency;
            Currency toCurrency;

            try
            {
                fromCurrency = _currencyRepository.Get(fromCurrencyId);
                toCurrency = _currencyRepository.Get(toCurrencyId);
            }
            catch
            {
                throw;
            }
            

            return _converter.Convert(amount, fromCurrency.ExchangeRate, fromCurrency.ConversionFactor,
                toCurrency.ExchangeRate, toCurrency.ConversionFactor);
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            try
            {
                var allCurrencies = _currencyRepository.GetAll();
                return allCurrencies;
            }
            catch
            {
                throw;
            }
        }
    }
}
