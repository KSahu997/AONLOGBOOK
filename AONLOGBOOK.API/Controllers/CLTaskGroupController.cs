using AONLOGBOOK.API.Services;
using AONLOGBOOK.SHARED.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AONLOGBOOK.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CLTaskGroupController : ControllerBase
	{
		private readonly SqlService _sql;
		public CLTaskGroupController(SqlService _sqlS)
		{

			_sql = _sqlS;

		}

		[HttpGet]
		public ActionResult<IEnumerable<TblCLTaskGroup>?> GetTblCLTaskGroup()
		{
			SqlParameter[] @params =
			{
				new SqlParameter{ParameterName="@type",Direction=ParameterDirection.Input,Value="ALL"}
			};
			return _sql.getDatas<TblCLTaskGroup>("uspCLTaskGroup", @params);
		}

		[HttpGet("{id}")]
		public ActionResult<TblCLTaskGroup?> GetTblCLTaskGroup(Guid id)
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="SEL"},
			new SqlParameter {ParameterName="@Id",Direction=ParameterDirection.Input,Value=id}

		   };
			return _sql.getData<TblCLTaskGroup>("uspCLTaskGroup", @params);
		}

		[HttpGet("ACT")]
		public ActionResult<IEnumerable<TblCLTaskGroup>?> ActTblCLTaskGroup()
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="ACT"},
		   };
			return _sql.getDatas<TblCLTaskGroup>("uspCLTaskGroup", @params);
		}

		[HttpPost]
		public ActionResult PostTblEquipmentMaster(TblCLTaskGroup TblCLTaskGroup)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
			new SqlParameter {ParameterName="@CompanyId",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.Company_ID },
			new SqlParameter {ParameterName="@taskname",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.Task_Group_Name },
			new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.Plant_ID },
			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.Inserted_By },

			};
			_sql.postData("uspCLTaskGroup", @params);
			return Ok(TblCLTaskGroup.Task_Group_Name + " Created");
		}
		[HttpPost("UPD")]
		public ActionResult UpdTblEquipmentMaster(TblCLTaskGroup TblCLTaskGroup)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
			new SqlParameter {ParameterName="@Id",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.ID },
			new SqlParameter {ParameterName="@CompanyId",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.Company_ID },
			new SqlParameter {ParameterName="@taskname",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.Task_Group_Name },
			new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.Plant_ID },
			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = TblCLTaskGroup.Inserted_By },

			};
			_sql.postData("uspCLTaskGroup", @params);
			return Ok("Task Updated");
		}

	}
	}
}
