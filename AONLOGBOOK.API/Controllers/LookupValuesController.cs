using AONLOGBOOK.API.Services;
using AONLOGBOOK.SHARED.CModels;
using AONLOGBOOK.SHARED.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AONLOGBOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupValuesController : ControllerBase
    {
        private readonly SqlService _sql;
        public LookupValuesController(SqlService _sqlS)
        {

            _sql = _sqlS;

        }

        [HttpGet]
        public ActionResult<IEnumerable<TblLookupValue>?> GetTblLookupValues()
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}

           };
            return _sql.getDatas<TblLookupValue>("uspLookupValues", @params);

        }
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblLookupValue?> GetTblLookupValues(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblLookupValue>("uspLookupValues", @params);
        }
        // Get Specific Record
        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblLookupValue>?> ActTblLookupValues()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblLookupValue>("uspLookupValues", @params);
        }
        // POST: api/ShiftMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblLookupValues(lookupEleList le)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="@lookupParams",Direction=ParameterDirection.Input,Value=_sql.ToDataTable<lookupElement>(le.Tbllookup),SqlDbType=SqlDbType.Structured,TypeName="dbo.tvpLookUp"},
                new SqlParameter {ParameterName="@nameValue",Direction =ParameterDirection.Input,Value = le.NameValue },
                new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = le.CompanyId },
                new SqlParameter {ParameterName="@lookupID",Direction =ParameterDirection.Input,Value = le.LookupId},
                new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = le.PlantId },
                new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = le.CreatedBy }
            };
            _sql.postData("uspLookupValues", @params);
            return Ok("Record Inserted");
        }
    }
}
