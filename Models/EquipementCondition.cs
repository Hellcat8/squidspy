using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class EquipementCondition
    {
        public int IdEquipementCondition { get; set; }
        public string Condition { get; set; }
        public int Order { get; set; }
        public int IdEquipement { get; set; }

        public virtual Equipement IdEquipementNavigation { get; set; }
    }
}
