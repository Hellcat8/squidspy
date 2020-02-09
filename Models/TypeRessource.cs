using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class TypeRessource
    {
        public TypeRessource()
        {
            Ressource = new HashSet<Ressource>();
        }

        public int IdTypeRessource { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Ressource> Ressource { get; set; }
    }
}
