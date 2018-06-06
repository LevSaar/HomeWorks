using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherAppHW
{
    [XmlRoot(ElementName = "condition")]
    public class Condition
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }

        [XmlElement(ElementName = "icon")]
        public string Icon { get; set; }
    }
}
