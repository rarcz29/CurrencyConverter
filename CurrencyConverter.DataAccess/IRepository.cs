using System.Collections.Generic;

namespace CurrencyConverter.DataAccess
{
    public interface IRepository<T>
    {
        T Get(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllSavedData();
        T GetSavedData(string id);
    }
}