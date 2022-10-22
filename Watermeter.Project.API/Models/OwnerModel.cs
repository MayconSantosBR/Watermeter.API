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

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required, MaxLength(2)]
        public string State { get; set; }

        [Required, MaxLength(100)]
        public string Neighborhood { get; set; }

        [Required, MaxLength(50)]
        public string Number { get; set; }

        [Required, MaxLength(9)]
        public string PostalCode { get; set; }

        [Required, MaxLength(100)]
        public string Street { get; set; }
    }
}
