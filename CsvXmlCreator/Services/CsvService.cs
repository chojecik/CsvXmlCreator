using CsvXmlCreator.Interfaces;
using CsvXmlCreator.Models;
using System.Text;
using System;
using System.Linq;
using System.IO;

namespace CsvXmlCreator.Services
{
    public class CsvService : IService<CsvService>
    {
        public byte[] GenerateFile(string serializedText)
        {
            return Encoding.Default.GetBytes(serializedText);
        }

        public string SerializeObject(Text text)
        {
            var sb = new StringBuilder();

            var maxWordsCount = text.Sentences.Max(s => s.Words.Count);
            var columnHeaders = Enumerable.Range(1, maxWordsCount).Select(i => $"Word {i} ");
            sb.AppendLine(string.Join(",", columnHeaders));

            var sentenceCounter = 1;
            foreach (var sentence in text.Sentences)
            {
                sb.Append($"Sentence {sentenceCounter}, ");
                sb.AppendLine(string.Join(", ", sentence.Words));
                sentenceCounter++;
            }

            return sb.ToString();
        }
    }
}
