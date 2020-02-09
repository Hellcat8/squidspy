using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class ClassDetail
    {
        public int IdClassDetail { get; set; }
        public string Keyword { get; set; }
        public string Detail { get; set; }
        public int IdClass { get; set; }

        public virtual Class IdClassNavigation { get; set; }
    }
}
