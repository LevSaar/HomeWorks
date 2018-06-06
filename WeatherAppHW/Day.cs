using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherAppHW
{
    [XmlRoot(ElementName = "day")]
    public class Day
    {
        [XmlElement(ElementName = "maxtemp_c")]
        public string Maxtemp { get; set; }

        [XmlElement(ElementName = "mintemp_c")]
        public string Mintemp { get; set; }
        
        [XmlElement(ElementName = "maxwind_mph")]
        public string Maxwind { get; set; }

        [XmlElement(ElementName = "avghumidity")]
        public string Humidity { get; set; }

        [XmlElement(ElementName = "condition")]
        public Condition Condition { get; set; }
    }
}
