using System;

namespace CurrencyConverter.BusinessLogic
{
    class Converter : IConverter
    {
        public decimal Convert(decimal amount,
            decimal exchangeRate1, int conversionFactor1,
            decimal exchangeRate2, int conversionFactor2)
        {
            var pln = ConvertToPln(amount, exchangeRate1, conversionFactor1);
            var result = ConvertFromPln(pln, exchangeRate2, conversionFactor2);

            return Math.Round(result, 2);
        }

        private decimal ConvertToPln(decimal amount, decimal exchangeRate, int conversionFactor)
        {
            return amount * exchangeRate / conversionFactor;
        }

        private decimal ConvertFromPln(decimal amount, decimal exchangeRate, int conversionFactor)
        {
            return amount / exchangeRate * conversionFactor;
        }
    }
}
