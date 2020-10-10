using CurrencyConverter.BusinessLogic;
using CurrencyConverter.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.UserInterface
{
    static class IocInitializer
    {
        public static ServiceProvider Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddXmlDataConnector()
                .AddCurrencyConverter()
                .AddSingleton<IUserInterface, UserInterface>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
