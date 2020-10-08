using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CurrencyConverter.DataAccess
{
    static class XmlParser<T>
    {
        public static IEnumerable<T> Parse(string data, string tableName)
        {
            var stringReader = CreateStringReader(data);
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Currency>), new XmlRootAttribute(tableName));
            List<T> result = (List<T>)deserializer.Deserialize(stringReader);

            return result;
        }

        private static StringReader CreateStringReader(string xmlString) => new StringReader(xmlString);
    }
}
