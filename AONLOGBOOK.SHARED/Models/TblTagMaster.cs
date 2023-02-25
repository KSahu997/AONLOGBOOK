using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblTagMaster
    {
        public Guid ID { get; set; }

        public string? Tag_Name { get; set; }

        public string? Display_Name { get; set; }

        public long? UOM { get; set; }

        public string? Description { get; set; }

        public int? Is_Deleted { get; set; }

        public string? Updated_By { get; set; }

        public DateTime? Updated_On { get; set; }

        public DateTime? Created_On { get; set; }

        public string? Created_By { get; set; }
    }
}
