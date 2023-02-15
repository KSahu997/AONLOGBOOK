using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLogbookDetailSchema
    {
        public Guid Id { get; set; }
        public string? LogbookId { get; set; }
        public string? HeaderId { get; set; }
        public int? Element { get; set; }
        public string? DataType { get; set; }
        public string? Uom { get; set; }
        public int? Show { get; set; }
        public string? Source { get; set; }
        public double? LMax { get; set; }
        public double? LMin { get; set; }
        public int? Prscn { get; set; }
        public DateTime? CretedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public int? DelFlag { get; set; }
        public string? RefCol { get; set; }
        public int Seq { get; set; }
        public string? CalulationParams { get; set; }
        public string? Operator { get; set; }
        public string? Critical { get; set; }
        public string? Special { get; set; }
        public int? IsDashboardComponent { get; set; }
        public int? IsMandatory { get; set; }
    }
}
