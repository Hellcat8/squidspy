using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class ArmeCondition
    {
        public int IdArmeCondition { get; set; }
        public string Condition { get; set; }
        public int Order { get; set; }
        public int IdArme { get; set; }

        public virtual Arme IdArmeNavigation { get; set; }
    }
}
