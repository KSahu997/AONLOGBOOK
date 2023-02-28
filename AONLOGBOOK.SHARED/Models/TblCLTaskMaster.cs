using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.SHARED.Models
{
	public class TblCLTaskMaster
	{
		public Guid ID { get; set; }

		public string? CompanyID { get; set; }

		public string? Based_on { get; set; }

		public string? Action { get; set; }

		public int? Del_Flag { get; set; }

		public string? Updated_By { get; set; }

		public DateTime? Updated_On { get; set; }

		public string? Inserted_By { get; set; }

		public DateTime? Inserted_On { get; set; }
	}
}
