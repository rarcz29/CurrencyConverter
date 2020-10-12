using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.DataAccess
{
    public class CurrencyRepository : IRepository<Currency>
    {
        private const string _TableName = "tabela_kursow";
        private readonly IDataProvider _dataProvider;
        private readonly IParser<Currency> _xmlParser;
        private IEnumerable<Currency> _savedData = null;

        public CurrencyRepository(IDataProvider dataProvider, IParser<Currency> xmlParser)
        {
            _dataProvider = dataProvider;
            _xmlParser = xmlParser;
        }

        public void DownloadAndSaveData()
        {
            try
            {
                var currencies = GetAndParseData();
                SaveData(currencies);
            }
            catch
            {
                throw;
            }
        }

        /// <returns>data saved in the repository</returns>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when data is null
        /// </exception>
        public IEnumerable<Currency> GetAll()
        {
            try
            {
                CheckDataAvailability();
            }
            catch
            {
                throw;
            }

            return _savedData;
        }

        /// <param name="id">ID of an entity</param>
        /// <returns>one record from the saved data</returns>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when data is null
        /// </exception>
        public Currency Get(string id)
        {
            try
            {
                CheckDataAvailability();
            }
            catch
            {
                throw;
            }

            return _savedData
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Get data from the data provider
        /// </summary>
        /// <returns>parsed data</returns>
        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        private IEnumerable<Currency> GetAndParseData()
        {
            string dataAsString;

            try
            {
                dataAsString = _dataProvider.GetData();
            }
            catch
            {
                throw;
            }

            var parsedData = _xmlParser.Parse(dataAsString, _TableName);

            return parsedData;
        }

        private void CheckDataAvailability()
        {
            if (_savedData == null)
            {
                throw new NullReferenceException("There is no saved data");
            }
        }

        private IEnumerable<Currency> SaveData(IEnumerable<Currency> data) => _savedData = data;
    }
}
