using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.DataAccess
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            return services
                .AddTransient<IDataProvider, DataProvider>()
                .AddTransient(typeof(IParser<>), typeof(XmlParser<>))
                .AddSingleton<IRepository<Currency>, CurrencyRepository>();
        }
    }
}
