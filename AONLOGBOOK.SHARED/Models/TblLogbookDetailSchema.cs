using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLogbookDetailSchema
    {
        public Guid Id { get; set; }

        public string? LogbookId { get; set; }

        public string ?Element { get; set; }

        public string ?DataType { get; set; }

        public string? UOM { get; set; }

        public int? Show { get; set; }
        public string? LookupId { get; set; }
        public string ?Source { get; set; }

        public float? L_Max { get; set; }

        public float? L_Min { get; set; }

        public int? prscn { get; set; }

        public DateTime? CretedOn { get; set; }

        public string ?CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public int? Del_Flag { get; set; }

        public string? RefCol { get; set; }

        public int? Seq { get; set; }

        public string ?Calulation_Params { get; set; }

        public string? Operator { get; set; }

        public string? Critical { get; set; }

        public string? Special { get; set; }

        public int? isDashboardComponent { get; set; }

        public int? isMandatory { get; set; }
    }
}
