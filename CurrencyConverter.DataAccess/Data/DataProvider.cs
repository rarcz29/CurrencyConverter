using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace CurrencyConverter.DataAccess.Data
{
    public class DataProvider : IDataProvider
    {
        public string GetData()
        {

            var url = ConfigurationManager.AppSettings["NBPApiUrl"];
            var xmlResponse = GetXmlResponse(url);

            return xmlResponse;
        }

        private string GetXmlResponse(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            var response = request.GetResponse();

            var receiveStream = response.GetResponseStream();
            var readStream = new StreamReader(receiveStream, Encoding.UTF8);

            var result = readStream.ReadToEnd();

            return result;
        }
    }
}
