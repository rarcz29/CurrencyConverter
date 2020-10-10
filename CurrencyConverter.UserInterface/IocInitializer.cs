using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.UserInterface
{
    static class IocInitializer
    {
        static IServiceCollection Setup()
        {
            var serviceProvider = new ServiceCollection();

            serviceProvider
                .

            serviceProvider
                .

            ////configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()
            //    .AddConsole(LogLevel.Debug);

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            ////do the actual work here
            //var bar = serviceProvider.GetService<IBarService>();
            //bar.DoSomeRealWork();

            //logger.LogDebug("All done!");
        }
    }
}
