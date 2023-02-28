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
    public class LookupCreationController : ControllerBase
    {
        private readonly SqlService _sql;
        public LookupCreationController(SqlService _sqlS)
        {
            _sql = _sqlS;
        }
        // Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblLookup>?> GetTblLookup()
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}

           };
            return _sql.getDatas<TblLookup>("uspLookup", @params);

        }
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblLookup?> GetTblLookup(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblLookup>("uspLookup", @params);
        }
        // Get Specific Record
        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblLookup>?> ActTblLookup()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblLookup>("uspLookup", @params);
        }
        // POST: api/ShiftMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblLookup(TblLookup tblLookup)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="@Name",Direction =ParameterDirection.Input,Value = tblLookup.Name },
                new SqlParameter {ParameterName="@CompanyID",Direction =ParameterDirection.Input,Value = tblLookup.Company_ID},
                new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value = tblLookup.Plant_Id },
                new SqlParameter {ParameterName="@User",Direction =ParameterDirection.Input,Value = tblLookup.Created_By }
            };
            _sql.postData("uspLookup", @params);
            return Ok(tblLookup.Name + " Created");
        }
        [HttpPost("UPD")]
        public ActionResult UpdTblLookup(TblLookup tblLookup)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@Name",Direction =ParameterDirection.Input,Value = tblLookup.Name },
                new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblLookup.ID},
                new SqlParameter {ParameterName="@Delf",Direction =ParameterDirection.Input,Value = tblLookup.Del_Flag},
                new SqlParameter {ParameterName="@User",Direction =ParameterDirection.Input,Value = tblLookup.Updated_By }
            };
            _sql.postData("uspLookup", @params);
            return Ok(tblLookup.Name + " Updated");
        }
    }
}
