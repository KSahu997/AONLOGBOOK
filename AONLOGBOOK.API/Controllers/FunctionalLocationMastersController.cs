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
	public class FunctionalLocationMastersController : ControllerBase
	{
		private readonly SqlService _sql;
		public FunctionalLocationMastersController(SqlService _sqlS)
		{

			_sql = _sqlS;

		}

		[HttpGet]
		public ActionResult<IEnumerable<TblFunctionalLocationMaster>?> GetTblFunctionalLocationMasters()
		{
			SqlParameter[] @params =
			{
				new SqlParameter{ParameterName="@type",Direction=ParameterDirection.Input,Value="ALL"}
			};
			return _sql.getDatas<TblFunctionalLocationMaster>("uspFunctionalLocation", @params);
		}

		[HttpGet("{id}")]
		public ActionResult<TblFunctionalLocationMaster?> GetTblFunctionalLocationMasters(Guid id)
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="SEL"},
			new SqlParameter {ParameterName="@ID",Direction=ParameterDirection.Input,Value=id}

		   };
			return _sql.getData<TblFunctionalLocationMaster>("uspFunctionalLocation", @params);
		}

		// Get Specific Record
		[HttpGet("ACT")]
		public ActionResult<IEnumerable<TblFunctionalLocationMaster>?> ActTblFunctionalLocationMasters()
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="ACT"},
		   };
			return _sql.getDatas<TblFunctionalLocationMaster>("uspFunctionalLocation", @params);
		}

		[HttpPost]
		public ActionResult PostTblFunctionalLocationMasters(TblFunctionalLocationMaster tblFunctionalLocationMaster)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
			new SqlParameter {ParameterName="@FunName",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Functional_Location },
			new SqlParameter {ParameterName="@FunCode",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Location_Code },
			new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Company_ID },
			new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Plant_ID },
			new SqlParameter {ParameterName="@WorkCenID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.WorkCenter_ID },
			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Inserted_By },
		
			};
			_sql.postData("uspFunctionalLocation", @params);
			return Ok(tblFunctionalLocationMaster.Functional_Location + " Created");
		}
		[HttpPost("UPD")]
		public ActionResult UpdTblFunctionalLocationMasters(TblFunctionalLocationMaster tblFunctionalLocationMaster)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
			new SqlParameter {ParameterName="@FunName",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Functional_Location },
			new SqlParameter {ParameterName="@FunCode",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Location_Code },
		
			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Updated_By },
			new SqlParameter {ParameterName="@delflag",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Del_Flag },

			};
			_sql.postData("uspFunctionalLocation", @params);
			return Ok(tblFunctionalLocationMaster.Functional_Location + " Updated");
		}
	}
}
