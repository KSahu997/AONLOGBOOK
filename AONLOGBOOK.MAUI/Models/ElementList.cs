using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.MAUI.Models
{
    public class ElementList
    {
        public string? Label { get; set; }
        public string? ElementType { get; set; }

        public DateTime? DateValue { get; set; }
        public string? StringValue { get; set; }
        public int? IntegerValue { get; set; }
        public float? FloatValue { get; set; }
        public bool? BoolValue { get; set; }
        public Dictionary<string, string> options { get; set; }
        public int? Sequence { get; set; }

    }
}
