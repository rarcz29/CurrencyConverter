using CurrencyConverter.DataAccess.Data;
using CurrencyConverter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.DataAccess.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private const string _TableName = "tabela_kursow";
        private IDataProvider _dataProvider;

        public CurrencyRepository(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

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
