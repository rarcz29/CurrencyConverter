using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CurrencyConverter.DataAccess
{
    public class DataRepository
    {
        private DataProvider _dataProvider = new DataProvider();
        private StringReader _data;

        public DataRepository()
        {
            _data = _dataProvider.GetData();
        }

        public IEnumerable<Currency> GetAll()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Currency>), new XmlRootAttribute("tabela_kursow"));
            List<Currency> result = (List<Currency>)deserializer.Deserialize(_data);

            return result;
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
