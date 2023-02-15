using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLogbookMaster
    {
        public Guid LogbookId { get; set; }
        public string Department { get; set; } = null!;
        public string SubDepartment { get; set; } = null!;
        public string? LogbookName { get; set; }
        public string? LogbookCode { get; set; }
        public string? StatutoryName { get; set; }
        public string? Prefix { get; set; }
        public string? IsLeaf { get; set; }
        public string? Mname { get; set; }
        public string? Mode { get; set; }
        public int? DelFlag { get; set; }
        public string? PlantCode { get; set; }
        public string? CompanyId { get; set; }
        public string? Inspection { get; set; }
        public int? SeqSm { get; set; }
        public string? InsOper { get; set; }
        public DateTime? InsDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? DeleteQry { get; set; }
        public string? UpdateQry { get; set; }
        public string? InsertQry { get; set; }
        public int? Seq { get; set; }
    }
}
