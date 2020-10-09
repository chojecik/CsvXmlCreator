using System.Text;

namespace CsvXmlCreator.Helpers.Extensions
{
    public static class Extensions
    {
        public static readonly char acceptedPunctuation = '\'';
        public static string RemovePunctuation(this string input)
        {
            var sb = new StringBuilder();

            foreach (char c in input)
            {
                if (!char.IsPunctuation(c) || c == acceptedPunctuation)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
