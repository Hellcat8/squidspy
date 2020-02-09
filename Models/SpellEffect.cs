using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class SpellEffect
    {
        public int IdSpellEffect { get; set; }
        public string Type { get; set; }
        public string Effect { get; set; }
        public string Element { get; set; }
        public int Order { get; set; }
        public int IdSpellDetail { get; set; }

        public virtual SpellDetail IdSpellDetailNavigation { get; set; }
    }
}
