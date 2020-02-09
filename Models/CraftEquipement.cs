using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class CraftEquipement
    {
        public int IdCraftEquipement { get; set; }
        public int IdCraft { get; set; }
        public int IdEquipement { get; set; }
        public int Quantity { get; set; }

        public virtual Craft IdCraftNavigation { get; set; }
        public virtual Equipement IdEquipementNavigation { get; set; }
    }
}
