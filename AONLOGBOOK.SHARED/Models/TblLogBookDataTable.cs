using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLogBookDataTable
    {
        public Guid Id { get; set; }

        public string? Header_Id { get; set; }

        public long sl { get; set; }

        public string? CompanyId { get; set; }

        public string? plantcode { get; set; }

        public string? DeptId { get; set; }

        public string? Uom { get; set; }

        public string? Sub_deptid { get; set; }

        public string? LogbookId { get; set; }

        public DateTime? LogDate { get; set; }

        public string? ParamName { get; set; }

        public string? Value { get; set; }

        public string? CretedBy { get; set; }

        public DateTime? CretedOn { get; set; }

        public string? ModifyBy { get; set; }

        public DateTime? ModifyOn { get; set; }

        public string? MarkforDeletion { get; set; }

        public string? Shift { get; set; }

        public int? SapFlag { get; set; }

        public string? Mode { get; set; }

    }
}
