using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLogBookDataTableHeader
    {
        public Guid id { get; set; }

        public DateTime? DateTime { get; set; }

        public string? Shift { get; set; }

        public string? Company { get; set; }

        public string? Dept_Id { get; set; }

        public string? Sub_deptId { get; set; }

        public string? Plant_Id { get; set; }

        public string? Logbook_Id { get; set; }

        public string? F_Year { get; set; }

        public DateTime? Created_On { get; set; }

        public string? Created_By { get; set; }

        public DateTime? Modified_On { get; set; }

        public string? Modified_By { get; set; }

        public int? Status_F { get; set; }
    }
}
