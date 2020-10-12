using CurrencyConverter.BusinessLogic;
using System;

namespace CurrencyConverter.Presentation
{
    public class UserInterface : IUserInterface
    {
        private string _ExceptionMessage = "Nie można odczytać danych. " +
            "Sprawdź swoje połączenie internetowe.";

        private readonly ICurrencyBusinessLogic _currencyBusinessLogic;

        public UserInterface(ICurrencyBusinessLogic currencyBusinessLogic)
        {
            _currencyBusinessLogic = currencyBusinessLogic;
        }

        public void Run()
        {
            try
            {
                var availableCurrencies = _currencyBusinessLogic.GetCurrencyNamesAndCodes();

                foreach (var currency in availableCurrencies)
                {
                    Console.WriteLine($"{currency.Name} (kod: {currency.Code})");
                }
            }
            catch
            {
                Console.WriteLine(_ExceptionMessage);
            }
        }
    }
}
