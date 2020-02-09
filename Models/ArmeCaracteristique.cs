using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class ArmeCaracteristique
    {
        public int IdArmeCaracteristique { get; set; }
        public int Pa { get; set; }
        public int Portee { get; set; }
        public string CriticalHitProbability { get; set; }
        public string FailureProbability { get; set; }
        public int IdArme { get; set; }

        public virtual Arme IdArmeNavigation { get; set; }
    }
}
