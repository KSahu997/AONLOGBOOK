using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AONLOGBOOK.API.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using AONLOGBOOK.SHARED.Models;

namespace AONLogbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UommastersController : ControllerBase
    {
        private readonly DBContext _context;

        public UommastersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Uommasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUommaster>>> GetTblUommasters()
        {
            return await _context.TblUommasters.ToListAsync();
        }

        // GET: api/Uommasters/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<TblUommaster>> GetTblUommaster(Guid id)
        {
            return await _context.TblUommasters.FromSqlRaw("sp_UOMmaster @Id=" + id).ToListAsync();
        }

        // PUT: api/Uommasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUommaster(Guid id, TblUommaster tblUommaster)
        {
            if (id != tblUommaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUommaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUommasterExists(id))
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

        // POST: api/Uommasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblUommaster>> PostTblUommaster(TblUommaster tblUommaster)
        //{
        //    _context.TblUommasters.Add(tblUommaster);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTblUommaster", new { id = tblUommaster.Id }, tblUommaster);
        //}

        [HttpPost]
        public async Task<ActionResult> PostTblUommaster(TblUommaster tblUommaster)
        {
            string sqlQuery = "EXEC [dbo].[sp_UOMmaster] @Id, @Type,@unit ,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Id",Direction=ParameterDirection.Input,Value=(object)tblUommaster.Id??DBNull.Value},
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@unit",Direction =ParameterDirection.Input,Value = (object)tblUommaster.Unit??DBNull.Value},
            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[3].Value);
        }


        // DELETE: api/Uommasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUommaster(long id)
        {
            var tblUommaster = await _context.TblUommasters.FindAsync(id);
            if (tblUommaster == null)
            {
                return NotFound();
            }

            _context.TblUommasters.Remove(tblUommaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblUommasterExists(Guid id)
        {
            return _context.TblUommasters.Any(e => e.Id == id);
        }
    }
}
