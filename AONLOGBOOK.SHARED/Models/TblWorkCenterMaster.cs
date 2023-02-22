using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblWorkCenterMaster
    {
        public Guid Id { get; set; }
        public string? WorkCenterName { get; set; }
        public string? CompanyId { get; set; }
        public string? PlantId { get; set; }
        public int? DelFlag { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
