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
	public class EquipmentMastersController : ControllerBase
	{

		private readonly SqlService _sql;
		public EquipmentMastersController(SqlService _sqlS)
		{

			_sql = _sqlS;

		}

		[HttpGet]
		public ActionResult<IEnumerable<TblEquipmentMaster>?> GetTblEquipmentMaster()
		{
			SqlParameter[] @params =
			{
				new SqlParameter{ParameterName="@type",Direction=ParameterDirection.Input,Value="ALL"}
			};
			return _sql.getDatas<TblEquipmentMaster>("uspEquipment", @params);
		}

		[HttpGet("{id}")]
		public ActionResult<TblEquipmentMaster?> GetTblEquipmentMaster(Guid id)
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="SEL"},
			new SqlParameter {ParameterName="@ID",Direction=ParameterDirection.Input,Value=id}

		   };
			return _sql.getData<TblEquipmentMaster>("uspEquipment", @params);
		}

		[HttpGet("ACT")]
		public ActionResult<IEnumerable<TblEquipmentMaster>?> ActTblEquipmentMaster()
		{
			SqlParameter[] @params =
		   {
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="ACT"},
		   };
			return _sql.getDatas<TblEquipmentMaster>("uspEquipment", @params);
		}

		[HttpPost]
		public ActionResult PostTblEquipmentMaster(TblEquipmentMaster tblEquipmentMaster)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
			new SqlParameter {ParameterName="@EquipName",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Equipment_Name },
			new SqlParameter {ParameterName="@EquipCode",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Equipment_Code },
			new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Company_ID },
			new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Plant_ID },
			new SqlParameter {ParameterName="@WorkCenID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.WorkCenter_ID },
			new SqlParameter {ParameterName="@funcLocID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Func_Location_ID },
			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Inserted_By },

			};
			_sql.postData("uspEquipment", @params);
			return Ok(tblEquipmentMaster.Equipment_Name + " Created");
		}
		[HttpPost("UPD")]
		public ActionResult UpdTblEquipmentMaster(TblEquipmentMaster tblEquipmentMaster)
		{
			SqlParameter[] @params =
			{
			new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
			new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.ID },
			new SqlParameter {ParameterName="@EquipName",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Equipment_Name },
			new SqlParameter {ParameterName="@EquipCode",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Equipment_Code },

			new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Updated_By },
			new SqlParameter {ParameterName="@Delflag",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Del_Flag },

			};
			_sql.postData("uspEquipment", @params);
			return Ok(tblEquipmentMaster.Equipment_Name + " Updated");
		}




	}
}
