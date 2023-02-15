using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblFormGroupMaster
    {
        public Guid FormGroupId { get; set; }
        public string? Plant { get; set; }
        public string? Dept { get; set; }
        public string? SubDept { get; set; }
        public string? FormGroup { get; set; }
        public string? Role { get; set; }
        public int? DelFlag { get; set; }
    }
}
