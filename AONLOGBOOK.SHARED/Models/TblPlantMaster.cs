using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblPlantMaster
    {
        public Guid ID { get; set; }

        public string? Plant_Name { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public int? PinCode { get; set; }

        public string? Email { get; set; }

        public string? Phone_no { get; set; }

        public string? Company_Id { get; set; }

        public DateTime? Doc_Date { get; set; }

        public string? F_Year { get; set; }

        public DateTime? Created_On { get; set; }

        public string? Created_By { get; set; }

        public DateTime? Modified_On { get; set; }

        public string? Modified_By { get; set; }

        public int? Status_F { get; set; }

    }
}
