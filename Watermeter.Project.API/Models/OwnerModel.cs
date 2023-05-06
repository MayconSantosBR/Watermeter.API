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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Cellphone { get; set; }

        [Required, MinLength(8), MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
