using CurrencyConverter.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.BusinessLogic
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCurrencyBusinessLogic(this IServiceCollection services)
        {
            return services
                .AddTransient<IConverter, Converter>()
                .AddTransient<ICurrencyBusinessLogic, CurrencyBusinessLogic>()
                .AddDataAccess();
        }
    }
}
