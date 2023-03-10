using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLookupParam
    {
        public Guid Id { get; set; }
        public string? LookupId { get; set; }
        public string? Param { get; set; }
        public string? CompanyId { get; set; }
        public string? PlantId { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? DelFlag { get; set; }
    }
}
