using CsvXmlCreator.Helpers.Factories;
using CsvXmlCreator.Models;
using Xunit;

namespace CxvXmlCreatorTests
{
    public class TextFactoryTests
    {
        [Fact]
        public void GenerateText_ShouldReturnTextObject_WhenInputIsNotNull()
        {
            //Arrange
            var input = "Mary had a little lamb.";

            //Act
            var resultTypeName = TextFactory.GenerateText(input).GetType().Name;

            //Assert
            Assert.Equal(typeof(Text).Name, resultTypeName);
        }

        [Fact]
        public void GenerateText_ShouldReturnNull_WhenInputIsNull()
        {
            //Act
            var result = TextFactory.GenerateText(null);

            //Assert
            Assert.Null(result);
        }
    }
}
