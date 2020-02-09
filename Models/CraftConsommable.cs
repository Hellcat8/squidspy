using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class CraftConsommable
    {
        public int IdCraftConsommable { get; set; }
        public int IdCraft { get; set; }
        public int IdConsommable { get; set; }
        public int Quantity { get; set; }

        public virtual Consommable IdConsommableNavigation { get; set; }
        public virtual Craft IdCraftNavigation { get; set; }
    }
}
