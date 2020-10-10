using CsvXmlCreator.Helpers.Extensions;
using Xunit;

namespace CxvXmlCreatorTests
{
    public class ExtensionsTests
    {
        [Fact]
        public void RemovePunctuation_ShouldRemovePunctuationsExceptApostrophe()
        {
            //Arrange
            var input = "Mary had a little lamb. Peter called for the wolf, and Aesop came.Cinderella likes shoes.I don't like tomatoes - said Thomas.";
            var apostrophe = '\'';

            //Act
            var result = input.RemovePunctuation();

            //Assert
            Assert.Contains(result, x => char.IsPunctuation(x) || x == apostrophe);
        }
    }
}
