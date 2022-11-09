using System;
using System.Collections.Generic;

namespace Watermeter.Project.API
{
    public partial class Arduino
    {
        public Arduino()
        {
            Histories = new HashSet<History>();
        }

        public int IdArduino { get; set; }
        public int IdOwner { get; set; }
        public string Name { get; set; } = null!;
        public DateTime ApplyDate { get; set; } = DateTime.Now.Date.ToUniversalTime();
        public DateTime? LastRead { get; set; }

        public virtual Owner IdOwnerNavigation { get; set; } = null!;
        public virtual ICollection<History> Histories { get; set; }
    }
}
