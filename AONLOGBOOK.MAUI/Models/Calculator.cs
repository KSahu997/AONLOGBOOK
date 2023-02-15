using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.MAUI.Models
{
    public class Calculator
    {
        public string Tag { get; set; }
        public string Operator { get; set; }
        public string Num { get; set; }
        public List<string> formula { get; set; }
    }
}
