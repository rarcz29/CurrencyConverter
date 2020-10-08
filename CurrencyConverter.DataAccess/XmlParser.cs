using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CurrencyConverter.DataAccess
{
    class XmlParser<T>
    {
        public IEnumerable<T> Parse(StringReader sr)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Currency>), new XmlRootAttribute("tabela_kursow"));
            List<T> result = (List<T>)deserializer.Deserialize(sr);

            return result;
        }

        private StringReader CreateStringReader(string xmlString) => new StringReader(xmlString);
    }
}
