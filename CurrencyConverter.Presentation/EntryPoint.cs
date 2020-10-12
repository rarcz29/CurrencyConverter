using CurrencyConverter.BusinessLogic;
using CurrencyConverter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Presentation
{
    class EntryPoint
    {
        static void Main()
        {
            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUserInterface, UserInterface>()
                .AddCurrencyBusinessLogic()
                .BuildServiceProvider();

            var ui = serviceProvider.GetService<IUserInterface>(); // Get ui service
            ui.Run(); // Run ui
        }
    }
}
