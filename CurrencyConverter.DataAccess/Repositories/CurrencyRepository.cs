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
        private readonly IDataProvider _dataProvider;
        private readonly IParser<Currency> _xmlParser;
        private IEnumerable<Currency> _savedData;

        public CurrencyRepository(IDataProvider dataProvider, IParser<Currency> xmlParser)
        {
            _dataProvider = dataProvider;
            _xmlParser = xmlParser;
        }

        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        public void DownloadAndSaveData()
        {
            try
            {
                _savedData = GetAllElements();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// It downloads and returns data from the API
        /// </summary>
        /// <returns>parsed data from xml</returns>
        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        public IEnumerable<Currency> GetAll()
        {
            IEnumerable<Currency> allElements;

            try
            {
                allElements = GetAllElements();
            }
            catch
            {
                throw;
            }

            return allElements;
        }

        /// <summary>
        /// It downloads data from the API and returns one record of the given ID
        /// </summary>
        /// <param name="id">ID of an entity</param>
        /// <returns>one record from parsed data</returns>
        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        public Currency Get(string id)
        {
            IEnumerable<Currency> allElements;

            try
            {
                allElements = GetAllElements();
            }
            catch
            {
                throw;
            }

            return allElements
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        /// <returns>data saved in the repository</returns>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when data is null
        /// </exception>
        public IEnumerable<Currency> GetAllSavedData()
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
        public Currency GetSavedData(string id)
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

        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        private IEnumerable<Currency> GetAllElements()
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
    }
}
