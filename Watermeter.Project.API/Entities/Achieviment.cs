using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Entities
{
    public class Achieviment
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public bool IsAchieved { get; set; }
        public DateOnly DataAchieved { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
