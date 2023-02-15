using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLogBookDataTableHeader
    {
        public Guid Id { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Shift { get; set; }
        public string? Company { get; set; }
        public string? DeptId { get; set; }
        public string? SubDeptId { get; set; }
        public string? PlantId { get; set; }
        public string? LogbookId { get; set; }
        public string? FYear { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public int? StatusF { get; set; }
    }
}
