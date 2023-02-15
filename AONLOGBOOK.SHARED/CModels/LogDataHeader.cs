using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.SHARED.CModels
{
    public class LogDataHeader
    {
        public string? LogbookId { get; set; }
        public string? CompanyId { get; set; }
        public string? PlantId { get; set; }
        public string? DeptId { get; set; }
        public string? SubDeptId { get; set; }
        public string? Shift { get; set; }
        public DateTime? date { get; set; }
        public string? CreatedBy { get; set; }
        public int? StatusF { get; set; }
    }
}
