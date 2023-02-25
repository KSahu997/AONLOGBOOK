using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AONLOGBOOK.API.Models;
using AONLOGBOOK.API.Services;
using AONLOGBOOK.SHARED.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AONLogbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantMastersController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IConfiguration con;
        private readonly SqlService _sql;
        public PlantMastersController(DBContext context, SqlService _sqlS, IConfiguration conn)
        {
            _context = context;
            _sql = _sqlS;
            con = conn;
        }

        // GET: api/PlantMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPlantMaster>>> GetTblPlantMasters()
        {
            SqlParameter[] @params =
            {
                new SqlParameter{ParameterName="@Type",Direction=ParameterDirection.Input,Value="SEL"}
            };
            return _sql.getDatas<TblPlantMaster>("sp_Plant_Master", @params);
        }

        
        [HttpGet("{Company_Id}")]
        public async Task<IEnumerable<TblPlantMaster>> GetTblPlantMasterByCompanyID(string Company_Id)
        {
            SqlParameter[] @params =
           {
                new SqlParameter{ParameterName="@company_id",Direction=ParameterDirection.Input,Value=Company_Id}
            };
            return _sql.getDatas<TblPlantMaster>("Sp_ListPlant", @params);



        }
        // PUT: api/PlantMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPlantMaster(Guid id, TblPlantMaster tblPlantMaster)
        {
            if (id != tblPlantMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblPlantMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlantMasterExists(id))
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

        // POST: api/PlantMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       
            public async Task<ActionResult> PostTblPlantMasters(TblPlantMaster tblPlantMaster)
            {

               // string sqlQuery = "EXEC[dbo].[sp_Plant_Master] @Plant_Name,@Address,@Country,@State,@City,@Pin,@Email,@Phone,@Company_Id,@By,@Type,@message=@message OUT";
                SqlParameter[] @params =
                { 
                    // Create parameters    
                    new SqlParameter {ParameterName="@Type",Direction=ParameterDirection.Input,Value="INS"},
                    new SqlParameter {ParameterName="@Plant_Name",Direction=ParameterDirection.Input,Value=tblPlantMaster.PlantName},
                    new SqlParameter {ParameterName="@Address",Direction=ParameterDirection.Input,Value=(object)tblPlantMaster.Address??DBNull.Value},
                    new SqlParameter {ParameterName="@Country",Direction=ParameterDirection.Input,Value=(object)tblPlantMaster.Country??DBNull.Value},
                    new SqlParameter {ParameterName="@State",Direction=ParameterDirection.Input,Value=(object)tblPlantMaster.State??DBNull.Value},
                    new SqlParameter {ParameterName="@City",Direction=ParameterDirection.Input,Value=(object)tblPlantMaster.City??DBNull.Value},
                    new SqlParameter {ParameterName="@Pin",Direction =ParameterDirection.Input,Value = (object)tblPlantMaster.PinCode??DBNull.Value},
                    new SqlParameter {ParameterName="@Email",Direction =ParameterDirection.Input,Value = (object)tblPlantMaster.Email??DBNull.Value},
                    new SqlParameter {ParameterName="@Phone",Direction =ParameterDirection.Input,Value = (object)tblPlantMaster.PhoneNo??DBNull.Value},
                    new SqlParameter {ParameterName="@Company_Id",Direction =ParameterDirection.Input,Value = (object)tblPlantMaster.CompanyId??DBNull.Value},
                    new SqlParameter {ParameterName="@By",Direction=ParameterDirection.Input,Value=(object)tblPlantMaster.CreatedBy??DBNull.Value},
                    new SqlParameter {ParameterName="@message",SqlDbType=SqlDbType.NVarChar,Size=50,Direction = ParameterDirection.Output}
                };
            
               _sql.postData("sp_Plant_Master", @params);
                return Ok(@params[11].Value);


        }

        // DELETE: api/PlantMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPlantMaster(int id)
        {
            var tblPlantMaster = await _context.TblPlantMasters.FindAsync(id);
            if (tblPlantMaster == null)
            {
                return NotFound();
            }

            _context.TblPlantMasters.Remove(tblPlantMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPlantMasterExists(Guid id)
        {
            return _context.TblPlantMasters.Any(e => e.Id == id);
        }
    }
}
