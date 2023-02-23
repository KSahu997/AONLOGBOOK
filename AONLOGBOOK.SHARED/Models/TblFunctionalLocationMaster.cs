using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblFunctionalLocationMaster
    {
        public Guid Id { get; set; }
        public string? FunctionalLocation { get; set; }
        public string? LocationCode { get; set; }
        public string? WorkCenterId { get; set; }
        public string? CompanyId { get; set; }
        public string? PlantId { get; set; }
        public int? DelFlag { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? InsertedBy { get; set; }
        public DateTime? InsertedOn { get; set; }
    }
}
