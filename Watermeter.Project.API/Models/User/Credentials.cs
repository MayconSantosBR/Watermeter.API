using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Models.User
{
    public class Credentials
    {
        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(20)]
        public string Password { get; set; }
    }
}
