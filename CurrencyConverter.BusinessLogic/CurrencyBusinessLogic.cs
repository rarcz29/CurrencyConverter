using CurrencyConverter.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.BusinessLogic
{
    class CurrencyBusinessLogic : ICurrencyBusinessLogic
    {
        private readonly IRepository<Currency> _currencyRepository;
        private readonly IConverter _converter;

        private Currency Pln
        {
            get => new Currency
            {
                Name = "złoty (Polska)",
                Id = "PLN",
                ExchangeRate = 1M,
                ConversionFactor = 1
            };
        }

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
                var fromCurrency = GetIncludingPln(fromCurrencyId);
                var toCurrency = GetIncludingPln(toCurrencyId);

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
                var currencies = GetAllIncludingPln();
                var currencyNamesAndCodes = new List<(string Name, string)>();

                foreach (var currency in currencies)
                {
                    currencyNamesAndCodes.Add((currency.Name, currency.Id));
                }

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
                return GetIncludingPln(code) != null;
            }
            catch
            {
                throw;
            }
        }

        private IEnumerable<Currency> GetAllIncludingPln()
        {
            try
            {
                var currencies = _currencyRepository.GetAll().ToList();
                currencies.Add(Pln);
                return currencies;
            }
            catch
            {
                throw;
            }
        }

        private Currency GetIncludingPln(string code)
        {
            var pln = Pln;

            if (code == pln.Id)
            {
                return pln;
            }

            try
            {
                return _currencyRepository.Get(code);
            }
            catch
            {
                throw;
            }
        }
    }
}
