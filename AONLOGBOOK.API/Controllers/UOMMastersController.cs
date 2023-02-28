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
    public class UOMMastersController : ControllerBase
    {
        private readonly SqlService _sql;
        public UOMMastersController(SqlService _sqlS)
        {

            _sql = _sqlS;

        }

        [HttpGet]

        public ActionResult<IEnumerable<TblUommaster>> GetTblUomMasters()
        {
            SqlParameter[] @params =
            {
                new SqlParameter{ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}
            };
            return _sql.getDatas<TblUommaster>("uspUOMmaster", @params);
        }

        [HttpGet("{id}")]
        public ActionResult<TblUommaster?> GetTblUomMasters(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@Id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblUommaster>("uspUOMmaster", @params);
        }

        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblUommaster>?> ActTblUomMasters()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblUommaster>("uspUOMmaster", @params);
        }

        [HttpPost]
        public ActionResult PostTblUomMasters(TblUommaster tblUommaster)
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@unit",Direction =ParameterDirection.Input,Value = tblUommaster.Unit},
           

            };
            _sql.postData("uspUOMmaster", @params);
            return Ok("Uom Created");
        }
    }
}
