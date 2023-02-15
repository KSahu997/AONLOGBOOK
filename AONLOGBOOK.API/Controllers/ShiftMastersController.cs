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
    public class ShiftMastersController : ControllerBase
    {
        private readonly DBContext _context;

        public ShiftMastersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/ShiftMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblShiftMaster>>> GetTblShiftMasters()
        {
            return await _context.TblShiftMasters.ToListAsync();
        }

        // GET: api/ShiftMasters/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblShiftMaster>> GetTblShiftMaster(Guid id)
        //{
        //    var tblShiftMaster = await _context.TblShiftMasters.FindAsync(id);

        //    if (tblShiftMaster == null)
        //    {
        //        return NotFound();
        //    }

        //  return tblShiftMaster;
        //}
        [HttpGet("{Company_Id}/{Shift_time}")]
        public async Task<IEnumerable<TblShiftMaster>> GetTblShiftMasterByCompanyID(Guid Company_Id, DateTime Shift_time)
        {

            return await _context.TblShiftMasters.FromSqlRaw("SP_GetShiftList'" + Company_Id + "','"+Shift_time.ToString("MM-dd-yyyy HH:mm:ss")+"'").ToListAsync();



        }

        // PUT: api/ShiftMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblShiftMaster(Guid id, TblShiftMaster tblShiftMaster)
        {
            if (id != tblShiftMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblShiftMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblShiftMasterExists(id))
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

        // POST: api/ShiftMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTblShiftMaster(TblShiftMaster tblshiftmaster)
        {
            try
            {
                string sqlQuery = "EXEC[dbo].[Sp_Shift_Master]@Type,@Company_Id,@Shift_prefix,@Shift_hour,@Shift_start";
                //string sqlQuery = "EXEC[dbo].[Sp_Shift_Master]@Type,@Company_Id,@Shift_prefix,@Shift_hour";
                SqlParameter[] @params =
                { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@Company_Id",Direction =ParameterDirection.Input,Value = (object)tblshiftmaster.CompanyId??DBNull.Value },
            new SqlParameter {ParameterName="@Shift_start",Direction =ParameterDirection.Input,Value = (object)tblshiftmaster.ShiftStart??DBNull.Value},
            //new SqlParameter {ParameterName="@Shift_start",Direction =ParameterDirection.Input,Value = (object)new DateTime(tblshiftmaster.ShiftStart.Value.Ticks).ToString("HHmmss")??DBNull.Value},
            new SqlParameter {ParameterName="@Shift_prefix",Direction =ParameterDirection.Input,Value = (object)tblshiftmaster.ShiftPrefix??DBNull.Value },
            new SqlParameter {ParameterName="@Shift_hour",Direction =ParameterDirection.Input,Value = (object)tblshiftmaster.Shifthour??DBNull.Value }
            };
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
                return Ok(@params[3].Value);
            }catch(Exception ex)
            {
                return BadRequest();
            }
           
        }
        [HttpPost("upd")]
        public async Task<ActionResult> PostTblShiftMasterEdit(TblShiftMaster tblshiftmaster)
        {
            try
            {
                string sqlQuery = "EXEC[dbo].[Sp_Shift_Master_UPD]@Type,@Shift_prefix,@Id";
                SqlParameter[] @params =
                { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="UPD"},
            new SqlParameter {ParameterName="@Id",Direction =ParameterDirection.Input,Value = (object)tblshiftmaster.Id??DBNull.Value },
            new SqlParameter {ParameterName="@Shift_prefix",Direction =ParameterDirection.Input,Value = (object)tblshiftmaster.ShiftPrefix??DBNull.Value }
            };
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
                return Ok(@params[2].Value);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpPost("del")]
        public async Task<ActionResult> PostTblShiftMasterDel(TblShiftMaster tblshiftmaster)
        {
            
                string sqlQuery = "EXEC[dbo].[Sp_Shift_Master_Del]@Delf,@Id";
                SqlParameter[] @params =
                { 
            // Create parameters    
            new SqlParameter {ParameterName="@Id",Direction =ParameterDirection.Input,Value = (object)tblshiftmaster.Id??DBNull.Value },
            new SqlParameter {ParameterName="@Delf",Direction =ParameterDirection.Input,Value = (object)tblshiftmaster.Delflag??DBNull.Value }
            };
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
                return Ok("Data Successfully Deleted");
            
            

        }
        // DELETE: api/ShiftMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblShiftMaster(Guid id)
        {
            var tblShiftMaster = await _context.TblShiftMasters.FindAsync(id);
            if (tblShiftMaster == null)
            {
                return NotFound();
            }

            _context.TblShiftMasters.Remove(tblShiftMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblShiftMasterExists(Guid id)
        {
            return _context.TblShiftMasters.Any(e => e.Id == id);
        }
    }
}
