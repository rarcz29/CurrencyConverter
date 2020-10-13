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
            DownloadData();
            WriteCurrencyNamesAndCodes();
            NewLine();

            if (!ReadCurrencyCode("Podaj walutę początkową (kod waluty)", out string fromCurrencyCode) ||
                !ReadCurrencyCode("Podaj walutę końcową (kod waluty)", out string toCurrencyCode))
            {
                Console.WriteLine("Podano nieistniejącą walutę. Aplikacja zostanie zamknięta.");
                CloseApp();
                return;
            }

            NewLine();

            if (!ReadAmountOfMoney(out decimal amount))
            {
                Console.WriteLine("Podano niepoprawne dane. Aplikacja zostanie zamknięta.");
                CloseApp();
            }

            NewLine();

            try
            {
                var result = _currencyBusinessLogic.ConvertCurrency(amount, fromCurrencyCode, toCurrencyCode);
                Console.WriteLine($"Wynik to {result} {toCurrencyCode.ToUpper()}");
            }
            catch
            {
                Console.WriteLine("Wystąpił błąd podczas przeliczania waluty. Aplikacja zostanie zamknięta");
            }

            Console.ReadKey();
        }

        private void DownloadData()
        {
            try
            {
                _currencyBusinessLogic.DownloadAndSaveData();
            }
            catch
            {
                Console.WriteLine("Nie udało się pobrać danych. " +
                    "Sprawdź swoje połączenie internetowe. " +
                    "Aplikacja zostanie zamknięta.");

                CloseApp();
            }
        }

        private void WriteCurrencyNamesAndCodes()
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
                Console.WriteLine("Nie udało się odczytać danych. Aplikacja zostanie zamknięta.");
                CloseApp();
            }
        }

        /// <returns>true if currency exists</returns>
        private bool ReadCurrencyCode(string message, out string code)
        {
            Console.WriteLine(message);
            code = Console.ReadLine();

            try
            {
                return _currencyBusinessLogic.CheckIfCurrencyExists(code);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Brak zapisanych danych. " +
                    "Aplikacja zostanie zamknięta.");
                CloseApp();
                return false;
            }
        }

        private bool ReadAmountOfMoney(out decimal amountOfMoney)
        {
            Console.WriteLine("Podaj kwotę (część ułamkową oddziel kropką)");
            var amount = Console.ReadLine();

            try
            {
                amountOfMoney = Decimal.Parse(amount);
                return true;
            }
            catch
            {
                amountOfMoney = 0M;
                return false;
            }
        }

        private void CloseApp()
        {
            Console.ReadKey();
            Environment.Exit(1);
        }

        private void NewLine() => Console.WriteLine();
    }
}
