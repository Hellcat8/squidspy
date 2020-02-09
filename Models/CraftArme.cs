using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class CraftArme
    {
        public int IdCraftArme { get; set; }
        public int IdCraft { get; set; }
        public int IdArme { get; set; }
        public int Quantity { get; set; }

        public virtual Arme IdArmeNavigation { get; set; }
        public virtual Craft IdCraftNavigation { get; set; }
    }
}
