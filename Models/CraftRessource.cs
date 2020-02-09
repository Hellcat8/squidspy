using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class CraftRessource
    {
        public int IdCraftRessource { get; set; }
        public int IdCraft { get; set; }
        public int IdRessource { get; set; }
        public int Quantity { get; set; }

        public virtual Craft IdCraftNavigation { get; set; }
        public virtual Ressource IdRessourceNavigation { get; set; }
    }
}
