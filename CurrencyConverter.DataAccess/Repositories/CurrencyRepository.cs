using CurrencyConverter.DataAccess.Entities;
using CurrencyConverter.DataAccess.Services;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.DataAccess.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private const string _TableName = "tabela_kursow";
        private IDataProvider _dataProvider;
        private IEnumerable<Currency> _savedData;

        public CurrencyRepository(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void DownloadAndSaveData()
        {
            _savedData = GetAllElements();
        }

        /// <summary>
        /// Method downloads data from the API
        /// </summary>
        /// <returns>parsed data from xml</returns>
        public IEnumerable<Currency> GetAll()
        {
            return GetAllElements();
        }

        /// <summary>
        /// Method downloads data from the API and returns one record of the given ID
        /// </summary>
        /// <param name="id">ID of an entity</param>
        /// <returns>one record from parsed data</returns>
        public Currency Get(string id)
        {
            return GetAllElements()
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Currency> 

        private IEnumerable<Currency> GetAllElements()
        {
            var dataAsString = _dataProvider.GetData();
            var parsedData = XmlParser<Currency>.Parse(dataAsString, _TableName);

            return parsedData;
        }
    }
}
