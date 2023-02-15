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
    public class LogbookMastersController : ControllerBase
    {
        private readonly DBContext _context;

        public LogbookMastersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/LogbookMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLogbookMaster>>> GetTblLogbookMasters()
        {
            return await _context.TblLogbookMasters.ToListAsync();
        }

        // GET: api/LogbookMasters/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblLogbookMaster>> GetTblLogbookMaster(Guid id)
        //{
        //    var tblLogbookMaster = await _context.TblLogbookMasters.FindAsync(id);

        //    if (tblLogbookMaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblLogbookMaster;
        //}


        [HttpGet("{SubDept}")]
        public async Task<IEnumerable<TblLogbookMaster>> GetTblLogbookMaster(Guid SubDept)
        {
            return await _context.TblLogbookMasters.FromSqlRaw("sp_LogbookMaster'"+ SubDept + "'").ToListAsync();
        }

        // PUT: api/LogbookMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLogbookMaster(Guid id, TblLogbookMaster tblLogbookMaster)
        {
            if (id != tblLogbookMaster.LogbookId)
            {
                return BadRequest();
            }

            _context.Entry(tblLogbookMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLogbookMasterExists(id))
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

        // POST: api/LogbookMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblLogbookMaster>> PostTblLogbookMaster(TblLogbookMaster tblLogbookMaster)
        //{
        //    _context.TblLogbookMasters.Add(tblLogbookMaster);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTblLogbookMaster", new { id = tblLogbookMaster.LogbookId }, tblLogbookMaster);
        //}


        [HttpPost]
        public async Task<ActionResult> PostTblLogbookMaster(TblLogbookMaster tblLogbookMaster)
        {
            string sqlQuery = "EXEC [dbo].[sp_LogBookMasterEntry] @Type,@Department,@SubDept,@LogbookName,@Company_Id,@Prefix,@PlantCode,@Sequence,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@Department",Direction =ParameterDirection.Input,Value =(object) tblLogbookMaster.Department??DBNull.Value},
            new SqlParameter {ParameterName="@SubDept",Direction =ParameterDirection.Input,Value = (object) tblLogbookMaster.SubDepartment??DBNull.Value},
            new SqlParameter {ParameterName="@LogbookName",Direction =ParameterDirection.Input,Value = (object) tblLogbookMaster.LogbookName ?? DBNull.Value},
            new SqlParameter {ParameterName="@Company_Id",Direction =ParameterDirection.Input,Value = (object) tblLogbookMaster.CompanyId ?? DBNull.Value},
           
            new SqlParameter {ParameterName="@Prefix",Direction =ParameterDirection.Input,Value = (object) tblLogbookMaster.Prefix ?? DBNull.Value},
            new SqlParameter {ParameterName="@PlantCode",Direction =ParameterDirection.Input,Value = (object) tblLogbookMaster.PlantCode ?? DBNull.Value},
            new SqlParameter {ParameterName="@Sequence",Direction =ParameterDirection.Input,Value = (object) tblLogbookMaster.Seq ?? DBNull.Value},
            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[8].Value);
        }

        // DELETE: api/LogbookMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLogbookMaster(Guid id)
        {
            var tblLogbookMaster = await _context.TblLogbookMasters.FindAsync(id);
            if (tblLogbookMaster == null)
            {
                return NotFound();
            }

            _context.TblLogbookMasters.Remove(tblLogbookMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLogbookMasterExists(Guid id)
        {
            return _context.TblLogbookMasters.Any(e => e.LogbookId == id);
        }
    }
}
