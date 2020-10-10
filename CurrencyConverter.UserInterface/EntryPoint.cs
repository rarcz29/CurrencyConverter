using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.UserInterface
{
    class EntryPoint
    {
        static void Main()
        {
            var serviceProvider = IocInitializer.Setup(); // Setup dependency injection
            var ui = serviceProvider.GetService<IUserInterface>(); // Get ui service
            ui.Run(); // Run ui
        }
    }
}
