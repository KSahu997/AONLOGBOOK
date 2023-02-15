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
    public class SubDeptMastersController : ControllerBase
    {
        private readonly DBContext _context;

        public SubDeptMastersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/SubDeptMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSubDeptMaster>>> GetTblSubDeptMasters()
        {
            return await _context.TblSubDeptMasters.ToListAsync();
        }

        // GET: api/SubDeptMasters/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblSubDeptMaster>> GetTblSubDeptMaster(Guid id)
        //{
        //    var tblSubDeptMaster = await _context.TblSubDeptMasters.FindAsync(id);

        //    if (tblSubDeptMaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblSubDeptMaster;
        //}
        [HttpGet("{Dept}")]
         public async Task<IEnumerable<TblSubDeptMaster>> GetTblSubDeptMaster(Guid Dept)
        {

            return await _context.TblSubDeptMasters.FromSqlRaw("sp_ListSubDept'" + Dept + "'").ToListAsync();
           
         }
        // PUT: api/SubDeptMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSubDeptMaster(Guid id, TblSubDeptMaster tblSubDeptMaster)
        {
            if (id != tblSubDeptMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblSubDeptMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSubDeptMasterExists(id))
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

        // POST: api/SubDeptMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSubDeptMaster>> PostTblSubDeptMaster(TblSubDeptMaster tblSubDeptMaster)
        {
            string sqlQuery = "EXEC [dbo].[sp_SubDepartment_Master] @Type,@SubDepartment_Name ,@Department_Id ,@Plant_Id,@Company_Id,@By ,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@SubDepartment_Name",Direction =ParameterDirection.Input,Value =tblSubDeptMaster.SubDptName},
            new SqlParameter {ParameterName="@Department_Id",Direction =ParameterDirection.Input,Value = (object)tblSubDeptMaster.DeptId??DBNull.Value },
            new SqlParameter {ParameterName="@Plant_Id",Direction =ParameterDirection.Input,Value = (object)tblSubDeptMaster.PlantId??DBNull.Value },
            new SqlParameter {ParameterName="@Company_Id",Direction =ParameterDirection.Input,Value = (object)tblSubDeptMaster.CompanyId??DBNull.Value },
            new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=(object)tblSubDeptMaster.CreatedBy??DBNull.Value},
            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[6].Value);
        }

        // DELETE: api/SubDeptMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSubDeptMaster(int id)
        {
            var tblSubDeptMaster = await _context.TblSubDeptMasters.FindAsync(id);
            if (tblSubDeptMaster == null)
            {
                return NotFound();
            }

            _context.TblSubDeptMasters.Remove(tblSubDeptMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSubDeptMasterExists(Guid id)
        {
            return _context.TblSubDeptMasters.Any(e => e.Id == id);
        }
    }
}
