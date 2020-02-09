using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class TypeArme
    {
        public TypeArme()
        {
            Arme = new HashSet<Arme>();
        }

        public int IdTypeArme { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Arme> Arme { get; set; }
    }
}
