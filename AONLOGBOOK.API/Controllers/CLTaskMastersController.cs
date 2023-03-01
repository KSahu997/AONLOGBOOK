using AONLOGBOOK.API.Services;
using AONLOGBOOK.SHARED.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AONLOGBOOK.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CLTaskMastersController : ControllerBase
	{

		private readonly SqlService _sql;
		public CLTaskMastersController(SqlService _sqlS)
		{

			_sql = _sqlS;

		}

		[HttpGet]
		public ActionResult<IEnumerable<TblCLTask>?> GetTblCLTask(string workcenterid,string locationid,string equipmentid)
		{
			SqlParameter[] @params =
			{
				new SqlParameter{ParameterName="@type",Direction=ParameterDirection.Input,Value="ALL"},
				new SqlParameter{ParameterName="@Workcenterid",Direction=ParameterDirection.Input,Value=workcenterid},
				new SqlParameter{ParameterName="@FunctionalLocId",Direction=ParameterDirection.Input,Value=locationid},
				new SqlParameter{ParameterName="@EqpId",Direction=ParameterDirection.Input,Value=equipmentid},
			};
			return _sql.getDatas<TblCLTask>("uspTaskMaster", @params);
		}

		[HttpGet("{id}")]
		public ActionResult<TblCLTask?> GetTblCLTask(Guid id)
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="SEL"},
			new SqlParameter {ParameterName="@Id",Direction=ParameterDirection.Input,Value=id}

		   };
			return _sql.getData<TblCLTask>("uspTaskMaster", @params);
		}

		[HttpGet("ACT/{companyid}")]
		public ActionResult<IEnumerable<TblCLTask>?> ActTblCLTask(Guid companyid)
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="ACT"},
			new SqlParameter {ParameterName="@CompanyId",Direction=ParameterDirection.Input,Value=companyid},
		   };
			return _sql.getDatas<TblCLTask>("uspTaskMaster", @params);
		}

		[HttpPost]
		public ActionResult PostTblEquipmentMaster(TblCLTask TblCLTask)
		{
			SqlParameter[] @params =
			{
				new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
				new SqlParameter {ParameterName="@CompanyId",Direction =ParameterDirection.Input,Value = TblCLTask.Company_ID },
				new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value = TblCLTask.Plant_ID },
				new SqlParameter {ParameterName="@Workcenterid",Direction =ParameterDirection.Input,Value = TblCLTask.WorkCenter_ID },
				new SqlParameter {ParameterName="@FunctionalLocId",Direction =ParameterDirection.Input,Value = TblCLTask.FunctionalLocation_ID },
				new SqlParameter {ParameterName="@EqpId",Direction =ParameterDirection.Input,Value = TblCLTask.Equipment_ID },
				new SqlParameter {ParameterName="@TaskGrpId",Direction =ParameterDirection.Input,Value = TblCLTask.Task_Group_ID },
				new SqlParameter {ParameterName="@taskname",Direction =ParameterDirection.Input,Value = TblCLTask.Task_Name },
				new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = TblCLTask.Inserted_By },

			};
			_sql.postData("uspTaskMaster", @params);
			return Ok(TblCLTask.Task_Name + " Created");
		}
		[HttpPost("UPD")]
		public ActionResult UpdTblEquipmentMaster(TblCLTask TblCLTask)
		{
			SqlParameter[] @params =
			{
				new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
				new SqlParameter {ParameterName="@CompanyId",Direction =ParameterDirection.Input,Value = TblCLTask.Company_ID },
				new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value = TblCLTask.Plant_ID },
				new SqlParameter {ParameterName="@Workcenterid",Direction =ParameterDirection.Input,Value = TblCLTask.WorkCenter_ID },
				new SqlParameter {ParameterName="@FunctionalLocId",Direction =ParameterDirection.Input,Value = TblCLTask.FunctionalLocation_ID },
				new SqlParameter {ParameterName="@EqpId",Direction =ParameterDirection.Input,Value = TblCLTask.Equipment_ID },
				new SqlParameter {ParameterName="@TaskGrpId",Direction =ParameterDirection.Input,Value = TblCLTask.Task_Group_ID },
				new SqlParameter {ParameterName="@taskname",Direction =ParameterDirection.Input,Value = TblCLTask.Task_Name },
				new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = TblCLTask.Updated_By },
			};
			_sql.postData("uspTaskMaster", @params);
			return Ok("Task Updated");
		}

	}
}
