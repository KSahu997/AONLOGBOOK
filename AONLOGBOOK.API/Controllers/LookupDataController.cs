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
    public class LookupDataController : ControllerBase
    {
        private readonly SqlService _sql;
        public LookupDataController(SqlService _sqlS)
        {
            _sql = _sqlS;
        }
        [HttpGet("{TextSchema}/{ValueSchema}")]
        public ActionResult<IEnumerable<LookupData>?> GetTblLookupData(Guid TextSchema, Guid ValueSchema)
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@textSchema",Direction=ParameterDirection.Input,Value=TextSchema},
            new SqlParameter {ParameterName="@valueSchema",Direction=ParameterDirection.Input,Value=ValueSchema}

           };
            return _sql.getDatas<LookupData>("uspLookup", @params);

        }
    }
}
