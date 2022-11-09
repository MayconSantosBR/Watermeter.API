using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Models
{
    public class ArduinoNameUpdateModel
    {
        [MaxLength(50)]
        public int Name { get; set; }
    }
}
