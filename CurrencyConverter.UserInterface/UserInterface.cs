using CurrencyConverter.BusinessLogic;
using CurrencyConverter.DataAccess;
using System;

namespace CurrencyConverter.UserInterface
{
    class UserInterface
    {
        private CurrencyRepository _data = new CurrencyRepository();

        public void DoSomething()
        {
            var jpy = _data.Get("JPY");
            var result = ConverterService.Convert(1M, 1M, 1, jpy.ExchangeRate, jpy.ConversionFactor);
            Console.WriteLine(result);
        }
    }
}
