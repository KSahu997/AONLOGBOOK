using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblLogbookMaster
    {
        public Guid LogbookId { get; set; }

        public string? Department { get; set; }

        public string? SubDepartment { get; set; }

        public string? LogbookName { get; set; }

        public string? StatutoryName { get; set; }

        public string? Prefix { get; set; }

        public string? isLeaf { get; set; }

        public string? MName { get; set; }
        public int? IsLookup { get; set; }

        public string? Mode { get; set; }

        public int? Del_Flag { get; set; }

        public string? PlantCode { get; set; }

        public string? Company_Id { get; set; }

        public string? Inspection { get; set; }

        public int? Seq_sm { get; set; }

        public string? InsOper { get; set; }

        public DateTime? InsDate { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? DeleteQry { get; set; }

        public string? UpdateQry { get; set; }

        public string? InsertQry { get; set; }

        public int? Seq { get; set; }
    }
}
