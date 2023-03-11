using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.MAUI.Models
{
    public class Formgroup
    {
        public Guid FormGroupId { get; set; }
#nullable enable


        public string? Plant { get; set; }

        public string? Dept { get; set; }

        public string? FormGroup { get; set; }

        public string? Role { get; set; }

        public int? DelFlag { get; set; }
#nullable disable


    }
}
