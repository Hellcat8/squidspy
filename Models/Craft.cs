using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class Craft
    {
        public Craft()
        {
            Arme = new HashSet<Arme>();
            Consommable = new HashSet<Consommable>();
            CraftArme = new HashSet<CraftArme>();
            CraftConsommable = new HashSet<CraftConsommable>();
            CraftEquipement = new HashSet<CraftEquipement>();
            CraftRessource = new HashSet<CraftRessource>();
            Equipement = new HashSet<Equipement>();
            Ressource = new HashSet<Ressource>();
        }

        public int IdCraft { get; set; }

        public virtual ICollection<Arme> Arme { get; set; }
        public virtual ICollection<Consommable> Consommable { get; set; }
        public virtual ICollection<CraftArme> CraftArme { get; set; }
        public virtual ICollection<CraftConsommable> CraftConsommable { get; set; }
        public virtual ICollection<CraftEquipement> CraftEquipement { get; set; }
        public virtual ICollection<CraftRessource> CraftRessource { get; set; }
        public virtual ICollection<Equipement> Equipement { get; set; }
        public virtual ICollection<Ressource> Ressource { get; set; }
    }
}
