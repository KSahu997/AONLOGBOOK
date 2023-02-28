using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLookupParam
    {
        public Guid ID { get; set; }

        public string? Lookup_ID { get; set; }

        public string? Param { get; set; }

        public string? Company_ID { get; set; }

        public string? Plant_ID { get; set; }

        public string? Updated_By { get; set; }

        public DateTime? Updated_On { get; set; }

        public string? Created_By { get; set; }

        public DateTime? Created_On { get; set; }

        public int? Del_Flag { get; set; }
    }
}
