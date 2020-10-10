using CurrencyConverter.DataAccess.Entities;
using System.Collections.Generic;

namespace CurrencyConverter.DataAccess.Repositories
{
    public interface ICurrencyRepository
    {
        Currency Get(string id);
        IEnumerable<Currency> GetAll();
    }
}