using CurrencyConverter.DataAccess.Entities;
using System.Collections.Generic;

namespace CurrencyConverter.DataAccess.Repositories
{
    interface ICurrencyRepository
    {
        Currency Get(string id);
        IEnumerable<Currency> GetAll();
    }
}