using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class TypeConsommable
    {
        public TypeConsommable()
        {
            Consommable = new HashSet<Consommable>();
        }

        public int IdTypeConsommable { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Consommable> Consommable { get; set; }
    }
}
