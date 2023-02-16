using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.SHARED.CModels
{
    public class LogData
    {
        //public Guid Id { get; set; }
        public string? LogbookId { get; set; }
        public string? ParamName { get; set; }
        public string? Val { get; set; }
        public string? CompanyId { get; set; }
        public string? PlantId { get; set; }
        public string? DeptId { get; set; }
        public string? SubDeptId { get; set; }
        public string? Shift { get; set; }
        
        public string? MarkforDeletion { get; set; }
        public string? Uom { get; set; }
    }
}
