using AONLOGBOOK.API.Models;
using AONLOGBOOK.API.Service;
using AONLOGBOOK.API.Services;
using AONLOGBOOK.SHARED.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;

namespace AONLOGBOOK.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EquipmentMastersController : ControllerBase
	{
		private readonly DBContext _context;
		private readonly CustomContext _ccontext;
		private readonly IConfiguration _con;
		private readonly SqlService _sql;
		

		public EquipmentMastersController(DBContext context, CustomContext ccontext, IConfiguration con, SqlService sql)
		{
			_context = context;
			_ccontext = ccontext;
			_con = con;
			_sql = sql;
		}
		
		[HttpGet("{id}")]
		public async Task<ActionResult<TblEquipmentMaster?>> GetTblEquipmentMaster(Guid id)
		{
			SqlParameter[] @param =
			{
				new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="SEL"},
				new SqlParameter {ParameterName="@ID",Direction=ParameterDirection.Input,Value = id}
				
			};
			return _sql.getData<TblEquipmentMaster>("uspEquipment",@param);
		}

		[HttpPost]
		public async Task<ActionResult> PostTblEquipment(TblEquipmentMaster tblEquipmentMaster)
		{

			//SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
			SqlParameter[] @params =
			{ 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
			new SqlParameter {ParameterName="@EquipName",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Equipment_Name },
			new SqlParameter {ParameterName="@EquipCode",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Equipment_Code },
			new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Company_ID },
			new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Plant_ID },
			new SqlParameter {ParameterName="@WorkCenID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.WorkCenter_ID },
			new SqlParameter {ParameterName="@funcLocID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Func_Location_ID },
			new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Id },
			new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=tblEquipmentMaster.Inserted_By},
			new SqlParameter {ParameterName="@Delflag",Direction=ParameterDirection.Input,Value=tblEquipmentMaster.Del_Flag},
			};
			_sql.postData("uspEquipment", @params);
			return Ok("success");
		}

		[HttpPost("update")]
		public async Task<ActionResult> UpdateTblEquipment(TblEquipmentMaster tblEquipmentMaster)
		{

			//SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
			SqlParameter[] @params =
			{ 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
			new SqlParameter {ParameterName="@EquipName",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Equipment_Name },
			new SqlParameter {ParameterName="@EquipCode",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Equipment_Code },
			new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Id },
			new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=tblEquipmentMaster.UpdatedBy},
			new SqlParameter {ParameterName="@Delflag",Direction=ParameterDirection.Input,Value=tblEquipmentMaster.Del_Flag},
			};
			 _sql.postData("uspEquipment", @params);
			return Ok("success");
		}
		[HttpPost("delete")]
		public async Task<ActionResult> DeleteTblEquipment(TblEquipmentMaster tblEquipmentMaster)
		{

			//SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
			SqlParameter[] @params=
			{ 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="DEL"},
			new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblEquipmentMaster.Id },
			new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=tblEquipmentMaster.Inserted_By}
			};
			_sql.postData("uspEquipment", @params);
			return Ok("success");
		}
	}
}
