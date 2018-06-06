using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherAppHW
{
    [XmlRoot(ElementName = "forecastday")]
    public class ForecastDay
    {
        [XmlElement(ElementName = "date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "day")]
        public Day Day { get; set; }
    }
}
