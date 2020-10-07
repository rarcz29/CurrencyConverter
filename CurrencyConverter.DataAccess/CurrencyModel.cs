namespace CurrencyConverter.DataAccess
{
    public class CurrencyModel
    {
        public string Name { get; set; }
        public int Scaler { get; set; }
        public string Code { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
