using CurrencyConverter.BusinessLogic;
//using CurrencyConverter.DataAccess.Entities;
//using CurrencyConverter.DataAccess.Repositories;
using System;
using System.Text;

namespace CurrencyConverter.UserInterface
{
    public class UserInterface : IUserInterface
    {
        ////private readonly ICurrencyRepository _data;
        //private readonly IConverter _converterService;

        //public UserInterface(IConverter converterService)
        //{
        //    _converterService = converterService;
        //    Console.OutputEncoding = Encoding.UTF8;
        }

        public void Run()
        {
            //var eur = _data.Get("EUR");
            //Console.ReadKey();

            //Console.WriteLine("Podaj walutę 1");
            //var waluta1 = Console.ReadLine();

            //Console.WriteLine("Podaj walutę 2");
            //var waluta2 = Console.ReadLine();

            //var waluta1objekt = _data.Get(waluta1);
            //var waluta2objekt = _data.Get(waluta2);

            //Console.WriteLine("Podaj kwotę");
            //var kwota = Int32.Parse(Console.ReadLine());

            //var wynik = _converterService.Convert(kwota,
            //    waluta1objekt.ExchangeRate, waluta1objekt.ConversionFactor,
            //    waluta2objekt.ExchangeRate, waluta2objekt.ConversionFactor);

            //Console.WriteLine($"Otrzymana kwota to {wynik}");

            PrintCurrencyNamesWithCodes();
        }

        private void PrintCurrencyNamesWithCodes()
        {
            //var currencies = _data.GetAll();

            //foreach (var currency in currencies)
            //{
            //    Console.WriteLine($"{currency.Name} (kod: {currency.Id})");
            //}
        }

        private string ReadCurrencyCode(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().ToUpper();
        }

        //private Currency GetAllCurrencies()
        //{
        //    Currency currency;

        //    try
        //    {
        //        currency = _data.GetAll();
        //    }
        //    catch (WebException)
        //    {
        //        Console.WriteLine("Błąd połączenia z internetem");
        //        Console.WriteLine("Następuje próba pobrania lokalnie zapisanych danych");
        //        HandleGetAllDataWebException();
        //    }

        //    return currency;
        //}

        //private void HandleGetDataWebException(string code)
        //{
        //    IEnumerable<Currency> currency;

        //    try
        //    {
        //        currency = _data.GetAllSavedData();
        //        Console.WriteLine("Udało się odczytać dane");
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Błąd!!!: Nie można pobrać danych");
        //    }
        //}

        //private Currency GetCurrency(string code)
        //{
        //    Currency currency;

        //    try
        //    {
        //        currency = _data.Get(code);
        //    }
        //    catch (WebException)
        //    {
        //        Console.WriteLine("Błąd połączenia z internetem");
        //        Console.WriteLine("Następuje próba pobrania lokalnie zapisanych danych");
        //        HandleGetDataWebException(code);
        //    }

        //    return _data.Get(code);
        //}

        //private void HandleGetDataWebException(string code)
        //{
        //    try
        //    {
        //        _data.GetSavedData(code);
        //        Console.WriteLine("Udało się odczytać dane");
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Błąd!!!: Nie można pobrać danych");
        //    }
        //}
    }
}
