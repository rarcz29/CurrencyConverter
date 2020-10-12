using CurrencyConverter.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Presentation
{
    public static class ContainerConfig
    {
        public static ServiceProvider Configuration()
        {
            return new ServiceCollection()
                .AddSingleton<IUserInterface, UserInterface>()
                .AddCurrencyBusinessLogic()
                .BuildServiceProvider();
        }
    }
}
