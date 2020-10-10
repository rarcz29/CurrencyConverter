using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CurrencyConverter.DataAccess
{
    class XmlParser<T> : IParser<T>
    {
        public IEnumerable<T> Parse(string data, string tableName)
        {
            var stringReader = CreateStringReader(data);
            var deserializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(tableName));
            var result = (List<T>)deserializer.Deserialize(stringReader);

            return result;
        }

        private StringReader CreateStringReader(string xmlString) => new StringReader(xmlString);
    }
}
