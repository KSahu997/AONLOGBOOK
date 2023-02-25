using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using AONLOGBOOK.SHARED.Models;
using AONLOGBOOK.API.Services;
namespace AONLogbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyMastersController : ControllerBase
    {

        private readonly SqlService _sql;
        public CompanyMastersController(SqlService _sqlS)
        {

            _sql = _sqlS;

        }

        // Get All Records
        [HttpGet]
        public ActionResult<IEnumerable<TblCompanyMaster>?> GetTblCompanyMasters()
        {
           SqlParameter[] @params = 
           { 
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ALL"}
           
           };
           return _sql.getDatas<TblCompanyMaster>("uspCompany", @params);
           
        }
        // GET: api/CompanyMasters/5
        // Get Specific Record
        [HttpGet("{id}")]
        public ActionResult<TblCompanyMaster?> GetTblCompanyMaster(Guid id)
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"},
            new SqlParameter {ParameterName="@id",Direction=ParameterDirection.Input,Value=id}

           };
            return _sql.getData<TblCompanyMaster>("uspCompany", @params);
        }
        // Get Specific Record
        [HttpGet("ACT")]
        public ActionResult<IEnumerable<TblCompanyMaster>?> ActTblCompanyMaster()
        {
            SqlParameter[] @params =
           {
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="ACT"},
           };
            return _sql.getDatas<TblCompanyMaster>("uspCompany", @params);
        }

        

        // POST: api/CompanyMasters
        // Create Operation
        [HttpPost]
        public ActionResult PostTblCompanyMaster(TblCompanyMaster tblCompanyMaster)
        {
            SqlParameter[] @params =
            { 
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@Company_Name",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Company_Name },
            new SqlParameter {ParameterName="@Attachment",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Attachment },
            new SqlParameter {ParameterName="@GST",Direction =ParameterDirection.Input,Value = tblCompanyMaster.GST_no },
            new SqlParameter {ParameterName="@Address",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Address },
            new SqlParameter {ParameterName="@Country",Direction =ParameterDirection.Input,Value =tblCompanyMaster.Country },
            new SqlParameter {ParameterName="@City",Direction =ParameterDirection.Input,Value = tblCompanyMaster.City },
            new SqlParameter {ParameterName="@State",Direction =ParameterDirection.Input,Value = tblCompanyMaster.State },
            new SqlParameter {ParameterName="@Pin",Direction =ParameterDirection.Input,Value = tblCompanyMaster.PinCode },
            new SqlParameter {ParameterName="@Phone",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Phone_no},
            new SqlParameter {ParameterName="@Email",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Email },
            new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=tblCompanyMaster.Created_By},
            };
            _sql.postData("uspCompany", @params);
            return Ok(tblCompanyMaster.Company_Name+" Created");
        }
        [HttpPost("UPD")]
        public ActionResult UpdTblCompanyMaster(TblCompanyMaster tblCompanyMaster)
        {
            SqlParameter[] @params =
            { 
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
            new SqlParameter {ParameterName="@Company_Name",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Company_Name },
            new SqlParameter {ParameterName="@id",Direction =ParameterDirection.Input,Value = tblCompanyMaster.ID },
            new SqlParameter {ParameterName="@Attachment",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Attachment },
            new SqlParameter {ParameterName="@GST",Direction =ParameterDirection.Input,Value = tblCompanyMaster.GST_no },
            new SqlParameter {ParameterName="@Address",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Address },
            new SqlParameter {ParameterName="@Country",Direction =ParameterDirection.Input,Value =tblCompanyMaster.Country },
            new SqlParameter {ParameterName="@City",Direction =ParameterDirection.Input,Value = tblCompanyMaster.City },
            new SqlParameter {ParameterName="@State",Direction =ParameterDirection.Input,Value = tblCompanyMaster.State },
            new SqlParameter {ParameterName="@Pin",Direction =ParameterDirection.Input,Value = tblCompanyMaster.PinCode },
            new SqlParameter {ParameterName="@Phone",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Phone_no},
            new SqlParameter {ParameterName="@Email",Direction =ParameterDirection.Input,Value = tblCompanyMaster.Email },
            new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=tblCompanyMaster.Created_By},
            };
            _sql.postData("uspCompany", @params);
            return Ok(tblCompanyMaster.Company_Name+" Updated");
        } 
    }
}
