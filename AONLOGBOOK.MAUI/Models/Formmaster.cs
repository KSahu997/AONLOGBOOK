using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.MAUI.Models
{
    public class Formmaster
    {
        public Guid FormId { get; set; }

        public string FormGroup { get; set; } = null!;

        public string FormName { get; set; } = null!;

        public int? SeqSm { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? Seq { get; set; }


    }
}
