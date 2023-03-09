using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.SHARED.CModels
{
    public partial class TblLogbookDetailSchemaMOD
    {
        public Guid Id { get; set; }
        public string? Tag_Name { get; set; }
        public string? Display_Name { get; set; }
        public string? Source { get; set; }
        public double? L_Min { get; set; }
        public double? L_Max { get; set; }
        public string? DataType { get; set; }
        // public string? Id { get; set; }
        public string? LookupId { get; set; }

        public int Seq { get; set; }
        public string? Element { get; set; }
        public int isMandatory { get; set; }
        public int isOther { get; set; }
        public string? LogbookId { get; set; }

        // public string? Unit { get; set; }
        public string? UOM { get; set; }
        public int? Show { get; set; }
        public int? Prscn { get; set; }

        public string? RefCol { get; set; }

        public string? Operator { get; set; }

        public string? Critical { get; set; }

        public string? Special { get; set; }

        public int? isDashboardComponent { get; set; }
        public string? CalulationParams { get; set; }
        public string? LogbookName { get; set; }

        public DateTime? CretedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public int? Del_Flag { get; set; }
        public string? Text_Schema { get; set; }

        public string? Value_Schema { get; set; }
    }
}
