using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.SHARED.CModels
{
    public class LogDataReport
    {
        public string? ParamName { get; set; }
        public string? Value { get; set; }
        public long Sl { get; set; }
        public string? ShiftPrefix { get; set; }
        public string? Unit { get; set; }
        //public string? LogbookId { get; set; }
        //public string? Shift { get; set; }
    }
}
