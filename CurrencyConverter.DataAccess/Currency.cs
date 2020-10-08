using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace CurrencyConverter.DataAccess
{
    [XmlType("pozycja")]
    public class Currency
    {
        [XmlElement("kod_waluty")]
        public string Code { get; set; }

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
                return ExchangeRate.ToString(CultureInfo.CreateSpecificCulture("pl-PL"));
            }
            set
            {
                Decimal.TryParse(value, NumberStyles.Any, CultureInfo.CreateSpecificCulture("pl-PL"),
                    out decimal result);
                ExchangeRate = result;
            }
        }
    }
}
