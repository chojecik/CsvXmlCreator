using CsvXmlCreator.Helpers.Extensions;
using CsvXmlCreator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CsvXmlCreator.Helpers.Factories
{
    public static class TextFactory
    {
        static readonly char[] seperators = new char[] { '.', '!', '?' };
        
        public static Text GenerateText(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            input = Regex.Replace(input, @"\s", " ");
            var sentences = input.Split(seperators).Where(x => !string.IsNullOrEmpty(x));

            var text = new Text
            {
                Sentences = new List<Sentence>()
            };

            foreach (var sentence in sentences)
            {
                var strippedSentence = sentence.RemovePunctuation();
                text.Sentences.Add(new Sentence
                {
                    Words = strippedSentence.Split(' ').Where(x => !string.IsNullOrEmpty(x)).OrderBy(x => x).ToList()
                });
            }
            return text;
        }
    }
}
