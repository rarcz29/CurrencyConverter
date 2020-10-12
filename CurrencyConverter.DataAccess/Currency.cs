using CurrencyConverter.Interfaces;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Xml.Serialization;

namespace CurrencyConverter.DataAccess
{
    [XmlType("pozycja")]
    public class Currency : ICurrency
    {
        [XmlElement("kod_waluty")]
        public string Id { get; set; }

        [XmlElement("nazwa_waluty")]
        public string Name { get; set; }

        [XmlElement("przelicznik")]
        public int ConversionFactor { get; set; }

        [XmlIgnore]
        public decimal ExchangeRate { get; set; }

        [XmlElement("kurs_sredni")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string ExchangeRateSerialized
        {
            get
            {
                var cultureInfoName = ConfigurationManager.AppSettings["CultureInfoName"];
                return ExchangeRate.ToString(CultureInfo.CreateSpecificCulture(cultureInfoName));
            }
            set
            {
                var cultureInfoName = ConfigurationManager.AppSettings["CultureInfoName"];
                Decimal.TryParse(
                    value,
                    NumberStyles.Any,
                    CultureInfo.CreateSpecificCulture(cultureInfoName),
                    out decimal result);
                ExchangeRate = result;
            }
        }
    }
}
