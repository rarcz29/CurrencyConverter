namespace CurrencyConverter.BusinessLogic
{
    class Converter
    {
        public decimal Convert(decimal amount,
                               decimal exchangeRate1, int conversionFactor1,
                               decimal exchangeRate2, int conversionFactor2)
        {
            var value1 = ConvertToPln(amount, exchangeRate1, conversionFactor1);
            var value2 = ConvertToPln(value1, exchangeRate2, conversionFactor2);

            return value2;
        }

        private decimal ConvertToPln(decimal amount, decimal exchangeRate, int conversionFactor)
        {
            return amount / exchangeRate * conversionFactor;
        }

        private decimal ConvertFromPln(decimal amount, decimal exchangeRate, int conversionFactor)
        {
            return amount * exchangeRate / conversionFactor;
        }
    }
}
