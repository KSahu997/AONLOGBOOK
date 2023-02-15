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
    public class TagMastersController : ControllerBase
    {
        private readonly DBContext _context;

        public TagMastersController(DBContext context)
        {
            _context = context;
        }

       // GET: api/TagMasters
       [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTagMaster>>> GetTblTagMasters()
        {
            return await _context.TblTagMasters.ToListAsync();
        }



        // GET: api/TagMasters/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblTagMaster>> GetTblTagMaster(string id)
        //{
        //    var tblTagMaster = await _context.TblTagMasters.FindAsync(id);

        //    if (tblTagMaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblTagMaster;
        //}


        [HttpGet("{id}")]
        public async Task<IEnumerable<TblTagMaster>> GetTblTagMasterById(long id)
        {
           
            return await _context.TblTagMasters.FromSqlRaw("sp_tagMaster @Id="+id).ToListAsync();
            
        }

        // PUT: api/TagMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTagMaster(string id, TblTagMaster tblTagMaster)
        {
            if (id != tblTagMaster.TagName)
            {
                return BadRequest();
            }

            _context.Entry(tblTagMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTagMasterExists(id))
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

        // POST: api/TagMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblTagMaster>> PostTblTagMaster(TblTagMaster tblTagMaster)
        //{
        //    _context.TblTagMasters.Add(tblTagMaster);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (TblTagMasterExists(tblTagMaster.TagName))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetTblTagMaster", new { id = tblTagMaster.TagName }, tblTagMaster);
        //}

        [HttpPost]
        public async Task<ActionResult> PostTblTagMaster(TblTagMaster tblTagMaster)
        {
            string sqlQuery = "EXEC [dbo].[sp_tagMaster] @Type,@Id,@tagname,@display ,@uom,@desc,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@Id",Direction=ParameterDirection.Input,Value=(object)tblTagMaster.Id??DBNull.Value},
            new SqlParameter {ParameterName="@tagname",Direction =ParameterDirection.Input,Value =(object)tblTagMaster.TagName??DBNull.Value},
            new SqlParameter {ParameterName="@display",Direction =ParameterDirection.Input,Value = (object)tblTagMaster.DisplayName??DBNull.Value},
            new SqlParameter {ParameterName="@uom",Direction =ParameterDirection.Input,Value = (object)tblTagMaster.Uom??DBNull.Value},

            new SqlParameter {ParameterName="@desc",Direction =ParameterDirection.Input,Value = (object)tblTagMaster.Description??DBNull.Value},

            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[6].Value);
        }

        // DELETE: api/TagMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTagMaster(string id)
        {
            var tblTagMaster = await _context.TblTagMasters.FindAsync(id);
            if (tblTagMaster == null)
            {
                return NotFound();
            }

            _context.TblTagMasters.Remove(tblTagMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblTagMasterExists(string id)
        {
            return _context.TblTagMasters.Any(e => e.TagName == id);
        }
    }
}
