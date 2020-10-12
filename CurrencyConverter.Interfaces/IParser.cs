using System.Collections.Generic;

namespace CurrencyConverter.DataAccess
{
    public interface IParser<T>
    {
        IEnumerable<T> Parse(string data, string tableName);
    }
}