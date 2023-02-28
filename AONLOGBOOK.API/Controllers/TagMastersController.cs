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
    public class TagMastersController : ControllerBase
    {
        private readonly SqlService _sql;
        public TagMastersController(SqlService _sqlS)
        {

            _sql = _sqlS;

        }

        [HttpGet]

        public ActionResult<IEnumerable<TblTagMaster>>GetTblTagMasters()
        {
            SqlParameter[] @params =
            {
                new SqlParameter{ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}
            };
            return _sql.getDatas<TblTagMaster>("usptagMaster", @params);
        }

        [HttpGet("{id}")]
        public ActionResult<TblTagMaster?> GetTblTagMasters(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblTagMaster>("usptagMaster", @params);
        }

        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblTagMaster>?> ActTblTagMasters()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblTagMaster>("usptagMaster", @params);
        }

        [HttpPost]
        public ActionResult PostTblTagMasters(TblTagMaster tblTagMasters)
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@tagname",Direction =ParameterDirection.Input,Value = tblTagMasters.Tag_Name },
            new SqlParameter {ParameterName="@display",Direction =ParameterDirection.Input,Value = tblTagMasters.Display_Name },
            new SqlParameter {ParameterName="@uom",Direction =ParameterDirection.Input,Value = tblTagMasters.UOM },
            new SqlParameter {ParameterName="@By",Direction =ParameterDirection.Input,Value = tblTagMasters.Created_By },
           
            };
            _sql.postData("usptagMaster", @params);
            return Ok("Tag Created");
        }

        [HttpPost("UPD")]
        public ActionResult UpdTblTagMaster(TblTagMaster tblTagMasters)
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@tagname",Direction =ParameterDirection.Input,Value = tblTagMasters.Tag_Name },
            new SqlParameter {ParameterName="@Id",Direction =ParameterDirection.Input,Value = tblTagMasters.ID },
            new SqlParameter {ParameterName="@display",Direction =ParameterDirection.Input,Value = tblTagMasters.Display_Name },
            new SqlParameter {ParameterName="@uom",Direction =ParameterDirection.Input,Value = tblTagMasters.UOM },
            new SqlParameter {ParameterName="@By",Direction =ParameterDirection.Input,Value = tblTagMasters.Updated_By },
            new SqlParameter {ParameterName="@delflag",Direction =ParameterDirection.Input,Value = tblTagMasters.Is_Deleted },

            };
            _sql.postData("usptagMaster", @params);
            return Ok(tblTagMasters.Tag_Name +" Updated");
        }
    }

}
