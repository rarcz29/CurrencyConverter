using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.DataAccess
{
    public class CurrencyRepository
    {
        private DataProvider _dataProvider = new DataProvider();
        private const string _TableName = "tabela_kursow";

        public IEnumerable<Currency> GetAll()
        {
            var dataAsString = _dataProvider.GetData();
            var parsedData = XmlParser<Currency>.Parse(dataAsString, _TableName);

            return parsedData;
        }

        public Currency Get(string id)
        {
            var dataAsString = _dataProvider.GetData();
            var parsedData = XmlParser<Currency>.Parse(dataAsString, _TableName)
                                .Where(e => e.Id == id)
                                .FirstOrDefault();

            return parsedData;
        }
    }
}
