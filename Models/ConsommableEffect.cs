using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class ConsommableEffect
    {
        public int IdConsommableEffect { get; set; }
        public string Effect { get; set; }
        public int Order { get; set; }
        public int IdConsommable { get; set; }

        public virtual Consommable IdConsommableNavigation { get; set; }
    }
}
