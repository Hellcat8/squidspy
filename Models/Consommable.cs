using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class Consommable
    {
        public Consommable()
        {
            ConsommableEffect = new HashSet<ConsommableEffect>();
            CraftConsommable = new HashSet<CraftConsommable>();
        }

        public int IdConsommable { get; set; }
        public string Label { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int? IdCraft { get; set; }
        public int? IdImage { get; set; }
        public int IdTypeConsommable { get; set; }

        public virtual Craft IdCraftNavigation { get; set; }
        public virtual Image IdImageNavigation { get; set; }
        public virtual TypeConsommable IdTypeConsommableNavigation { get; set; }
        public virtual ICollection<ConsommableEffect> ConsommableEffect { get; set; }
        public virtual ICollection<CraftConsommable> CraftConsommable { get; set; }
    }
}
