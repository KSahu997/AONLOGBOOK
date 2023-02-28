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
    public class DeptMastersController : ControllerBase
    {
        private readonly SqlService _sql;
        public DeptMastersController(SqlService _sqlS)
        {
            _sql = _sqlS;
        }

        // Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblDeptMaster>?> GetTblDeptMasters()
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}

           };
            return _sql.getDatas<TblDeptMaster>("uspDepartment", @params);

        }
        // GET: api/DeptMasters/5
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblDeptMaster?> GetTblDeptMaster(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblDeptMaster>("uspDepartment", @params);
        }
        // Get Specific Record
        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblDeptMaster>?> ActTblDeptMaster()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblDeptMaster>("uspDepartment", @params);
        }



        // POST: api/DeptMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblDeptMaster(TblDeptMaster TblDeptMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="@Department_Name",Direction =ParameterDirection.Input,Value = TblDeptMaster.Dept_Name },
                new SqlParameter {ParameterName="@Plant_Id",Direction =ParameterDirection.Input,Value = TblDeptMaster.Plant_Id },
                new SqlParameter {ParameterName="@Company_ID",Direction =ParameterDirection.Input,Value = TblDeptMaster.Company_Id },
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=TblDeptMaster.Created_By},
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=TblDeptMaster.Created_By},
            };
            _sql.postData("uspDepartment", @params);
            return Ok(TblDeptMaster.Dept_Name + " Created"); ;
        }
        [HttpPost("UPD")]
        public ActionResult UpdTblDeptMaster(TblDeptMaster TblDeptMaster)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=TblDeptMaster.Id},
                new SqlParameter {ParameterName="@Department_Name",Direction =ParameterDirection.Input,Value = TblDeptMaster.Dept_Name },
                new SqlParameter {ParameterName="@Plant_Id",Direction =ParameterDirection.Input,Value = TblDeptMaster.Plant_Id },
                new SqlParameter {ParameterName="@Company_ID",Direction =ParameterDirection.Input,Value = TblDeptMaster.Company_Id },
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=TblDeptMaster.Created_By},
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=TblDeptMaster.Created_By},
            };
            _sql.postData("uspDepartment", @params);
            return Ok(TblDeptMaster.Dept_Name + " Updated");
        }
    }
}
