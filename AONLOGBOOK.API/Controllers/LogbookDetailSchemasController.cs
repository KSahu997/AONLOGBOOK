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
    public class LogbookDetailSchemasController : ControllerBase
    {
        private readonly SqlService _sql;
        public LogbookDetailSchemasController(SqlService _sqlS)
        {

            _sql = _sqlS;

        }

        // Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblLogbookDetailSchema>?> GetTblLogbookDetailSchemaMasters()
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}

           };
            return _sql.getDatas<TblLogbookDetailSchema>("uspLogbookDetailSchema", @params);

        }
        // GET: api/LogbookDetailSchemaMasters/5
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblLogbookDetailSchema?> GetTblLogbookDetailSchemaMaster(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblLogbookDetailSchema>("uspLogbookDetailSchema", @params);
        }
        // Get Specific Record
        [HttpGet("ACT/{Logbookid}")]
        public ActionResult<IEnumerable<TblLogbookDetailSchemasMD>?> ActTblLogbookDetailSchemaMaster(string Logbookid)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
            new SqlParameter {ParameterName="@LogbookId",Direction=ParameterDirection.Input,Value=Logbookid},
           };
            return _sql.getDatas<TblLogbookDetailSchemasMD>("uspLogbookDetailSchema", @params);
        }

     

        // POST: api/LogbookDetailSchemaMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblLogbookDetailSchemaMaster([FromBody]TblLogbookDetailSchemasMD tblLogbookDetailSchema)
        {
           
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@LogbookId",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.LogbookId},
            new SqlParameter {ParameterName="@Element",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.Element },
            new SqlParameter {ParameterName="@DataType",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.DataType },
            new SqlParameter {ParameterName="@lookupid",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.LookupId},
            new SqlParameter {ParameterName="@UOM",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.UOM },
            new SqlParameter {ParameterName="@source",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.Source },
            new SqlParameter {ParameterName="@L_min",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.L_Min },
            new SqlParameter {ParameterName="@L_max",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.L_Max },
            new SqlParameter {ParameterName="@Prscn",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.Prscn },
            new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.CreatedBy},
            new SqlParameter {ParameterName="@refcol",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.RefCol},
            new SqlParameter {ParameterName="@cal_param",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.CalulationParams},
            new SqlParameter {ParameterName="@operator",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.Operator},
            new SqlParameter {ParameterName="@TextSchema",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.Text_Schema},
            new SqlParameter {ParameterName="@ValueSchema",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.Value_Schema},
            new SqlParameter {ParameterName="@ismandatory",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.isMandatory},
            };

            _sql.postData("uspLogbookDetailSchema", @params);
            return Ok("Schema Created");
        }
        [HttpPost("UPD")]
        public ActionResult UpdTblLogbookDetailSchemaMaster(TblLogbookDetailSchemasMD tblLogbookDetailSchema)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@id",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.Id },
                new SqlParameter {ParameterName="@Delflag",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.Del_Flag},
                new SqlParameter {ParameterName="@Element",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.Element },
                new SqlParameter {ParameterName="@DataType",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.DataType },
                new SqlParameter {ParameterName="@UOM",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.UOM },
                new SqlParameter {ParameterName="@source",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.Source },
                new SqlParameter {ParameterName="@L_min",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.L_Min },
                new SqlParameter {ParameterName="@L_max",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.L_Max },
                new SqlParameter {ParameterName="@Prscn",Direction =ParameterDirection.Input,Value = tblLogbookDetailSchema.Prscn},
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.UpdatedBy},
                new SqlParameter {ParameterName="@refcol",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.RefCol},
                new SqlParameter {ParameterName="@cal_param",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.CalulationParams},
                new SqlParameter {ParameterName="@operator",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.Operator},
                 new SqlParameter {ParameterName="@ismandatory",Direction=ParameterDirection.Input,Value=tblLogbookDetailSchema.isMandatory},
            };
            _sql.postData("uspLogbookDetailSchema", @params);
            return Ok("Schema Updated");
        }
    }
}
