using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using AONLOGBOOK.API.Models;
using System;
using AONLOGBOOK.SHARED.Models;

namespace AONLogbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyMastersController : ControllerBase
    {
        private readonly DBContext _context;

        public CompanyMastersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/CompanyMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCompanyMaster>>> GetTblCompanyMasters()
        {
            return await _context.TblCompanyMasters.ToListAsync();
        }

        // GET: api/CompanyMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCompanyMaster>> GetTblCompanyMaster(Guid id)
        {
            var tblCompanyMaster = await _context.TblCompanyMasters.FindAsync(id);

            if (tblCompanyMaster == null)
            {
                return NotFound();
            }

            return tblCompanyMaster;
        }

        // PUT: api/CompanyMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult> PutTblCompanyMaster(TblCompanyMaster tblCompanyMaster)
        {
            string sqlQuery = "EXEC [dbo].[sp_Company_Master] @Type,@id, @Company_Name,@By,@message=@message OUT ";
            SqlParameter[] @params =
            { 
                // Create parameters    
                new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
                new SqlParameter {ParameterName="@id",SqlDbType=SqlDbType.UniqueIdentifier, Direction=ParameterDirection.Input,Value=tblCompanyMaster.Id},
                new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=tblCompanyMaster.CreatedBy},
                new SqlParameter {ParameterName="@Company_Name",Direction =ParameterDirection.Input,Value = tblCompanyMaster.CompanyName },
                new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
                };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[3].Value);
        }

        // POST: api/CompanyMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTblCompanyMaster(TblCompanyMaster tblCompanyMaster)
        {
            
                string sqlQuery = "EXEC[dbo].[sp_Company_Master]@Type,@Company_Name,@Attachment,@GST,@Address,@Country,@City,@State,@Pin,@Phone,@Email,@By,@message=@message OUT";
                SqlParameter[] @params =
                { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@Company_Name",Direction =ParameterDirection.Input,Value = tblCompanyMaster.CompanyName },
            new SqlParameter {ParameterName="@Attachment",Direction =ParameterDirection.Input,Value = (object)tblCompanyMaster.Attachment??DBNull.Value },
            new SqlParameter {ParameterName="@GST",Direction =ParameterDirection.Input,Value = (object)tblCompanyMaster.GstNo??DBNull.Value },
            new SqlParameter {ParameterName="@Address",Direction =ParameterDirection.Input,Value = (object)tblCompanyMaster.Address??DBNull.Value },
            new SqlParameter {ParameterName="@Country",Direction =ParameterDirection.Input,Value =(object)tblCompanyMaster.Country??DBNull.Value },
            new SqlParameter {ParameterName="@City",Direction =ParameterDirection.Input,Value = (object)tblCompanyMaster.City??DBNull.Value },
            new SqlParameter {ParameterName="@State",Direction =ParameterDirection.Input,Value = (object)tblCompanyMaster.State??DBNull.Value },
            new SqlParameter {ParameterName="@Pin",Direction =ParameterDirection.Input,Value = (object)tblCompanyMaster.PinCode??DBNull.Value },
            new SqlParameter {ParameterName="@Phone",Direction =ParameterDirection.Input,Value = (object)tblCompanyMaster.PhoneNo??DBNull.Value},
            new SqlParameter {ParameterName="@Email",Direction =ParameterDirection.Input,Value = (object)tblCompanyMaster.Email??DBNull.Value },
            new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=(object)tblCompanyMaster.CreatedBy??DBNull.Value},
            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
                return Ok(@params[12].Value);
        }

        // DELETE: api/CompanyMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCompanyMaster(int id)
        {
            var tblCompanyMaster = await _context.TblCompanyMasters.FindAsync(id);
            if (tblCompanyMaster == null)
            {
                return NotFound();
            }

            _context.TblCompanyMasters.Remove(tblCompanyMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCompanyMasterExists(Guid id)
        {
            return _context.TblCompanyMasters.Any(e => e.Id == id);
        }
    }
}
