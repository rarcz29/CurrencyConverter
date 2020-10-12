using CurrencyConverter.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.BusinessLogic
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCurrencyBusinessLogic(this IServiceCollection services)
        {
            return services
                .AddTransient<IDataProvider, DataProvider>()
                .AddTransient(typeof(IParser<>), typeof(XmlParser<>))
                .AddSingleton<IRepository<Currency>, CurrencyRepository>()
                .AddTransient<IConverter, Converter>()
                .AddTransient<ICurrencyBusinessLogic, CurrencyBusinessLogic>();
        }
    }
}
