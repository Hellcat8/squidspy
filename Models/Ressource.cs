using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace squidspy.Models
{
    public partial class Ressource
    {
        public Ressource()
        {
            CraftRessource = new HashSet<CraftRessource>();
            RessourceEffect = new HashSet<RessourceEffect>();
        }

        public int IdRessource { get; set; }
        public string Label { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int? IdImage { get; set; }
        public int? IdCraft { get; set; }
        public int IdTypeRessource { get; set; }

        [NotMapped]
        public string TypeRessourceName { get; set; }

        public virtual Craft IdCraftNavigation { get; set; }
        public virtual Image IdImageNavigation { get; set; }
        public virtual TypeRessource IdTypeRessourceNavigation { get; set; }
        public virtual ICollection<CraftRessource> CraftRessource { get; set; }
        public virtual ICollection<RessourceEffect> RessourceEffect { get; set; }
    }
}
