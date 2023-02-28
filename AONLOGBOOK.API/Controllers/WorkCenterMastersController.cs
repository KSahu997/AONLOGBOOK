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
	public class WorkCenterMastersController : ControllerBase
	{
		private readonly SqlService _sql;
		public WorkCenterMastersController(SqlService _sqlS)
		{

			_sql = _sqlS;

		}

		[HttpGet]
		public ActionResult<IEnumerable<TblWorkCenterMaster>?>GetTblWorkCenterMasters()
		{
			SqlParameter[] @params =
			{
				new SqlParameter{ParameterName="@type",Direction=ParameterDirection.Input,Value="ALL"}
			};
			return _sql.getDatas<TblWorkCenterMaster>("uspWorkCenter", @params);
		}

		[HttpGet("{id}")]
		public ActionResult<TblWorkCenterMaster?> GetTblWorkCenterMasters(Guid id)
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="SEL"},
			new SqlParameter {ParameterName="@ID",Direction=ParameterDirection.Input,Value=id}

		   };
			return _sql.getData<TblWorkCenterMaster>("uspWorkCenter", @params);
		}
		// Get Specific Record
		[HttpGet("ACT")]
		public ActionResult<IEnumerable<TblWorkCenterMaster>?> ActTblWorkCenterMasters()
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="ACT"},
		   };
			return _sql.getDatas<TblWorkCenterMaster>("uspWorkCenter", @params);
		}

		[HttpPost]
		public ActionResult PostTblWorkCenterMaster(TblWorkCenterMaster tblWorkCenterMaster)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
			new SqlParameter {ParameterName="@WrokName",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.WorkCenter_Name },
			new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.Company_ID },
			new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.Plant_ID },
			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.Inserted_By },
			

			};
			_sql.postData("uspWorkCenter", @params);
			return Ok(tblWorkCenterMaster.WorkCenter_Name + " Created");
		}
		[HttpPost("UPD")]
		public ActionResult UpdTblWorkCenterMaster(TblWorkCenterMaster tblWorkCenterMaster)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
			new SqlParameter {ParameterName="@WrokName",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.WorkCenter_Name },
			new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.ID },

			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.Updated_By },
			new SqlParameter {ParameterName="@Delflag",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.Del_Flag },


			};
			_sql.postData("uspWorkCenter", @params);
			return Ok(tblWorkCenterMaster.WorkCenter_Name + " Updated");
		}

	}
}
