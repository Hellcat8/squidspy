using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class Image
    {
        public Image()
        {
            Arme = new HashSet<Arme>();
            Consommable = new HashSet<Consommable>();
            Equipement = new HashSet<Equipement>();
            Ressource = new HashSet<Ressource>();
            Spell = new HashSet<Spell>();
        }

        public int IdImage { get; set; }
        public string ImgFilename { get; set; }

        public virtual ICollection<Arme> Arme { get; set; }
        public virtual ICollection<Consommable> Consommable { get; set; }
        public virtual ICollection<Equipement> Equipement { get; set; }
        public virtual ICollection<Ressource> Ressource { get; set; }
        public virtual ICollection<Spell> Spell { get; set; }
    }
}
