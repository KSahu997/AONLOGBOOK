using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblTagMaster
    {
        public Guid Id { get; set; }
        public string? TagName { get; set; }
        public string? DisplayName { get; set; }
        public long? Uom { get; set; }
        public string? Description { get; set; }
        public int? IsDeleted { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedOn { get; set; }
    }
}
