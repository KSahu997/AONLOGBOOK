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
using System.Drawing;
using AONLOGBOOK.API.Service;

namespace AONLOGBOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionalLocationMastersController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly CustomContext _ccontext;
        private readonly IConfiguration _con;
        private readonly SqlADO _sql;

        public FunctionalLocationMastersController(DBContext context, CustomContext ccontext, IConfiguration con, SqlADO sql)
        {
            _context = context;
            _ccontext = ccontext;
            _con = con;
            _sql = sql;
        }

        // GET: api/FunctionalLocationMasters
        [HttpGet]
        public async Task<ActionResult<DataTable>> GetFunctionalLocation()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_con.GetConnectionString("db").ToString()))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SP_FunctionalLocation";
                        cmd.Parameters.Add(new SqlParameter("@type", "SEL"));
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return dt;

        }

        // GET: api/FunctionalLocationMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblFunctionalLocationMaster>> GetTblFunctionalLocationMaster(Guid id)
        {
            var tblFunctionalLocationMaster = await _context.TblFunctionalLocationMasters.FindAsync(id);

            if (tblFunctionalLocationMaster == null)
            {
                return NotFound();
            }

            return tblFunctionalLocationMaster;
        }



        // POST: api/FunctionalLocationMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostFunctionalLocation(TblFunctionalLocationMaster tblFunctionalLocationMaster)
        {

            //SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
            List<SqlParameter> @params = new()
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@FunName",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.FunctionalLocation },
            new SqlParameter {ParameterName="@FunCode",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.LocationCode },
            new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.CompanyId },
            new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.PlantId },
            new SqlParameter {ParameterName="@WorkCenID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.WorkCenterId },
            new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=tblFunctionalLocationMaster.InsertedBy},
            };
            @params = _sql.SqlCall("SP_FunctionalLocation", @params.ToList());
            return Ok("success");
        }

        // UPDATE : api/FunctionalLocationMasters
        [HttpPost("update")]
        public async Task<ActionResult> UpdateFunctionalLocation(TblFunctionalLocationMaster tblFunctionalLocationMaster)
        {

            //SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
            List<SqlParameter> @params = new()
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
            new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Id },
            new SqlParameter {ParameterName="@FunName",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.FunctionalLocation },
            new SqlParameter {ParameterName="@FunCode",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.LocationCode },
            new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.CompanyId },
            new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.PlantId },
            new SqlParameter {ParameterName="@WorkCenID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.WorkCenterId },
            new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=tblFunctionalLocationMaster.UpdatedBy},
            };
            @params = _sql.SqlCall("SP_FunctionalLocation", @params.ToList());
            return Ok("success");
        }

        // DELETE: api/FunctionalLocationMasters/5
        [HttpPost("delete")]
        public async Task<ActionResult> DeleteFunctionalLocation(TblFunctionalLocationMaster tblFunctionalLocationMaster)
        {

            //SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
            List<SqlParameter> @params = new()
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="DEL"},
            new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblFunctionalLocationMaster.Id },
            new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=tblFunctionalLocationMaster.UpdatedBy},
            };
            @params = _sql.SqlCall("SP_FunctionalLocation", @params.ToList());
            return Ok("success");
        }
    }
}
