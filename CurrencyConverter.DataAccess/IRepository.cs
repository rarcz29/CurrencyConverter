using System.Collections.Generic;

namespace CurrencyConverter.DataAccess
{
    public interface IRepository<T>
    {
        void DownloadAndSaveData();
        Currency Get(string id);
        IEnumerable<Currency> GetAll();
    }
}