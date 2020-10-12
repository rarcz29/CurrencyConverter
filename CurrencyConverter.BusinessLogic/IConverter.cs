namespace CurrencyConverter.BusinessLogic
{
    public interface IConverter
    {
        decimal Convert(decimal amount, decimal exchangeRate1, int conversionFactor1, decimal exchangeRate2, int conversionFactor2);
    }
}