using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblFormMaster
    {
        public Guid FormId { get; set; }
        public string FormGroup { get; set; } = null!;
        public string FormName { get; set; } = null!;
        public int? SeqSm { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? Seq { get; set; }
    }
}
