using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace CurrencyConverter.DataAccess
{
    class DataProvider
    {
        public XElement Data { get; private set; }

        public DataProvider()
        {
            LoadNewData();
        }

        public void LoadNewData()
        {
            var xmlResponse = GetXmlResponse("https://www.nbp.pl/kursy/xml/lasta.xml");
            Data = GetXElementFromString(xmlResponse);
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

        private XElement GetXElementFromString(string xmlResponse) => XElement.Parse(xmlResponse);
    }
}
