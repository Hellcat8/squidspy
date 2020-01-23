using System;
using System.Collections.Generic;

namespace squidspy.DofusItem
{
    public class DofusItem
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public List<String> Effects { get; set; }
        public bool HasError { get; set; } = false;
    }
}
