using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace CurrencyConverter.DataAccess
{
    public class DataProvider : IDataProvider
    {
        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        public string GetData()
        {

            var url = ConfigurationManager.AppSettings["NBPApiUrl"];

            string xmlResponse;

            try
            {
                xmlResponse = GetXmlResponse(url);
            }
            catch
            {
                throw;
            }
            

            return xmlResponse;
        }

        /// <exception cref="System.Web.WebException">
        /// Thrown when there is no internet connection
        /// </exception>
        /// <exception cref="System.NotSupportedException">
        /// Thrown when the GetResponseStream method is not supported
        /// </exception>
        private string GetXmlResponse(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            WebResponse response;
            Stream receiveStream;

            try
            {
                response = request.GetResponse();
                receiveStream = response.GetResponseStream();
            }
            catch (WebException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            
            var readStream = new StreamReader(receiveStream, Encoding.UTF8);
            var result = readStream.ReadToEnd();

            return result;
        }
    }
}
