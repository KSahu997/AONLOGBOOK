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
    public class LookupValuesController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly CustomContext _ccontext;

        public LookupValuesController(DBContext context, CustomContext ccontext)
        {
            _context = context;
            _ccontext = ccontext;
        }

        // GET: api/LookupValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLookupValue>>> GetTblLookupValues()
        {
            return await _context.TblLookupValues.ToListAsync();
        }

        // GET: api/LookupValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLookupValue>> GetTblLookupValue(Guid id)
        {
            var tblLookupValue = await _context.TblLookupValues.FindAsync(id);

            if (tblLookupValue == null)
            {
                return NotFound();
            }

            return tblLookupValue;
        }

        // PUT: api/LookupValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLookupValue(Guid id, TblLookupValue tblLookupValue)
        {
            if (id != tblLookupValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLookupValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLookupValueExists(id))
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

        // POST: api/LookupValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<lookupEleList>>> PostTblLookupValue(lookupEleList le)
        {
            try
            {
                string sqlQuery = "EXEC [dbo].[SP_LookupValues] @lookupParams,@nameValue,@companyID,@lookupID,@plantID,@by";
                SqlParameter[] @params =
                { 
            // Create parameters    
            new SqlParameter {ParameterName="@nameValue",Direction =ParameterDirection.Input,Value =le.NameValue},
            new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value =le.CompanyId},
            new SqlParameter {ParameterName="@plantID",Direction=ParameterDirection.Input,Value=le.PlantId},
            new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=le.CreatedBy},            
            new SqlParameter {ParameterName="@lookupParams",Direction=ParameterDirection.Input,Value=ToDataTable<lookupElement>(le.Tbllookup),SqlDbType=SqlDbType.Structured,TypeName="dbo.tvpLookUp"},
            new SqlParameter {ParameterName="@lookupID",Direction =ParameterDirection.Input,Value =le.LookupId }
            };

                await _ccontext.Database.ExecuteSqlRawAsync(sqlQuery, @params);
                return Ok("success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



        // DELETE: api/LookupValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLookupValue(Guid id)
        {
            var tblLookupValue = await _context.TblLookupValues.FindAsync(id);
            if (tblLookupValue == null)
            {
                return NotFound();
            }

            _context.TblLookupValues.Remove(tblLookupValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLookupValueExists(Guid id)
        {
            return _context.TblLookupValues.Any(e => e.Id == id);
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

