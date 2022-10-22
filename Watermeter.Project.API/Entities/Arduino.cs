using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Entities
{
    public class Arduino
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public int Name { get; set; }

        [Required]
        public DateTime InstallDate { get; set; }
        public DateTime LastMeasure { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public List<History> Histories { get; set; }
    }
}
