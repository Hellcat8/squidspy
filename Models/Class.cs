using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassBuild = new HashSet<ClassBuild>();
            ClassDetail = new HashSet<ClassDetail>();
            Spell = new HashSet<Spell>();
        }

        public int IdClass { get; set; }
        public string Label { get; set; }

        public virtual ICollection<ClassBuild> ClassBuild { get; set; }
        public virtual ICollection<ClassDetail> ClassDetail { get; set; }
        public virtual ICollection<Spell> Spell { get; set; }
    }
}
