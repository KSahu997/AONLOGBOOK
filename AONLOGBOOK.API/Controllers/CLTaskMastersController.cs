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
		public ActionResult<IEnumerable<TblCLTaskMaster>?> GetTblCLTaskMaster()
		{
			SqlParameter[] @params =
			{
				new SqlParameter{ParameterName="@type",Direction=ParameterDirection.Input,Value="ALL"}
			};
			return _sql.getDatas<TblCLTaskMaster>("uspTaskMaster", @params);
		}

		[HttpGet("{id}")]
		public ActionResult<TblCLTaskMaster?> GetTblCLTaskMaster(Guid id)
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="SEL"},
			new SqlParameter {ParameterName="@Id",Direction=ParameterDirection.Input,Value=id}

		   };
			return _sql.getData<TblCLTaskMaster>("uspTaskMaster", @params);
		}

		[HttpGet("ACT")]
		public ActionResult<IEnumerable<TblCLTaskMaster>?> ActTblCLTaskMaster()
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="ACT"},
		   };
			return _sql.getDatas<TblCLTaskMaster>("uspTaskMaster", @params);
		}

		[HttpPost]
		public ActionResult PostTblEquipmentMaster(TblCLTaskMaster tblCLTaskMaster)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
			new SqlParameter {ParameterName="@CompanyId",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.CompanyID },
			new SqlParameter {ParameterName="@Basedon",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.Based_on },
			new SqlParameter {ParameterName="@Action",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.Action },
			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.Inserted_By },

			};
			_sql.postData("uspTaskMaster", @params);
			return Ok(tblCLTaskMaster.CompanyID + " Created");
		}
		[HttpPost("UPD")]
		public ActionResult UpdTblEquipmentMaster(TblCLTaskMaster tblCLTaskMaster)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
			new SqlParameter {ParameterName="@Id",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.ID },
			new SqlParameter {ParameterName="@Basedon",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.Based_on },
			new SqlParameter {ParameterName="@Action",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.Action },

			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.Updated_By },
			new SqlParameter {ParameterName="@Delflag",Direction =ParameterDirection.Input,Value = tblCLTaskMaster.Del_Flag },

			};
			_sql.postData("uspTaskMaster", @params);
			return Ok("Task Updated");
		}

	}
}
