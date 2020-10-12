using CurrencyConverter.DataAccess.Repositories;
using System.Collections;

namespace CurrencyConverter.BusinessLogic
{
    class CurrencyBusinessLogic
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly Converter _converter;

        public CurrencyBusinessLogic(ICurrencyRepository currencyRepository, Converter converter)
        {
            _currencyRepository = currencyRepository;
            _converter = converter;
        }

        public IEnumerable<I>
    }
}
