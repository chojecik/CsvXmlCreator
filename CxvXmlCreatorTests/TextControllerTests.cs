using CsvXmlCreator.Controllers;
using CsvXmlCreator.Interfaces;
using CsvXmlCreator.Models;
using CsvXmlCreator.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CxvXmlCreatorTests
{
    public class TextControllerTests
    {
        private readonly TextController textController;
        private readonly Mock<IService<XmlService>> _xmlServiceMock = new Mock<IService<XmlService>>();
        private readonly Mock<IService<CsvService>> _csvServiceMock = new Mock<IService<CsvService>>();

        private readonly FormModel validModel = new FormModel
        {
            Input = "Mary had a little lamb",
            Type = CsvXmlCreator.Enums.Type.Xml
        };

        private readonly FormModel invalidModel = new FormModel
        {
            Input = null,
            Type = CsvXmlCreator.Enums.Type.Xml
        };

        private readonly Text text = new Text
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

        private readonly string serializedObject = @"
            <?xml version=""1.0"" encoding=""utf - 8""?>
            < text xmlns: xsi = ""http://www.w3.org/2001/XMLSchema-instance"" xmlns: xsd = ""http://www.w3.org/2001/XMLSchema"" >
                < sentence >
                    < word > a </ word >
                    < word > had </ word >
                    < word > lamb </ word >
                    < word > little </ word >
                    < word > Mary </ word >
                </ sentence >
            </ text > ";

        public TextControllerTests()
        {
            textController = new TextController(_xmlServiceMock.Object, _csvServiceMock.Object);
        }

        [Fact]
        public void Post_ShouldReturnOk_WhenModelIsValid()
        {
            //Arrange
            _xmlServiceMock.Setup(x => x.SerializeObject(text)).Returns(serializedObject);

            //Act
            var response = textController.Post(validModel);

            //Assert
            Assert.Equal(typeof(OkObjectResult), response.GetType());
        }

        [Fact]
        public void Post_ShouldReturnBadRequest_WhenModelIsNotValid()
        {
            //Arrange
            _xmlServiceMock.Setup(x => x.SerializeObject(text)).Returns(serializedObject);

            //Act
            var response = textController.Post(invalidModel);

            //Assert
            Assert.Equal(typeof(BadRequestObjectResult), response.GetType());
        }

        [Fact]
        public void Download_ShouldReturnOk_WhenModelIsValid()
        {
            //Arrange
            _xmlServiceMock.Setup(x => x.GenerateFile(serializedObject)).Returns(new byte[255]);

            //Act
            var response = textController.Download(validModel);

            //Assert
            Assert.Equal(typeof(FileContentResult), response.GetType());
        }

        [Fact]
        public void Download_ShouldReturnBadRequest_WhenModelIsInvalid()
        {
            //Arrange
            _xmlServiceMock.Setup(x => x.GenerateFile(serializedObject)).Returns(new byte[255]);

            //Act
            var response = textController.Download(invalidModel);

            //Assert
            Assert.Equal(typeof(BadRequestObjectResult), response.GetType());
        }
    }
}
