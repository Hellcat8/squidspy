using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class ClassBuild
    {
        public ClassBuild()
        {
            ClassBuildDetail = new HashSet<ClassBuildDetail>();
        }

        public int IdClassBuild { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public int Order { get; set; }
        public int IdClass { get; set; }

        public virtual Class IdClassNavigation { get; set; }
        public virtual ICollection<ClassBuildDetail> ClassBuildDetail { get; set; }
    }
}
