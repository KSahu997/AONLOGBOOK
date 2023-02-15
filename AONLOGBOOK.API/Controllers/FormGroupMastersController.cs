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
    public class FormGroupMastersController : ControllerBase
    {
        private readonly DBContext _context;

        public FormGroupMastersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/FormGroupMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblFormGroupMaster>>> GetTblFormGroupMasters()
        {
            return await _context.TblFormGroupMasters.ToListAsync();
        }

        // GET: api/FormGroupMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblFormGroupMaster>> GetTblFormGroupMaster(Guid id)
        {
            var tblFormGroupMaster = await _context.TblFormGroupMasters.FindAsync(id);

            if (tblFormGroupMaster == null)
            {
                return NotFound();
            }

            return tblFormGroupMaster;
        }

        // PUT: api/FormGroupMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFormGroupMaster(Guid id, TblFormGroupMaster tblFormGroupMaster)
        {
            if (id != tblFormGroupMaster.FormGroupId)
            {
                return BadRequest();
            }

            _context.Entry(tblFormGroupMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFormGroupMasterExists(id))
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

        // POST: api/FormGroupMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblFormGroupMaster>> PostTblFormGroupMaster(TblFormGroupMaster tblFormGroupMaster)
        //{
        //    _context.TblFormGroupMasters.Add(tblFormGroupMaster);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTblFormGroupMaster", new { id = tblFormGroupMaster.FormGroupId }, tblFormGroupMaster);
        //}



        [HttpPost]
        public async Task<ActionResult> PostTblFormGroupMaster(TblFormGroupMaster tblFormGroupMaster)
        {
            string sqlQuery = "EXEC [dbo].[sp_FormGroupMaster] @Type,@PlantCode ,@DeptCode ,@SubDeptCode,@FormGroup,@Role,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@PlantCode",Direction =ParameterDirection.Input,Value = tblFormGroupMaster.Plant},
            new SqlParameter {ParameterName="@DeptCode",Direction =ParameterDirection.Input,Value = tblFormGroupMaster.Dept},
            new SqlParameter {ParameterName="@SubDeptCode",Direction =ParameterDirection.Input,Value = tblFormGroupMaster.SubDept},

            new SqlParameter {ParameterName="@FormGroup",Direction=ParameterDirection.Input,Value=tblFormGroupMaster.FormGroup},
            new SqlParameter {ParameterName="@Role",Direction=ParameterDirection.Input,Value=tblFormGroupMaster.Role},

            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[6].Value);
        }

        // DELETE: api/FormGroupMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblFormGroupMaster(Guid id)
        {
            var tblFormGroupMaster = await _context.TblFormGroupMasters.FindAsync(id);
            if (tblFormGroupMaster == null)
            {
                return NotFound();
            }

            _context.TblFormGroupMasters.Remove(tblFormGroupMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblFormGroupMasterExists(Guid id)
        {
            return _context.TblFormGroupMasters.Any(e => e.FormGroupId == id);
        }
    }
}
