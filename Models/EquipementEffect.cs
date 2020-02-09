using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class EquipementEffect
    {
        public int IdEquipementEffect { get; set; }
        public int IdTypeEffect { get; set; }
        public int? IdTypeCaracteristique { get; set; }
        public string Effect { get; set; }
        public int Order { get; set; }
        public int IdEquipement { get; set; }

        public virtual Equipement IdEquipementNavigation { get; set; }
        public virtual TypeCaracteristique IdTypeCaracteristiqueNavigation { get; set; }
        public virtual TypeEffect IdTypeEffectNavigation { get; set; }
    }
}
