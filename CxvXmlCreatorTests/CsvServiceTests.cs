using CsvXmlCreator.Interfaces;
using CsvXmlCreator.Models;
using CsvXmlCreator.Services;
using System.Collections.Generic;
using Xunit;

namespace CxvXmlCreatorTests
{
    public class CsvServiceTests
    {
        private readonly IService<CsvService> service = new CsvService();

        [Fact]
        public void SerializeObject_ShouldReturnString_WhenTextIsValid()
        {
            //Arrange
            var text = new Text
            {
                Sentences = new List<Sentence>
                {
                    new Sentence
                    {
                        Words = new List<string>
                        {
                            "a", "had", "lamb", "little", "Mary"
                        }
                    }
                }
            };
            var expectedOutput = "Word 1 ,Word 2 ,Word 3 ,Word 4 ,Word 5 \r\nSentence 1, a, had, lamb, little, Mary\r\n";

            //Act
            var returnedObject = service.SerializeObject(text);

            //Assert
            Assert.Equal(expectedOutput, returnedObject);
        }

        [Fact]
        public void SerializeObject_ShouldReturnNull_WhenTextIsNull()
        {
            //Assert
            Assert.Null(service.SerializeObject(null));
        }

        [Fact]
        public void GenerateFile_ShouldReturnBytes_WhenInputIsNotNull()
        {
            //Arrange
            var serializedText = "Word 1 ,Word 2 ,Word 3 ,Word 4 ,Word 5 \r\nSentence 1, a, had, lamb, little, Mary\r\n";
            var expectedTypeName = typeof(byte[]);
            //Act
            var result = service.GenerateFile(serializedText);

            //Assert
            Assert.Equal(expectedTypeName.Name, result.GetType().Name);
        }

        [Fact]
        public void GenerateFile_ShouldReturnNull_WhenTextIsNull()
        {
            //Assert
            Assert.Null(service.GenerateFile(null));
        }
    }
}
