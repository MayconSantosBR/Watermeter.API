using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Models.Arduino
{
    public class ArduinoCreateModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int IdOwner { get; set; }
    }
}
