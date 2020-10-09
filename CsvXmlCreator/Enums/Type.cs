using System.Text.Json.Serialization;

namespace CsvXmlCreator.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Type
    {
        Xml = 1,
        Csv = 2
    }
}
