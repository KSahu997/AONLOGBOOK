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

        //public string? LogbookId { get; set; }

        public string? Element { get; set; }

        public string? DataType { get; set; }
        public string? DisplayName { get; set; }

       // public string? Unit { get; set; }
        public string? Uom { get; set; }

        public string? Source { get; set; }

        public double? LMax { get; set; }

        public double? LMin { get; set; }

        public int? Prscn { get; set; }

       
        public string? RefCol { get; set; }
        public int? Seq { get; set; }

        public string? CalulationParams { get; set; }

        public string? Operator { get; set; }




    }
}
