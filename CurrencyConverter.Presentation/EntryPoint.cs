using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Presentation
{
    class EntryPoint
    {
        static void Main()
        {
            var serviceProvider = ContainerConfig.Configuration();
            var ui = serviceProvider.GetService<IUserInterface>();
            ui.Run();
        }
    }
}
