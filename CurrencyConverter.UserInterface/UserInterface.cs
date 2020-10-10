using CurrencyConverter.DataAccess.Repositories;
using System;

namespace CurrencyConverter.UserInterface
{
    class UserInterface
    {
        private readonly ICurrencyRepository _data;

        public UserInterface(ICurrencyRepository currencyRepository)
        {
            _data = currencyRepository;
        }

        public void DoSomething()
        {
            var eur = _data.Get("EUR");
            Console.ReadKey();
        }
    }
}
