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
    public class ShiftMastersController : ControllerBase
    {
        private readonly SqlService _sql;
        public ShiftMastersController(SqlService _sqlS)
        {
            _sql = _sqlS;
        }

        // Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblShiftMaster>?> GetTblShiftMasters()
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}

           };
            return _sql.getDatas<TblShiftMaster>("uspShift", @params);

        }
        // GET: api/ShiftMasters/5
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblShiftMaster?> GetTblShiftMaster(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblShiftMaster>("uspShift", @params);
        }
        // Get Specific Record
        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblShiftMaster>?> ActTblShiftMaster()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblShiftMaster>("uspShift", @params);
        }



        // POST: api/ShiftMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblShiftMaster(TblShiftMaster TblShiftMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="@Company_Id",Direction =ParameterDirection.Input,Value = TblShiftMaster.CompanyId },
                new SqlParameter {ParameterName="@Shift_start",Direction =ParameterDirection.Input,Value = TblShiftMaster.Shift_start},
                new SqlParameter {ParameterName="@Shift_prefix",Direction =ParameterDirection.Input,Value = TblShiftMaster.Shift_prefix },
                new SqlParameter {ParameterName="@Shift_hour",Direction =ParameterDirection.Input,Value = TblShiftMaster.Shifthour }
            };
            _sql.postData("uspShift", @params);
            return Ok(TblShiftMaster.Shift_prefix + " Created"); 
        }
        [HttpPost("UPD")]
        public ActionResult UpdTblShiftMaster(TblShiftMaster TblShiftMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=TblShiftMaster.Id},
                new SqlParameter {ParameterName="@Company_Id",Direction =ParameterDirection.Input,Value = TblShiftMaster.CompanyId },
                new SqlParameter {ParameterName="@Shift_start",Direction =ParameterDirection.Input,Value = TblShiftMaster.Shift_start},
                new SqlParameter {ParameterName="@Shift_prefix",Direction =ParameterDirection.Input,Value = TblShiftMaster.Shift_prefix },
                new SqlParameter {ParameterName="@Shift_hour",Direction =ParameterDirection.Input,Value = TblShiftMaster.Shifthour }
            };
            _sql.postData("uspShift", @params);
            return Ok(TblShiftMaster.Shift_prefix + " Updated"); 
        }
    }
}
