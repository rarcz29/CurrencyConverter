using CurrencyConverter.BusinessLogic;
using System;

namespace CurrencyConverter.Presentation
{
    public class UserInterface : IUserInterface
    {
        private readonly ICurrencyBusinessLogic _currencyBusinessLogic;

        public UserInterface(ICurrencyBusinessLogic currencyBusinessLogic)
        {
            _currencyBusinessLogic = currencyBusinessLogic;
        }

        public void Run()
        {
            var availableCurrencies = _currencyBusinessLogic.GetCurrencyNamesAndCodes();

            foreach (var currency in availableCurrencies)
            {
                Console.WriteLine($"{currency.Name} (kod: {currency.Code})");
            }
        }
    }
}
