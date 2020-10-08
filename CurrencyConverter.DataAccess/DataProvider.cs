using System.IO;
using System.Net;
using System.Text;

namespace CurrencyConverter.DataAccess
{
    class DataProvider
    {
        public string GetData()
        {
            var xmlResponse = GetXmlResponse("https://www.nbp.pl/kursy/xml/lasta.xml");
            return xmlResponse;
        }

        private string GetXmlResponse(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            var response = request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            var result = readStream.ReadToEnd();

            return result;
        }
    }
}
