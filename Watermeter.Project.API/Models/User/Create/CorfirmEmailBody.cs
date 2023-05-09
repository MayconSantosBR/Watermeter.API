using System.ComponentModel.DataAnnotations;

namespace Watermeter.Project.API.Models.User.Create
{
    public class ConfirmEmailBody
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string ActivationCode { get; set; }
    }
}
