using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.IoC
{
    class DependencyInjection
    {
        public ServiceProvider AppServiceProvider { get; set; }

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
        }
    }
}
