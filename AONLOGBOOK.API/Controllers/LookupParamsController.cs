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
    public class LookupParamsController : ControllerBase
    {
        private readonly SqlService _sql;
        public LookupParamsController(SqlService _sqlS)
        {
            _sql = _sqlS;
        }
        // Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblLookupParam>?> GetTblLookupParam()
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}

           };
            return _sql.getDatas<TblLookupParam>("uspLookupParam", @params);

        }
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblLookupParam?> GetTblLookupParam(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblLookupParam>("uspLookupParam", @params);
        }
        // Get Specific Record
        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblLookupParam>?> ActTblLookupParam()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblLookupParam>("uspLookupParam", @params);
        }
        // POST: api/ShiftMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblLookupParam(TblLookupParam tblLookupParam)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="@CompanyID",Direction =ParameterDirection.Input,Value = tblLookupParam.Company_ID },
                new SqlParameter {ParameterName="@LookupID",Direction =ParameterDirection.Input,Value = tblLookupParam.Lookup_ID },
                new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value = tblLookupParam.Plant_ID},
                new SqlParameter {ParameterName="@User",Direction =ParameterDirection.Input,Value = tblLookupParam.Created_By},
                new SqlParameter {ParameterName="@Param",Direction =ParameterDirection.Input,Value = tblLookupParam.Param }
            };
            _sql.postData("uspLookupParam", @params);
            return Ok(tblLookupParam.Param + " Created");
        }
        [HttpPost("UPD")]
        public ActionResult UpdTblLookupParam(TblLookupParam tblLookupParam)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@Param",Direction =ParameterDirection.Input,Value = tblLookupParam.Param},
                new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblLookupParam.ID},
                new SqlParameter {ParameterName="@Delf",Direction =ParameterDirection.Input,Value = tblLookupParam.Del_Flag},
                new SqlParameter {ParameterName="@User",Direction =ParameterDirection.Input,Value = tblLookupParam.Updated_By }
            };
            _sql.postData("uspLookupParam", @params);
            return Ok(tblLookupParam.Param + " Updated");
        }
    }
}
