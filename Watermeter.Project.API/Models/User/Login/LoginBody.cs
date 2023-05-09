using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Models.User.Login
{
    public class LoginBody
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
