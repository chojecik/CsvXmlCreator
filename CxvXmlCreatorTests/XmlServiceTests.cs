using CsvXmlCreator.Interfaces;
using CsvXmlCreator.Models;
using CsvXmlCreator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CxvXmlCreatorTests
{
    public class XmlServiceTests
    {
        private readonly IService<XmlService> service = new XmlService();

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
            var expectedOutput = @"<?xml version=""1.0"" encoding=""utf-8""?>
<text xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <sentence>
    <word>a</word>
    <word>had</word>
    <word>lamb</word>
    <word>little</word>
    <word>Mary</word>
  </sentence>
</text>";

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
            var serializedText = @"<?xml version=""1.0"" encoding=""utf-8""?>
<text xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <sentence>
    <word>a</word>
    <word>had</word>
    <word>lamb</word>
    <word>little</word>
    <word>Mary</word>
  </sentence>
</text>";
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
