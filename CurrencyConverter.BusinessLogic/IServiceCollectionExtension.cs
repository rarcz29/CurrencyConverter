using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.BusinessLogic
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddXmlDataConnector(this IServiceCollection services)
        {
            services.AddTransient<IConverterService, ConverterService>();
            return services;
        }
    }
}
