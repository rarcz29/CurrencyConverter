using System.Collections.Generic;

namespace CurrencyConverter.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        T Get(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllSavedData();
        T GetSavedData(string id);
    }
}