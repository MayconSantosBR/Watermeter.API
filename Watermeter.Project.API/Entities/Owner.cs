using System;
using System.Collections.Generic;

namespace Watermeter.Project.API.Entities
{
    public partial class Owner
    {
        public Owner()
        {
            Achieviments = new HashSet<Achieviment>();
            Arduinos = new HashSet<Arduino>();
            Histories = new HashSet<History>();
        }

        public int IdOwner { get; set; }
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Cellphone { get; set; }
        public string Email { get; set; } = null!;
        public DateOnly? Birthdate { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<Achieviment> Achieviments { get; set; }
        public virtual ICollection<Arduino> Arduinos { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
