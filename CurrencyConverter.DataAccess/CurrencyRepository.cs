using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CurrencyConverter.DataAccess
{
    public class CurrencyRepository
    {
        private DataProvider _dataProvider = new DataProvider();

        public IEnumerable<Currency> GetAll()
        {
            var dataAsString = _dataProvider.GetData();
            var parsedData = XmlParser<Currency>.Parse(dataAsString);
            //XmlSerializer deserializer = new XmlSerializer(typeof(List<Currency>), new XmlRootAttribute("tabela_kursow"));
            //List<Currency> result = (List<Currency>)deserializer.Deserialize(_data);

            //return result;
        }

        public Currency Get(string id)
        {
            throw new NotImplementedException();
            //XmlSerializer deserializer = new XmlSerializer(typeof(List<Currency>), new XmlRootAttribute("tabela_kursow"));
            //ListCurrency> result = (List<Currency>)deserializer.Deserialize(_data);

            //return result;
        }

        public void UpdateData() => _data = _dataProvider.GetData();
    }
}
