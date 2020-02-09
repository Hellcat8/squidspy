using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class TypeEquipement
    {
        public TypeEquipement()
        {
            Equipement = new HashSet<Equipement>();
        }

        public int IdTypeEquipement { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Equipement> Equipement { get; set; }
    }
}
