using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblDocGenerateMaster
    {
        public int Id { get; set; }
        public string? DocName { get; set; }
        public string? Abbrevation { get; set; }
        public int? RunNo { get; set; }
        public int? Status { get; set; }
    }
}
