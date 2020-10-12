using System.Collections.Generic;

namespace CurrencyConverter.BusinessLogic
{
    public interface ICurrencyBusinessLogic
    {
        void DownloadAndSaveData();
        decimal ConvertCurrency(decimal amount, string fromCurrencyId, string toCurrencyId);
        IEnumerable<(string Name, string Code)> GetCurrencyNamesAndCodes();
    }
}