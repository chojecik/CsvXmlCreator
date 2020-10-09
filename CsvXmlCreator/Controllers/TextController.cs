using CsvXmlCreator.Enums;
using CsvXmlCreator.Helpers.Factories;
using CsvXmlCreator.Interfaces;
using CsvXmlCreator.Models;
using CsvXmlCreator.Services;
using Microsoft.AspNetCore.Mvc;

namespace CsvXmlCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly IService<XmlService> xmlService;
        private readonly IService<CsvService> csvService;

        public TextController(IService<XmlService> xmlService, IService<CsvService> csvService)
        {
            this.xmlService = xmlService;
            this.csvService = csvService;
        }
        [HttpPost("create")]
        public IActionResult Post([FromBody]FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var text = TextFactory.GenerateText(model.Input);
            string serializedObject = string.Empty;
            switch (model.Type)
            {
                case Type.Xml:
                    serializedObject = xmlService.SerializeObject(text);
                    break;
                case Type.Csv:
                    serializedObject = csvService.SerializeObject(text);
                    break;
            }

            return Ok(new
            {
                Response = serializedObject
            });
        }

        [HttpPost("download")]
        public IActionResult Download([FromBody]FormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            byte[] file;
            switch (model.Type)
            {
                case Type.Xml:
                    file = xmlService.GenerateFile(model.Input);
                    return File(file, "text/xml", "file.xml");
                case Type.Csv:
                    file = csvService.GenerateFile(model.Input);
                    return File(file, "text/csv", "file.csv");
            }
            return BadRequest();
        }
    }
}