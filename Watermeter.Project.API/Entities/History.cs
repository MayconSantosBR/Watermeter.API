using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Entities
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public string Begin { get; set; }
        public string End { get; set; }
        public DateOnly Date { get; set; }
        public double Waterflow { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int ArduinoId { get; set; }
        public Arduino Arduino { get; set; }
    }
}
