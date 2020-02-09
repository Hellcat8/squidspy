using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class TypeCaracteristique
    {
        public TypeCaracteristique()
        {
            ArmeEffect = new HashSet<ArmeEffect>();
            EquipementEffect = new HashSet<EquipementEffect>();
        }

        public int IdTypeCaracteristique { get; set; }
        public string Label { get; set; }

        public virtual ICollection<ArmeEffect> ArmeEffect { get; set; }
        public virtual ICollection<EquipementEffect> EquipementEffect { get; set; }
    }
}
