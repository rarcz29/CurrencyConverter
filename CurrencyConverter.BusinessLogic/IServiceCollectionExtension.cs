using CurrencyConverter.DataAccess;
using CurrencyConverter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.BusinessLogic
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCurrencyBusinessLogic(this IServiceCollection services)
        {
            return services
                .AddTransient<IConverter, Converter>()
                .AddXmlDataConnector();
        }
    }
}
