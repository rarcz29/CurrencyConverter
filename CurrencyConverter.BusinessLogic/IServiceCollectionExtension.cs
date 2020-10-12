using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.BusinessLogic
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCurrencyConverter(this IServiceCollection services)
        {
            services.AddTransient<IConverter, Converter>();
            return services;
        }
    }
}
