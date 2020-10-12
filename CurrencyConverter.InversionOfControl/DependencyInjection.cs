using CurrencyConverter.BusinessLogic;
using CurrencyConverter.DataAccess;
using CurrencyConverter.UserInterface;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.IoC
{
    class DependencyInjection
    {
        public ServiceProvider AppServiceProvider { get; private set; }

        public DependencyInjection()
        {
            Initialize();
        }

        private void Initialize()
        {
            var serviceProvider = new ServiceCollection()
                .AddXmlDataConnector()
                .AddCurrencyConverter()
                .AddSingleton<IUserInterface, UserInterface>()
                .BuildServiceProvider();

            AppServiceProvider = serviceProvider;
        }
    }
}
