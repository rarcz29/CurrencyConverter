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

        public void DownloadAndSaveData()
        {
            try
            {
                _currencyRepository.DownloadAndSaveData();
            }
            catch
            {
                throw;
            }
        }

        public decimal ConvertCurrency(decimal amount, string fromCurrencyId, string toCurrencyId)
        {
            fromCurrencyId = fromCurrencyId.ToUpper();
            toCurrencyId = toCurrencyId.ToUpper();

            try
            {
                var fromCurrency = _currencyRepository.Get(fromCurrencyId);
                var toCurrency = _currencyRepository.Get(toCurrencyId);

                return _converter.Convert(amount,
                    fromCurrency.ExchangeRate, fromCurrency.ConversionFactor,
                    toCurrency.ExchangeRate, toCurrency.ConversionFactor);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<(string Name, string Code)> GetCurrencyNamesAndCodes()
        {
            try
            {
                var currencies = _currencyRepository.GetAll();
                var currencyNamesAndCodes = new List<(string Name, string)>();

                foreach (var currency in currencies)
                {
                    currencyNamesAndCodes.Add((currency.Name, currency.Id));
                }

                currencyNamesAndCodes.Add(("złoty (Polska)", "PLN"));

                return currencyNamesAndCodes.OrderBy(c => c.Name);
            }
            catch
            {
                throw;
            }
        }

        public bool CheckIfCurrencyExists(string code)
        {
            code = code.ToUpper();

            try
            {
                return _currencyRepository.Get(code) != null;
            }
            catch
            {
                throw;
            }
        }
    }
}
