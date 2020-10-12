namespace CurrencyConverter.DataAccess.Entities
{
    public interface ICurrency
    {
        int ConversionFactor { get; set; }
        decimal ExchangeRate { get; set; }
        string Id { get; set; }
        string Name { get; set; }
    }
}