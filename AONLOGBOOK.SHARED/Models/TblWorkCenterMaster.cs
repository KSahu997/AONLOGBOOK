using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblWorkCenterMaster
    {
        public Guid ID { get; set; }

        public string? WorkCenter_Name { get; set; }

        public string? Company_ID { get; set; }

        public string? Plant_ID { get; set; }

        public int? Del_Flag { get; set; }

        public string? Inserted_By { get; set; }

        public DateTime? Inserted_On { get; set; }

        public string? Updated_By { get; set; }

        public DateTime? Updated_on { get; set; }
    }
}
