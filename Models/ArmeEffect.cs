using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class ArmeEffect
    {
        public int IdArmeEffect { get; set; }
        public int IdTypeEffect { get; set; }
        public int? IdTypeCaracteristique { get; set; }
        public string Effect { get; set; }
        public int Order { get; set; }
        public int IdArme { get; set; }

        public virtual Arme IdArmeNavigation { get; set; }
        public virtual TypeCaracteristique IdTypeCaracteristiqueNavigation { get; set; }
        public virtual TypeEffect IdTypeEffectNavigation { get; set; }
    }
}
