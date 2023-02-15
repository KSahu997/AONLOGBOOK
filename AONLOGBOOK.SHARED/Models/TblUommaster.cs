using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblUommaster
    {
        public Guid Id { get; set; }
        public string? Unit { get; set; }
        public byte? DelFlag { get; set; }
    }
}
