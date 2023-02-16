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
using AONLOGBOOK.SHARED.CModels;

namespace AONLogbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogBookDataTablesController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly CustomContext _ccontext;

        public LogBookDataTablesController(DBContext context, CustomContext ccontext)
        {
            _context = context;
            _ccontext = ccontext;
        }

        // GET: api/LogBookDataTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLogBookDataTable>>> GetTblLogBookDataTables()
        {
            return await _context.TblLogBookDataTables.ToListAsync();
        }

        // GET: api/LogBookDataTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLogBookDataTable>> GetTblLogBookDataTable(Guid id)
        {
            var tblLogBookDataTable = await _context.TblLogBookDataTables.FindAsync(id);

            if (tblLogBookDataTable == null)
            {
                return NotFound();
            }

            return tblLogBookDataTable;
        }
        [HttpGet("{Logbook_Id}/{date}")]
        public async Task<IEnumerable<LogDataReport>> GetTblLogBookDataTableByIds(string Logbook_Id, DateTime date)
        {

            return await _ccontext.TblLogDataReports.FromSqlRaw("SPLogDataReport'" + Logbook_Id + "','" + date.ToString("yyyy-MM-dd HH:mm:ss") + "'").ToListAsync();

        }

        // PUT: api/LogBookDataTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLogBookDataTable(Guid id, TblLogBookDataTable tblLogBookDataTable)
        {
            if (id != tblLogBookDataTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLogBookDataTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLogBookDataTableExists(id))
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

        // POST: api/LogBookDataTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblLogBookDataTable>> PostTblLogBookDataTable(TblLogBookDataTable tblLogBookDataTable)
        //{
        //    _context.TblLogBookDataTables.Add(tblLogBookDataTable);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (TblLogBookDataTableExists(tblLogBookDataTable.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetTblLogBookDataTable", new { id = tblLogBookDataTable.Id }, tblLogBookDataTable);
        //}


        [HttpPost]
        public async Task<ActionResult> PostTblLogBookDataTable(TblLogBookDataTable tblLogbookData)
        {
            string sqlQuery = "EXEC [dbo].[sp_Logbook_Datatable] @Type,@Company_ID ,@Plant_Id ,@Dept_Id,@SubDept_Id,@By ,@Logbook_name,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@Company_ID",Direction =ParameterDirection.Input,Value = tblLogbookData.CompanyId },
            new SqlParameter {ParameterName="@Plant_Id",Direction =ParameterDirection.Input,Value = tblLogbookData.Plantcode },
            new SqlParameter {ParameterName="@Dept_Id",Direction =ParameterDirection.Input,Value = tblLogbookData.DeptId },
            new SqlParameter {ParameterName="@SubDept_Id",Direction =ParameterDirection.Input,Value = tblLogbookData.SubDeptid },
            new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=tblLogbookData.CretedBy},
            new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[7].Value);
        }


        // DELETE: api/LogBookDataTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLogBookDataTable(Guid id)
        {
            var tblLogBookDataTable = await _context.TblLogBookDataTables.FindAsync(id);
            if (tblLogBookDataTable == null)
            {
                return NotFound();
            }

            _context.TblLogBookDataTables.Remove(tblLogBookDataTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLogBookDataTableExists(Guid id)
        {
            return _context.TblLogBookDataTables.Any(e => e.Id == id);
        }
    }
}
