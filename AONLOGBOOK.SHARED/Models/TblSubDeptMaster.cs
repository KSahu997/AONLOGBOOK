using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblSubDeptMaster
    {
        public Guid Id { get; set; }
        public string? SubDptId { get; set; }
        public string? SubDptName { get; set; }
        public string? DeptId { get; set; }
        public string? PlantId { get; set; }
        public string? CompanyId { get; set; }
        public DateTime? DocDate { get; set; }
        public string? FYear { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public int? StatusF { get; set; }
    }
}
