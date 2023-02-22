using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AONLOGBOOK.API.Models;
using AONLOGBOOK.SHARED.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace AONLOGBOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly DBContext _context;

        public LookupsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Lookups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLookup>>> GetTblLookups()
        {
            return await _context.TblLookups.ToListAsync();
        }

        // GET: api/Lookups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLookup>> GetTblLookup(Guid id)
        {
            var tblLookup = await _context.TblLookups.FindAsync(id);

            if (tblLookup == null)
            {
                return NotFound();
            }

            return tblLookup;
        }

        // PUT: api/Lookups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLookup(Guid id, TblLookup tblLookup)
        {
            if (id != tblLookup.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLookup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLookupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Lookups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTblLookup(TblLookup tblLookup)
        {
            string sqlQuery = "EXEC [dbo].[SP_Lookup]@Name,@CompanyID,@PlantID,@User,@ID,@Type";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Name",Direction=ParameterDirection.Input,Value=(object)tblLookup.Name??DBNull.Value},
            new SqlParameter {ParameterName="@CompanyID",Direction=ParameterDirection.Input,Value=(object)tblLookup.CompanyId??DBNull.Value},
            new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value =(object)tblLookup.PlantId??DBNull.Value},
            new SqlParameter {ParameterName="@User",Direction =ParameterDirection.Input,Value =(object)tblLookup.CreatedBy??DBNull.Value},
            new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value =(object)tblLookup.Id??DBNull.Value},
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[0].Value);
        }
        [HttpPost("upd")]
        public async Task<ActionResult> PostTblLookupbyID(TblLookup tblLookup)
        {
            string sqlQuery = "EXEC [dbo].[SP_Lookup]@Name,@CompanyID,@PlantID,@User,@ID,@Type";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Name",Direction=ParameterDirection.Input,Value=(object)tblLookup.Name??DBNull.Value},
            new SqlParameter {ParameterName="@CompanyID",Direction=ParameterDirection.Input,Value=(object)tblLookup.CompanyId??DBNull.Value},
            new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value =(object)tblLookup.PlantId??DBNull.Value},
            new SqlParameter {ParameterName="@User",Direction =ParameterDirection.Input,Value =(object)tblLookup.CreatedBy??DBNull.Value},
            new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value =(object)tblLookup.Id??DBNull.Value},
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[0].Value);
        }
        [HttpPost("del")]
        public async Task<ActionResult> PostTblLookupbyId(TblLookup tblLookup)
        {
            string sqlQuery = "EXEC [dbo].[SP_Lookup]@Name,@CompanyID,@PlantID,@User,@ID,@Type";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Name",Direction=ParameterDirection.Input,Value=(object)tblLookup.Name??DBNull.Value},
            new SqlParameter {ParameterName="@CompanyID",Direction=ParameterDirection.Input,Value=(object)tblLookup.CompanyId??DBNull.Value},
            new SqlParameter {ParameterName="@PlantID",Direction =ParameterDirection.Input,Value =(object)tblLookup.PlantId??DBNull.Value},
            new SqlParameter {ParameterName="@User",Direction =ParameterDirection.Input,Value =(object)tblLookup.CreatedBy??DBNull.Value},
            new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value =(object)tblLookup.Id??DBNull.Value},
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="DEL"}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[0].Value);
        }
        // DELETE: api/Lookups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLookup(Guid id)
        {
            var tblLookup = await _context.TblLookups.FindAsync(id);
            if (tblLookup == null)
            {
                return NotFound();
            }

            _context.TblLookups.Remove(tblLookup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLookupExists(Guid id)
        {
            return _context.TblLookups.Any(e => e.Id == id);
        }
    }
}
