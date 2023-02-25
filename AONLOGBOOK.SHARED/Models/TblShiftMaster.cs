using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblShiftMaster
    {
        public Guid Id { get; set; }

        public string? CompanyId { get; set; }

        public TimeSpan? Shift_start { get; set; }

        public string? Shift_prefix { get; set; }

        public int? Shifthour { get; set; }

        public byte? Delflag { get; set; }

    }
}
