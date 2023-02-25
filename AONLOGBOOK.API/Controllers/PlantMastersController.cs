using AONLOGBOOK.API.Services;
using AONLOGBOOK.SHARED.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AONLOGBOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantMastersController : ControllerBase
    {
        private readonly SqlService _sql;
        public PlantMastersController(SqlService _sqlS)
        {
            _sql = _sqlS;
        }

        // Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblPlantMaster>?> GetTblPlantMasters()
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}

           };
            return _sql.getDatas<TblPlantMaster>("uspPlant", @params);

        }
        // GET: api/PlantMasters/5
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblPlantMaster?> GetTblPlantMaster(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblPlantMaster>("uspPlant", @params);
        }
        // Get Specific Record
        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblPlantMaster>?> ActTblPlantMaster()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblPlantMaster>("uspPlant", @params);
        }



        // POST: api/PlantMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblPlantMaster(TblPlantMaster TblPlantMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="@Plant_Name",Direction=ParameterDirection.Input,Value=TblPlantMaster.Plant_Name},
                new SqlParameter {ParameterName="@Address",Direction=ParameterDirection.Input,Value=TblPlantMaster.Address},
                new SqlParameter {ParameterName="@Country",Direction=ParameterDirection.Input,Value=TblPlantMaster.Country},
                new SqlParameter {ParameterName="@State",Direction=ParameterDirection.Input,Value=TblPlantMaster.State},
                new SqlParameter {ParameterName="@City",Direction=ParameterDirection.Input,Value=TblPlantMaster.City},
                new SqlParameter {ParameterName="@Pin",Direction =ParameterDirection.Input,Value = TblPlantMaster.PinCode},
                new SqlParameter {ParameterName="@Email",Direction =ParameterDirection.Input,Value = TblPlantMaster.Email},
                new SqlParameter {ParameterName="@Phone",Direction =ParameterDirection.Input,Value = TblPlantMaster.Phone_no},
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=TblPlantMaster.Created_By},
            };
            _sql.postData("uspPlant", @params);
            return Ok(TblPlantMaster.Plant_Name + " Created"); ;
        }
        [HttpPost("UPD")]
        public ActionResult UpdTblPlantMaster(TblPlantMaster TblPlantMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=TblPlantMaster.ID},
                new SqlParameter {ParameterName="@Plant_Name",Direction=ParameterDirection.Input,Value=TblPlantMaster.Plant_Name},
                new SqlParameter {ParameterName="@Address",Direction=ParameterDirection.Input,Value=TblPlantMaster.Address},
                new SqlParameter {ParameterName="@Country",Direction=ParameterDirection.Input,Value=TblPlantMaster.Country},
                new SqlParameter {ParameterName="@State",Direction=ParameterDirection.Input,Value=TblPlantMaster.State},
                new SqlParameter {ParameterName="@City",Direction=ParameterDirection.Input,Value=TblPlantMaster.City},
                new SqlParameter {ParameterName="@Pin",Direction =ParameterDirection.Input,Value = TblPlantMaster.PinCode},
                new SqlParameter {ParameterName="@Email",Direction =ParameterDirection.Input,Value = TblPlantMaster.Email},
                new SqlParameter {ParameterName="@Phone",Direction =ParameterDirection.Input,Value = TblPlantMaster.Phone_no},
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=TblPlantMaster.Created_By},
            };
            _sql.postData("uspPlant", @params);
            return Ok(TblPlantMaster.Plant_Name + " Updated");
        }
    }
}
