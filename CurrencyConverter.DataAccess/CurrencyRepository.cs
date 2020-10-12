using CurrencyConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.DataAccess
{
    public class CurrencyRepository : IRepository<ICurrency>
    {
        private const string _TableName = "tabela_kursow";
        private readonly IDataProvider _dataProvider;
        private readonly IParser<ICurrency> _xmlParser;
        private IEnumerable<ICurrency> _savedData;

        public CurrencyRepository(IDataProvider dataProvider, IParser<ICurrency> xmlParser)
        {
            _dataProvider = dataProvider;
            _xmlParser = xmlParser;
        }

        /// <summary>
        /// It downloads, saves and returns data from the API
        /// </summary>
        /// <returns>parsed data from xml</returns>
        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        public IEnumerable<ICurrency> GetAll()
        {
            IEnumerable<ICurrency> allElements;

            try
            {
                allElements = GetAllElements();
            }
            catch
            {
                throw;
            }

            return SaveData(allElements);
        }

        /// <summary>
        /// It downloads data from the API, saves them and returns one record of the given ID
        /// </summary>
        /// <param name="id">ID of an entity</param>
        /// <returns>one record from parsed data</returns>
        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        public ICurrency Get(string id)
        {
            IEnumerable<ICurrency> allElements;

            try
            {
                allElements = GetAllElements();
            }
            catch
            {
                throw;
            }

            // Methode saves all elements then
            // one record is returned
            return SaveData(allElements)
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        /// <returns>data saved in the repository</returns>
        /// <exception cref="System.NullReferenceException">
        /// Thrown when data is null
        /// </exception>
        public IEnumerable<ICurrency> GetAllSavedData()
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
        public ICurrency GetSavedData(string id)
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
        private IEnumerable<ICurrency> GetAllElements()
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

        private IEnumerable<ICurrency> SaveData(IEnumerable<ICurrency> data) => _savedData = data;
    }
}
