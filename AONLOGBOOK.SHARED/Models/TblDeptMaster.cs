using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblDeptMaster
    {
        public Guid Id { get; set; }
        
        public string? Dept_Id { get; set; }
        public string? Dept_Name { get; set; }
        public string? Plant_Id { get; set; }
        public string? Company_Id { get; set; }
        public bool? IsLeaf { get; set; }
        public DateTime? Doc_Date { get; set; }
        public string? F_Year { get; set; }
        public DateTime? Created_On { get; set; }
        public string? Created_By { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public int? StatusF { get; set; }
    }
}
