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
    public class LogbookDetailSchemasController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly CustomContext _ccontext;

        public LogbookDetailSchemasController(DBContext context, CustomContext ccontext)
        {
            _context = context;
            _ccontext = ccontext;
        }

        // GET: api/LogbookDetailSchemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLogbookDetailSchema>>> GetTblLogbookDetailSchemas()
        {
            return await _context.TblLogbookDetailSchemas.ToListAsync();
        }

        // GET: api/LogbookDetailSchemas/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblLogbookDetailSchema>> GetTblLogbookDetailSchema(Guid id)
        //{
        //    var tblLogbookDetailSchema = await _context.TblLogbookDetailSchemas.FindAsync(id);

        //    if (tblLogbookDetailSchema == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblLogbookDetailSchema;
        //}

        [HttpGet("{LogbookId}")]
        public async Task<ActionResult<IEnumerable<TblLogbookDetailSchemaMOD>>> GetTblLogbookDetailSchema(string LogbookId)
        {
            try { 
                     return await _ccontext.TblLogbookDetailSchemaMODs.FromSqlRaw("sp_Logbook_Detail_Schema'" + LogbookId + "'").ToListAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
            //return await _ccontext.TblLogbookDetailSchemaMODs.FromSqlRaw("sp_Logbook_Detail_Schema'" + LogbookId + "'").ToListAsync();
        }


        // PUT: api/LogbookDetailSchemas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLogbookDetailSchema(Guid id, TblLogbookDetailSchema tblLogbookDetailSchema)
        {
            if (id != tblLogbookDetailSchema.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblLogbookDetailSchema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLogbookDetailSchemaExists(id))
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




        [HttpPost]
        public async Task<ActionResult> PostTblLogbookDetailSchema(TblLogbookDetailSchema tblLogbookDetailSchema)
        {
            string sqlQuery = "EXEC [dbo].[sp_LogBookSchema] @Type,@LogbookId ,@Element ,@DataType,@UOM,@source,@L_min,@L_max,@Prscn,@By,@refcol,@cal_param,@operator,@ismandatory,@message=@message OUT ";
            SqlParameter[] @params =
            { 
            // Create parameters    
                new SqlParameter {ParameterName="Type",Direction=ParameterDirection.Input,Value="INS"},
                new SqlParameter {ParameterName="LogbookId",Direction =ParameterDirection.Input,Value = (object)tblLogbookDetailSchema.LogbookId??DBNull.Value},
                new SqlParameter {ParameterName="Element",Direction =ParameterDirection.Input,Value = (object)tblLogbookDetailSchema.Element ??DBNull.Value},
                new SqlParameter {ParameterName="DataType",Direction =ParameterDirection.Input,Value = (object)tblLogbookDetailSchema.DataType ??DBNull.Value},
                new SqlParameter {ParameterName="UOM",Direction =ParameterDirection.Input,Value = (object)tblLogbookDetailSchema.Uom ??DBNull.Value},
                new SqlParameter {ParameterName="source",Direction =ParameterDirection.Input,Value = (object)tblLogbookDetailSchema.Source ??DBNull.Value},
                new SqlParameter {ParameterName="L_min",Direction =ParameterDirection.Input,Value = (object)tblLogbookDetailSchema.LMin??DBNull.Value },
                new SqlParameter {ParameterName="L_max",Direction =ParameterDirection.Input,Value = (object)tblLogbookDetailSchema.LMax ??DBNull.Value},
                new SqlParameter {ParameterName="Prscn",Direction =ParameterDirection.Input,Value = (object)tblLogbookDetailSchema.Prscn ??DBNull.Value},
                new SqlParameter {ParameterName="By",Direction=ParameterDirection.Input,Value=(object)tblLogbookDetailSchema.CreatedBy??DBNull.Value},
                new SqlParameter {ParameterName="refcol",Direction=ParameterDirection.Input,Value=(object)tblLogbookDetailSchema.RefCol??DBNull.Value}, 
                new SqlParameter {ParameterName="cal_param",Direction=ParameterDirection.Input,Value=(object)tblLogbookDetailSchema.CalulationParams??DBNull.Value},
                new SqlParameter {ParameterName="operator",Direction=ParameterDirection.Input,Value=(object)tblLogbookDetailSchema.Operator??DBNull.Value},
                new SqlParameter {ParameterName="ismandatory",Direction=ParameterDirection.Input,Value=(object)tblLogbookDetailSchema.IsMandatory??DBNull.Value},

                    new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
            };
            await _context.Database.ExecuteSqlRawAsync(sqlQuery, @params);
            return Ok(@params[14].Value);
        }

        // DELETE: api/LogbookDetailSchemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLogbookDetailSchema(Guid id)
        {
            var tblLogbookDetailSchema = await _context.TblLogbookDetailSchemas.FindAsync(id);
            if (tblLogbookDetailSchema == null)
            {
                return NotFound();
            }

            _context.TblLogbookDetailSchemas.Remove(tblLogbookDetailSchema);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool TblLogbookDetailSchemaExists(Guid id)
        {
            return _context.TblLogbookDetailSchemas.Any(e => e.Id == id);
        }
    }
}
