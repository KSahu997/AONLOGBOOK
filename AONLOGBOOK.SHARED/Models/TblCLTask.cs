﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AONLOGBOOK.SHARED.Models
{
	public class TblCLTask
	{
		public Guid ID { get; set; }

		public string? Company_ID { get; set; }

		public string? Plant_ID { get; set; }

		public string? WorkCenter_ID { get; set; }

		public string? FunctionalLocation_ID { get; set; }

		public string? Equipment_ID { get; set; }

		public string? Task_Group_ID { get; set; }

		public string? Task_Name { get; set; }

		public string? Inserted_By { get; set; }

		public DateTime? Inserted_On { get; set; }

		public string? Updated_By { get; set; }

		public DateTime? Updated_On { get; set; }

		public int? Del_Flag { get; set; }
	}
}
