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
    public class LogbookMastersController : ControllerBase
    {
        private readonly SqlService _sql;
        public LogbookMastersController(SqlService _sqlS)
        {
            _sql = _sqlS;

        }


        //Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblLogbookMaster>?> GetTblLogbookMasters()
        {
            SqlParameter[] @params =
           {
                new SqlParameter{ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"},

           };
            return _sql.getDatas<TblLogbookMaster>("uspLogBookMasterEntry", @params);
        }

        //Get by Id
        [HttpGet("{id}")]

        public ActionResult<TblLogbookMaster?> GetTblLogbookMasters(Guid id)
        {
            SqlParameter[] @params =
            {
                new SqlParameter { ParameterName = "@logbookId", Direction = ParameterDirection.Input, Value = id },
                new SqlParameter{ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"}
            };
            return _sql.getData<TblLogbookMaster>("uspLogBookMasterEntry", @params);
        }

        [HttpGet("ACT")]

        public ActionResult<IEnumerable<TblLogbookMaster>?>ActTblLogbookMasters()
        {
            SqlParameter[] @params =
            {
                new SqlParameter{ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
            };
            return _sql.getDatas<TblLogbookMaster>("uspLogBookMasterEntry", @params);
        }

        [HttpPost]

        public ActionResult PostTblLogbookMasters(TblLogbookMaster tblLogbookMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="@Department",Direction=ParameterDirection.Input,Value=tblLogbookMaster.Department},
                new SqlParameter {ParameterName="@SubDept",Direction=ParameterDirection.Input,Value=tblLogbookMaster.SubDepartment},
                new SqlParameter {ParameterName="@LogbookName",Direction=ParameterDirection.Input,Value=tblLogbookMaster.LogbookName},
                new SqlParameter {ParameterName="@Company_Id",Direction=ParameterDirection.Input,Value=tblLogbookMaster.Company_Id},
                new SqlParameter {ParameterName="@Prefix",Direction=ParameterDirection.Input,Value=tblLogbookMaster.Prefix},
                new SqlParameter {ParameterName="@PlantCode",Direction =ParameterDirection.Input,Value = tblLogbookMaster.PlantCode},
                new SqlParameter {ParameterName="@Sequence",Direction =ParameterDirection.Input,Value = tblLogbookMaster.Seq},
                new SqlParameter {ParameterName="@islookup",Direction =ParameterDirection.Input,Value = tblLogbookMaster.IsLookup},
               
            };
            _sql.postData("uspLogBookMasterEntry", @params);
            return Ok(tblLogbookMaster.LogbookName + " Created"); ;
        }

        [HttpPost("UPD")]
        public ActionResult UpdTblLogbookMasters(TblLogbookMaster tblLogbookMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@logbookId",Direction=ParameterDirection.Input,Value=tblLogbookMaster.LogbookId},
                new SqlParameter {ParameterName="@LogbookName",Direction=ParameterDirection.Input,Value=tblLogbookMaster.LogbookName},
                new SqlParameter {ParameterName="@Delflag",Direction=ParameterDirection.Input,Value=tblLogbookMaster.Del_Flag},
                 new SqlParameter {ParameterName="@islookup",Direction =ParameterDirection.Input,Value = tblLogbookMaster.IsLookup},
               //new SqlParameter {ParameterName="@Department",Direction=ParameterDirection.Input,Value=tblLogbookMaster.Department},
               // new SqlParameter {ParameterName="@SubDept",Direction=ParameterDirection.Input,Value=tblLogbookMaster.SubDepartment},
               // new SqlParameter {ParameterName="@Company_Id",Direction=ParameterDirection.Input,Value=tblLogbookMaster.Company_Id},
               //new SqlParameter {ParameterName="@PlantCode",Direction =ParameterDirection.Input,Value = tblLogbookMaster.PlantCode},

            };
            _sql.postData("uspLogBookMasterEntry", @params);
             return Ok(tblLogbookMaster.LogbookName + " Updated"); ;
        }
    }
}
