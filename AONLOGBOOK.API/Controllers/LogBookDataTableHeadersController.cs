using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AONLOGBOOK.API.Models;
using AONLOGBOOK.SHARED.Models;
using AONLOGBOOK.SHARED.CModels;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace AONLOGBOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogBookDataTableHeadersController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly CustomContext _ccontext;
        public LogBookDataTableHeadersController(DBContext context ,CustomContext ccontext)
        {
            _context = context;
            _ccontext= ccontext;
        }

        // GET: api/LogBookDataTableHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLogBookDataTableHeader>>> GetTblLogBookDataTableHeaders()
        {
            return await _context.TblLogBookDataTableHeaders.ToListAsync();
        }

        // GET: api/LogBookDataTableHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLogBookDataTableHeader>> GetTblLogBookDataTableHeader(Guid id)
        {
            var tblLogBookDataTableHeader = await _context.TblLogBookDataTableHeaders.FindAsync(id);

            if (tblLogBookDataTableHeader == null)
            {
                return NotFound();
            }

            return tblLogBookDataTableHeader;
        }

        // PUT: api/LogBookDataTableHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLogBookDataTableHeader(Guid id, TblLogBookDataTableHeader tblLogBookDataTableHeader)
        {
            if (id != tblLogBookDataTableHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLogBookDataTableHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLogBookDataTableHeaderExists(id))
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

        // POST: api/LogBookDataTableHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<TblLogBookDataTableHeader>> PostTblLogBookDataTableHeader(TblLogBookDataTableHeader tblLogBookDataTableHeader)
        //{
        //    _context.TblLogBookDataTableHeaders.Add(tblLogBookDataTableHeader);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetTblLogBookDataTableHeader", new { id = tblLogBookDataTableHeader.Id }, tblLogBookDataTableHeader);
        //}

        [HttpPost]

        public async Task <ActionResult<List<LogDataList>>>PostTblLogData(LogDataList logdt)
        { 
            try
            {
                string sqlQuery = "EXEC [dbo].[insertLog]  @data,@Company,@Plant,@DeptId,@subDeptId,@CreatedBy,@DateTime,@Shift,@LogbookId";
                SqlParameter[] @params =
                { 
            // Create parameters    
            new SqlParameter {ParameterName="@data",Direction=ParameterDirection.Input,Value=ToDataTable<LogData>(logdt.TblLog),SqlDbType=SqlDbType.Structured,TypeName="dbo.PostDynamicData"},
            new SqlParameter {ParameterName="@Company",Direction =ParameterDirection.Input,Value =logdt.TblLogHead.CompanyId},
            new SqlParameter {ParameterName="@Plant",Direction =ParameterDirection.Input,Value =logdt.TblLogHead.PlantId},
            new SqlParameter {ParameterName="@DeptId",Direction =ParameterDirection.Input,Value =logdt.TblLogHead.DeptId },
            new SqlParameter {ParameterName="@subDeptId",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.SubDeptId},
            new SqlParameter {ParameterName="@CreatedBy",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.CreatedBy},
            new SqlParameter {ParameterName="@DateTime",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.date},
            new SqlParameter {ParameterName="@Shift",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.Shift},
            new SqlParameter {ParameterName="@LogbookId",Direction=ParameterDirection.Input,Value=logdt.TblLogHead.LogbookId}
            };

                await _ccontext.Database.ExecuteSqlRawAsync(sqlQuery, @params);
                return Ok("success");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
          
        } 

        // DELETE: api/LogBookDataTableHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLogBookDataTableHeader(Guid id)
        {
            var tblLogBookDataTableHeader = await _context.TblLogBookDataTableHeaders.FindAsync(id);
            if (tblLogBookDataTableHeader == null)
            {
                return NotFound();
            }

            _context.TblLogBookDataTableHeaders.Remove(tblLogBookDataTableHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLogBookDataTableHeaderExists(Guid id)
        {
            return _context.TblLogBookDataTableHeaders.Any(e => e.Id == id);
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }
}
