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
    public class SubDeptMastersController : ControllerBase
    {
        private readonly SqlService _sql;
        public SubDeptMastersController(SqlService _sqlS)
        {
            _sql = _sqlS;
        }

        // Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblSubDeptMaster>?> GetTblSubDeptMasters()
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}

           };
            return _sql.getDatas<TblSubDeptMaster>("uspSubDept", @params);

        }
        // GET: api/SubDeptMasters/5
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblSubDeptMaster?> GetTblSubDeptMaster(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblSubDeptMaster>("uspSubDept", @params);
        }
        // Get Specific Record
        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblSubDeptMaster>?> ActTblSubDeptMaster()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblSubDeptMaster>("uspSubDept", @params);
        }



        // POST: api/SubDeptMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblSubDeptMaster(TblSubDeptMaster TblSubDeptMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="@SubDepartment_Name",Direction =ParameterDirection.Input,Value =TblSubDeptMaster.SubDpt_Name},
                new SqlParameter {ParameterName="@Department_Id",Direction =ParameterDirection.Input,Value = TblSubDeptMaster.Dept_Id },
                new SqlParameter {ParameterName="@Plant_Id",Direction =ParameterDirection.Input,Value = TblSubDeptMaster.Plant_Id },
                new SqlParameter {ParameterName="@Company_Id",Direction =ParameterDirection.Input,Value = TblSubDeptMaster.Company_Id },
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=TblSubDeptMaster.Created_By},
            };
            _sql.postData("uspSubDept", @params);
            return Ok(TblSubDeptMaster.SubDpt_Name + " Created"); ;
        }
        [HttpPost("UPD")]
        public ActionResult UpdTblSubDeptMaster(TblSubDeptMaster TblSubDeptMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=TblSubDeptMaster.Id},
                new SqlParameter {ParameterName="@SubDepartment_Name",Direction =ParameterDirection.Input,Value =TblSubDeptMaster.SubDpt_Name},
                new SqlParameter {ParameterName="@Department_Id",Direction =ParameterDirection.Input,Value = TblSubDeptMaster.Dept_Id },
                new SqlParameter {ParameterName="@Plant_Id",Direction =ParameterDirection.Input,Value = TblSubDeptMaster.Plant_Id },
                new SqlParameter {ParameterName="@Company_Id",Direction =ParameterDirection.Input,Value = TblSubDeptMaster.Company_Id },
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=TblSubDeptMaster.Created_By},
            };
            _sql.postData("uspSubDept", @params);
            return Ok(TblSubDeptMaster.SubDpt_Name + " Updated");
        }
    }
}
