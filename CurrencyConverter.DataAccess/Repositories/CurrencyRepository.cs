using CurrencyConverter.DataAccess.Entities;
using CurrencyConverter.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.DataAccess.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private const string _TableName = "tabela_kursow";
        private IDataProvider _dataProvider;
        private IParser<Currency> _xmlParser;
        private IEnumerable<Currency> _savedData;

        public CurrencyRepository(IDataProvider dataProvider, IParser<Currency> xmlParser)
        {
            _dataProvider = dataProvider;
            _xmlParser = xmlParser;
        }

        public void DownloadAndSaveData()
        {
            _savedData = GetAllElements();
        }

        /// <summary>
        /// It downloads and returns data from the API
        /// </summary>
        /// <returns>parsed data from xml</returns>
        public IEnumerable<Currency> GetAll()
        {
            return GetAllElements();
        }

        /// <summary>
        /// It downloads data from the API and returns one record of the given ID
        /// </summary>
        /// <param name="id">ID of an entity</param>
        /// <returns>one record from parsed data</returns>
        public Currency Get(string id)
        {
            return GetAllElements()
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        /// <returns>data saved in the repository</returns>
        /// <exception cref="System.NullReferenceException">
        /// Throw when data is null
        /// </exception>
        public IEnumerable<Currency> GetAllSavedData()
        {
            try
            {
                CheckDataAvailability();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }

            return _savedData;
        }

        /// <param name="id">ID of an entity</param>
        /// <returns>one record from the saved data</returns>
        /// <exception cref="System.NullReferenceException">
        /// Throw when data is null
        /// </exception>
        public Currency GetSavedData(string id)
        {
            try
            {
                CheckDataAvailability();
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }

            return _savedData
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        private IEnumerable<Currency> GetAllElements()
        {
            var dataAsString = _dataProvider.GetData();
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
    }
}
