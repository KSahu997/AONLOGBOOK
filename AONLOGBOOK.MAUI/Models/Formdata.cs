using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.MAUI.Models
{
    public class Formdata
    {
        [Required]
        public string Department { get; set; }
        [Required]
        public string SubDepartment { get; set; }
        [Required]
        public string logbook { get; set; }

        public DateTime? Date { get; set; }
        public string? Shift { get; set; }
    }
}
