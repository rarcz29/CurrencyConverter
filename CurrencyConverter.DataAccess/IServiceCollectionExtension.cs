using CurrencyConverter.DataAccess.Repositories;
using CurrencyConverter.DataAccess.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.DataAccess
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddXmlDataConnector(this IServiceCollection services)
        {
            services.AddTransient<IDataProvider, DataProvider>()
                    .AddSingleton<ICurrencyRepository, CurrencyRepository>();

            return services;
        }
    }
}
