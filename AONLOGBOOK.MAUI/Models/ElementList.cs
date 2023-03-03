using AONLOGBOOK.SHARED.CModels;
using AONLOGBOOK.SHARED.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.MAUI.Models
{
    public class ElementList
    {
        public string? Label { get; set; }
        public string? ElementType { get; set; }
        public string? HeaderId {get; set; }
        public DateTime? DateValue { get; set; }
        public DateTime? DateOnlyValue { get; set; }
        public TimeSpan? TimeValue { get; set; }
       // [Required(ErrorMessage ="Required")]
        public string? StringValue { get; set; }
       // [Required(ErrorMessage ="Required")]
        public int? IntegerValue { get; set; }
        //[Required(ErrorMessage ="Required")]
        public float? FloatValue { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        public bool? BoolValue { get; set; }
        public Dictionary<string, string> options { get; set; }
        public List<LookupData> lookuplist { get; set; } = new List<LookupData>();
        public string? LookupId { get; set; }
        public int? Sequence { get; set; }
        public int? IsMandatory { get; set; }
        public string? Shift_prefix { get; set; }
    }
}
