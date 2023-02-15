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
    public class FormMastersController : ControllerBase
    {
        private readonly DBContext _context;

        public FormMastersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/FormMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblFormMaster>>> GetTblFormMasters()
        {
            return await _context.TblFormMasters.ToListAsync();
        }

        //// GET: api/FormMasters/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblFormMaster>> GetTblFormMaster(Guid id)
        //{
        //    var tblFormMaster = await _context.TblFormMasters.FindAsync(id);

        //    if (tblFormMaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblFormMaster;
        //}

        [HttpGet("{FormGroupId}")]
        public async Task<IEnumerable<TblFormMaster>> GetTblFormMaster(Guid FormGroupId)
        {
            return await _context.TblFormMasters.FromSqlRaw("sp_ListForms'" + FormGroupId + "'").ToListAsync();
            
        }

        // PUT: api/FormMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFormMaster(Guid id, TblFormMaster tblFormMaster)
        {
            if (id != tblFormMaster.FormId)
            {
                return BadRequest();
            }

            _context.Entry(tblFormMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFormMasterExists(id))
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

        // POST: api/FormMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblFormMaster>> PostTblFormMaster(TblFormMaster tblFormMaster)
        //{
        //    _context.TblFormMasters.Add(tblFormMaster);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTblFormMaster", new { id = tblFormMaster.FormId }, tblFormMaster);
        //}


        [HttpPost]
        public async Task<ActionResult> PostTblFormMaster(TblFormMaster tblFormMaster)
        {
            string sqlQuery = "EXEC [dbo].[sp_FormMaster] @Type,@FormGroup ,@FormName ,@Sequence,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@FormGroup",Direction =ParameterDirection.Input,Value = tblFormMaster.FormGroup},
            new SqlParameter {ParameterName="@FormName",Direction =ParameterDirection.Input,Value = tblFormMaster.FormName},
            new SqlParameter {ParameterName="@Sequence",Direction =ParameterDirection.Input,Value = tblFormMaster.Seq},
            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[4].Value);
        }

        // DELETE: api/FormMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblFormMaster(Guid id)
        {
            var tblFormMaster = await _context.TblFormMasters.FindAsync(id);
            if (tblFormMaster == null)
            {
                return NotFound();
            }

            _context.TblFormMasters.Remove(tblFormMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblFormMasterExists(Guid id)
        {
            return _context.TblFormMasters.Any(e => e.FormId == id);
        }
    }
}
