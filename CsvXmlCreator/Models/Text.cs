using System.Collections.Generic;
using System.Xml.Serialization;

namespace CsvXmlCreator.Models
{
    [XmlRoot(ElementName = "text")]
    public class Text
    {
        [XmlElement(ElementName = "sentence")]
        public List<Sentence> Sentences { get; set; }
    }
}
