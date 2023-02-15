using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.SHARED.CModels
{
    public class LogDataList
    {
        public List<LogData> TblLog { get; set; } =new List<LogData>();
        public LogDataHeader TblLogHead {get;set;}
    }
}
