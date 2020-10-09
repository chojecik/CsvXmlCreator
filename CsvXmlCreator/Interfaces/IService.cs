using CsvXmlCreator.Models;

namespace CsvXmlCreator.Interfaces
{
    public interface IService<T> where T : class
    {
        string SerializeObject(Text text);
        byte[] GenerateFile(string serializedText);
    }
}
