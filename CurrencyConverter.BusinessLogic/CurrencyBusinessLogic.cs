using CurrencyConverter.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.BusinessLogic
{
    class CurrencyBusinessLogic : ICurrencyBusinessLogic
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
            IEnumerable<Currency> currencies;
            Currency fromCurrency;
            Currency toCurrency;

            try
            {
                currencies = _currencyRepository.GetAll();
                fromCurrency = currencies.Where(c => c.Id == fromCurrencyId).FirstOrDefault();
                toCurrency = currencies.Where(c => c.Id == toCurrencyId).FirstOrDefault();
            }
            catch
            {
                try
                {
                    fromCurrency = _currencyRepository.GetSavedData(fromCurrencyId);
                    toCurrency = _currencyRepository.GetSavedData(toCurrencyId);
                }
                catch
                {
                    throw;
                }
            }

            return _converter.Convert(amount, fromCurrency.ExchangeRate, fromCurrency.ConversionFactor,
                toCurrency.ExchangeRate, toCurrency.ConversionFactor);
        }

        public IEnumerable<(string Name, string Code)> GetCurrencyNamesAndCodes()
        {
            List<(string, string)> currencyNamesAndCodes = new List<(string, string)>();
            IEnumerable<Currency> currencies;

            try
            {
                currencies = _currencyRepository.GetAll();
            }
            catch
            {
                try
                {
                    currencies = _currencyRepository.GetAllSavedData();
                }
                catch
                {
                    throw;
                }
            }

            foreach (var currency in currencies)
            {
                currencyNamesAndCodes.Add((currency.Name, currency.Id));
            }

            return currencyNamesAndCodes;
        }
    }
}
