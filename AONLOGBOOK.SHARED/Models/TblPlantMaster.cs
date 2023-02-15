using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblPlantMaster
    {
        public Guid Id { get; set; }
        public string? PlantId { get; set; }
        public string? PlantName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int? PinCode { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
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
