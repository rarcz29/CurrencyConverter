using CurrencyConverter.DataAccess.Repositories;
using System;

namespace CurrencyConverter.UserInterface
{
    class UserInterface : IUserInterface
    {
        private readonly ICurrencyRepository _data;

        public UserInterface(ICurrencyRepository currencyRepository)
        {
            _data = currencyRepository;
        }

        public void Run()
        {
            var eur = _data.Get("EUR");
            Console.ReadKey();
        }
    }
}
