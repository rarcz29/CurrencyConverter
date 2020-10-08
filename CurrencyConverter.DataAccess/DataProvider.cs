using System.IO;
using System.Net;
using System.Text;

namespace CurrencyConverter.DataAccess
{
    class DataProvider
    {
        public StringReader GetData()
        {
            var xmlResponse = GetXmlResponse("https://www.nbp.pl/kursy/xml/lasta.xml");
            var stringReaderElement = GetDataAsStringReader(xmlResponse);

            return stringReaderElement;
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

        private StringReader GetDataAsStringReader(string xmlString) => new StringReader(xmlString);
    }
}
