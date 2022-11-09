using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Models
{
    public class OwnerModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(15)]
        public string Cellphone { get; set; }

        [Required, MinLength(8), MaxLength(20)]
        public string Password { get; set; }
    }
}
