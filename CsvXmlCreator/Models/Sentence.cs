using System.Collections.Generic;
using System.Xml.Serialization;

namespace CsvXmlCreator.Models
{
    [XmlRoot(ElementName = "sentence")]
    public class Sentence
    {
        [XmlElement(ElementName = "word")]
        public List<string> Words { get; set; }
    }
}
