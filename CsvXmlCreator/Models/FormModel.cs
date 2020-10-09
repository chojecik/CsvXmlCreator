using CsvXmlCreator.Enums;
using System.ComponentModel.DataAnnotations;

namespace CsvXmlCreator.Models
{
    public class FormModel
    {
        [Required]
        public string Input { get; set; }
        [Required]
        public Type Type { get; set; }
    }
}
