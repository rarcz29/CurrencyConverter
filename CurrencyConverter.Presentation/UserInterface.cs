using CurrencyConverter.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;

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
            //decimal result = 0M;
            //List<string> currencyCodes;

            //try
            //{
            //    var availableCurrencies = _currencyBusinessLogic.GetCurrencyNamesAndCodes();

            //    foreach (var currency in availableCurrencies)
            //    {
            //        Console.WriteLine($"{currency.Name} (kod: {currency.Code})");
            //    }

            //    currencyCodes = availableCurrencies.Select(c => c.Code).ToList();
            //}
            //catch
            //{
            //    Console.WriteLine("Nie udało się pobrać danych. Sprawdź swoje połączenie internetowe");
            //    return;
            //}

            //Console.WriteLine("Podaj walutę początkową");
            //var fromCurrency = Console.ReadLine();

            //if (!CheckIfCurrencyExists(fromCurrency, currencyCodes))
            //{
            //    ExitWrongCurrencyCode();
            //}

            //Console.WriteLine("Podaj walutę końcową");
            //var toCurrency = Console.ReadLine();

            //if (!CheckIfCurrencyExists(toCurrency, currencyCodes))
            //{
            //    ExitWrongCurrencyCode();
            //}

            //Console.WriteLine("Podaj kwotę (część ułamkową odziel kropką)");
            //var amount = Console.ReadLine();

            //try
            //{
            //    var parsedAmount = Decimal.Parse(amount);
            //    result = _currencyBusinessLogic.ConvertCurrency(parsedAmount, fromCurrency, toCurrency);
            //}
            //catch
            //{
            //    Console.WriteLine("Nie udało się obliczyć wartości");
            //}

            //Console.WriteLine($"Obliczona wartość to: {result}");
        }

        private bool CheckIfCurrencyExists(string code, IEnumerable<string> codes)
        {
            return codes.Where(c => c == code).Count() > 0;
        }

        private void ExitWrongCurrencyCode()
        {
            Console.WriteLine("Ta waluta nie istnieje");
            Console.WriteLine("Aplikacja zostanie zamknięta");
        }
    }
}
