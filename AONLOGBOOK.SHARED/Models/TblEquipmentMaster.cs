using System;
using System.Collections.Generic;

namespace AONLOGBOOK.SHARED.Models
{
    public partial class TblEquipmentMaster
    {
        public Guid Id { get; set; }
		public string Equipment_Name { get; set; }
		public string Equipment_Code { get; set; }
		public string WorkCenter_ID { get; set; }
		public string Func_Location_ID { get; set; }
		public string Company_ID { get; set; }
		public string Plant_ID { get; set; }
		public int Del_Flag { get; set; }
		public string Inserted_By { get; set; }
		public string UpdatedBy{ get; set; }
		public string UpdatedOn { get; set; }
		public DateTime Inserted_On { get; set; }
	}
}
