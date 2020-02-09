using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class ClassBuildDetail
    {
        public int IdClassBuildDetail { get; set; }
        public string Detail { get; set; }
        public bool ExtraLineAtEnd { get; set; }
        public int Order { get; set; }
        public int IdClassBuild { get; set; }

        public virtual ClassBuild IdClassBuildNavigation { get; set; }
    }
}
