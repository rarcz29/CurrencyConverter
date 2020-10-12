using System.Collections.Generic;

namespace CurrencyConverter.Interfaces
{
    public interface IParser<T>
    {
        IEnumerable<T> Parse(string data, string tableName);
    }
}