using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Models.Arduino
{
    public class ArduinoNameUpdateModel
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
