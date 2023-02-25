using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblDeptMaster
    {
        public Guid Id { get; set; }

        public string? Dept_Name { get; set; }

        public string? Plant_Id { get; set; }

        public string? Company_Id { get; set; }

        public bool? Is_Leaf { get; set; }

        public DateTime? Doc_Date { get; set; }

        public string? F_Year { get; set; }

        public DateTime? Created_On { get; set; }

        public string? Created_By { get; set; }

        public DateTime? Modified_On { get; set; }

        public string? Modified_By { get; set; }

        public int? Status_F { get; set; }
    }
}
