using CsvXmlCreator.Helpers;
using CsvXmlCreator.Interfaces;
using CsvXmlCreator.Models;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CsvXmlCreator.Services
{
    public class XmlService : IService<XmlService>
    {
        public byte[] GenerateFile(string serializedText)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(serializedText);

            return Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
        }

        public string SerializeObject(Text text)
        {
            if (text == null)
            {
                return string.Empty;
            }

            var xmlSerializer = new XmlSerializer(typeof(Text));

            using (var stringWriter = new Utf8StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, text);
                return stringWriter.ToString();
            }
        }
    }
}
