using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AONLOGBOOK.API.Models;
using AONLOGBOOK.SHARED.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AONLOGBOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupParamsController : ControllerBase
    {
        private readonly DBContext _context;

        public LookupParamsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/LookupParams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLookupParam>>> GetTblLookupParams()
        {
            return await _context.TblLookupParams.ToListAsync();
        }

        // GET: api/LookupParams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLookupParam>> GetTblLookupParam(Guid id)
        {
            var tblLookupParam = await _context.TblLookupParams.FindAsync(id);

            if (tblLookupParam == null)
            {
                return NotFound();
            }

            return tblLookupParam;
        }

        // PUT: api/LookupParams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLookupParam(Guid id, TblLookupParam tblLookupParam)
        {
            if (id != tblLookupParam.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLookupParam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLookupParamExists(id))
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

        // POST: api/LookupParams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTblLookupParam(TblLookupParam tblLookupParam)
        {
            string sqlQuery = "EXEC [dbo].[SP_Lookup_Param]@CompanyID,@PlantID,@User,@ID,@Type,@Param";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@CompanyID",Direction=ParameterDirection.Input,Value=(object)tblLookupParam.CompanyId??DBNull.Value},
            new SqlParameter {ParameterName="@PlantID",Direction=ParameterDirection.Input,Value=(object)tblLookupParam.PlantId??DBNull.Value},
            new SqlParameter {ParameterName="@User",Direction =ParameterDirection.Input,Value =(object)tblLookupParam.CreatedBy??DBNull.Value},
            new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value =(object)tblLookupParam.Id??DBNull.Value},
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@Param",Direction =ParameterDirection.Input,Value =(object)tblLookupParam.Param??DBNull.Value}            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[5].Value);
        }

        // DELETE: api/LookupParams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLookupParam(Guid id)
        {
            var tblLookupParam = await _context.TblLookupParams.FindAsync(id);
            if (tblLookupParam == null)
            {
                return NotFound();
            }

            _context.TblLookupParams.Remove(tblLookupParam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLookupParamExists(Guid id)
        {
            return _context.TblLookupParams.Any(e => e.Id == id);
        }
    }
}
