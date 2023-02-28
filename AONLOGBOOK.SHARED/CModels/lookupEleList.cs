using AONLOGBOOK.SHARED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.SHARED.CModels
{
    public class lookupEleList
    {
        public List<lookupElement> Tbllookup { get; set; } = new List<lookupElement>();
        public string? LookupId { get; set; }
        public string? NameValue { get; set; }
        public string? CompanyId { get; set; }
        public string? PlantId { get; set; }
        public string? CreatedBy { get; set; }
    }
}