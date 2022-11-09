using System;
using System.Collections.Generic;

namespace Watermeter.Project.API
{
    public partial class Achieviment
    {
        public int IdAchieviment { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int IsAchieved { get; set; }
        public int IdOwner { get; set; }

        public virtual Owner IdOwnerNavigation { get; set; } = null!;
    }
}
