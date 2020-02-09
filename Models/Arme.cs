using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class Arme
    {
        public Arme()
        {
            ArmeCaracteristique = new HashSet<ArmeCaracteristique>();
            ArmeCondition = new HashSet<ArmeCondition>();
            ArmeEffect = new HashSet<ArmeEffect>();
            CraftArme = new HashSet<CraftArme>();
        }

        public int IdArme { get; set; }
        public string Label { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int? IdCraft { get; set; }
        public int? IdImage { get; set; }
        public int IdTypeArme { get; set; }

        public virtual Craft IdCraftNavigation { get; set; }
        public virtual Image IdImageNavigation { get; set; }
        public virtual TypeArme IdTypeArmeNavigation { get; set; }
        public virtual ICollection<ArmeCaracteristique> ArmeCaracteristique { get; set; }
        public virtual ICollection<ArmeCondition> ArmeCondition { get; set; }
        public virtual ICollection<ArmeEffect> ArmeEffect { get; set; }
        public virtual ICollection<CraftArme> CraftArme { get; set; }
    }
}
