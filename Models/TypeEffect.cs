using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class TypeEffect
    {
        public TypeEffect()
        {
            ArmeEffect = new HashSet<ArmeEffect>();
            EquipementEffect = new HashSet<EquipementEffect>();
        }

        public int IdTypeEffect { get; set; }
        public string Label { get; set; }

        public virtual ICollection<ArmeEffect> ArmeEffect { get; set; }
        public virtual ICollection<EquipementEffect> EquipementEffect { get; set; }
    }
}
