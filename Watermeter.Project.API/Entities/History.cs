using System;
using System.Collections.Generic;

namespace Watermeter.Project.API
{
    public partial class History
    {
        public int IdHistory { get; set; }
        public int IdArduino { get; set; }
        public int IdOwner { get; set; }
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }
        public DateTime Date { get; set; }
        public decimal? Waterflow { get; set; }

        public virtual Arduino IdArduinoNavigation { get; set; } = null!;
        public virtual Owner IdOwnerNavigation { get; set; } = null!;
    }
}
