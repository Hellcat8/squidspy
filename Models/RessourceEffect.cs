using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class RessourceEffect
    {
        public int IdRessourceEffect { get; set; }
        public string Effect { get; set; }
        public int Order { get; set; }
        public int IdRessource { get; set; }

        public virtual Ressource IdRessourceNavigation { get; set; }
    }
}
