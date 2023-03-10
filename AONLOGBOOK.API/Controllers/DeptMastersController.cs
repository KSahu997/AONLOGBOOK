using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AONLOGBOOK.API.Models;
using AONLOGBOOK.SHARED.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AONLogbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptMastersController : ControllerBase
    {
        private readonly DBContext _context;

        public DeptMastersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/DeptMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDeptMaster>>> GetTblDeptMasters()
        {
            return await _context.TblDeptMasters.ToListAsync();
        }

        // GET: api/DeptMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDeptMaster>> GetTblDeptMaster(int id)
        {
            var tblDeptMaster = await _context.TblDeptMasters.FindAsync(id);

            if (tblDeptMaster == null)
            {
                return NotFound();
            }

            return tblDeptMaster;
        }

        // PUT: api/DeptMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDeptMaster(Guid id, TblDeptMaster tblDeptMaster)
        {
            if (id != tblDeptMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblDeptMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDeptMasterExists(id))
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

        // POST: api/DeptMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTblDeptMaster(TblDeptMaster tblDeptMaster)
        {
            string sqlQuery = "EXEC [dbo].[sp_Department_Master] @Type,@Department_Name ,@Plant_Id ,@Company_ID ,@By ,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@Department_Name",Direction =ParameterDirection.Input,Value = tblDeptMaster.DeptName },
            new SqlParameter {ParameterName="@Plant_Id",Direction =ParameterDirection.Input,Value = (object)tblDeptMaster.PlantId??DBNull.Value },
            new SqlParameter {ParameterName="@Company_ID",Direction =ParameterDirection.Input,Value = (object)tblDeptMaster.CompanyId??DBNull.Value },
            new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=(object)tblDeptMaster.CreatedBy??DBNull.Value},
            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[5].Value);
        }

        // DELETE: api/DeptMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDeptMaster(int id)
        {
            var tblDeptMaster = await _context.TblDeptMasters.FindAsync(id);
            if (tblDeptMaster == null)
            {
                return NotFound();
            }

            _context.TblDeptMasters.Remove(tblDeptMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblDeptMasterExists(Guid id)
        {
            return _context.TblDeptMasters.Any(e => e.Id == id);
        }
    }
}
