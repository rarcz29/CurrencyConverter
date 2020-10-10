using System.Collections.Generic;

namespace CurrencyConverter.DataAccess
{
    interface IXmlParser<T>
    {
        IEnumerable<T> Parse(string data, string tableName);
    }
}