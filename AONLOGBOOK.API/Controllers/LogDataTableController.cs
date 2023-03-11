using AONLOGBOOK.API.Services;
using AONLOGBOOK.SHARED.CModels;
using AONLOGBOOK.SHARED.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AONLOGBOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogDataTableController : ControllerBase
    {
        private readonly SqlService _sql;
        public LogDataTableController(SqlService _sqlS)
        {

            _sql = _sqlS;

        }

        // Get All Records
        [HttpGet("{logbookid}/{dt}")]
        public ActionResult<DataTable?> GetTblLogDataTableMasters(string logbookid, DateTime dt)
        {
            SqlParameter[] @params =
            {
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="DAT"},
                new SqlParameter {ParameterName="@LogbookId",Direction=ParameterDirection.Input,Value=logbookid},
                new SqlParameter {ParameterName="@DateTime",Direction=ParameterDirection.Input,Value=dt},
            };
            return _sql.getDataAsDataTable("uspLogDataTable", @params);

        }
        // GET: api/CompanyMasters/5
        // Get Specific Record
        //[HttpGet("{id}")]
        //public ActionResult<TblLogBookDataTable?> GetTblLogDataTableMasters(Guid id)
        //{
        //    SqlParameter[] @params =
        //    {
        //    new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"},
        //    new SqlParameter {ParameterName="@LogBookID",Direction=ParameterDirection.Input,Value=id},


        //    };
        //    return _sql.getData<TblCompanyMaster>("uspLogDataTable", @params);
        //}

        // POST: api/CompanyMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblLogDataTableMasters(LogDataList logdt)
        {
            SqlParameter[] @params =
            {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
             new SqlParameter {ParameterName="@data",Direction=ParameterDirection.Input,Value=_sql.ToDataTable<LogData>(logdt.TblLog),SqlDbType=SqlDbType.Structured,TypeName="dbo.PostDynamicData"},
            new SqlParameter {ParameterName="@Company",Direction =ParameterDirection.Input,Value =logdt.TblLogHead.CompanyId},
            new SqlParameter {ParameterName="@Plant",Direction =ParameterDirection.Input,Value =logdt.TblLogHead.PlantId},
            new SqlParameter {ParameterName="@DeptId",Direction =ParameterDirection.Input,Value =logdt.TblLogHead.DeptId },
            new SqlParameter {ParameterName="@subDeptId",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.SubDeptId},
            new SqlParameter {ParameterName="@CreatedBy",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.CreatedBy},
            new SqlParameter {ParameterName="@DateTime",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.date},
            new SqlParameter {ParameterName="@Shift",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.Shift},
            new SqlParameter{ParameterName="@MarkforDeletion",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.StatusF},
            new SqlParameter {ParameterName="@LogbookId",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.LogbookId}
            };
            _sql.postData("uspLogDataTable", @params);
            return Ok("Record Inserted");
        }
        //[HttpPost("UPD")]
        //public ActionResult UpdTblCompanyMaster(TblCompanyMaster tblCompanyMaster)
        //{
        //    SqlParameter[] @params =
        //    {
        //    new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
        //    new SqlParameter {ParameterName="@Company_Name",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Company_Name },
        //    new SqlParameter {ParameterName="@id",Direction =ParameterDirection.Input,Value = tblCompanyMaster.ID },
        //    new SqlParameter {ParameterName="@Attachment",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Attachment },
        //    new SqlParameter {ParameterName="@GST",Direction =ParameterDirection.Input,Value = tblCompanyMaster.GST_no },
        //    new SqlParameter {ParameterName="@Address",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Address },
        //    new SqlParameter {ParameterName="@Country",Direction =ParameterDirection.Input,Value =tblCompanyMaster.Country },
        //    new SqlParameter {ParameterName="@City",Direction =ParameterDirection.Input,Value = tblCompanyMaster.City },
        //    new SqlParameter {ParameterName="@State",Direction =ParameterDirection.Input,Value = tblCompanyMaster.State },
        //    new SqlParameter {ParameterName="@Pin",Direction =ParameterDirection.Input,Value = tblCompanyMaster.PinCode },
        //    new SqlParameter {ParameterName="@Phone",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Phone_no},
        //    new SqlParameter {ParameterName="@Email",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Email },
        //    new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=tblCompanyMaster.Created_By},
        //    };
        //    _sql.postData("uspCompany", @params);
        //    return Ok(tblCompanyMaster.Company_Name + " Updated");
        //}
    }
}
