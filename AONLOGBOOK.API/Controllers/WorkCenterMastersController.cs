using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AONLOGBOOK.API.Models;
using AONLOGBOOK.SHARED.Models;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Data;
using AONLOGBOOK.API.Service;

namespace AONLOGBOOK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkCenterMastersController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly CustomContext _ccontext;
        private readonly IConfiguration _con;
        private readonly SqlADO _sql;

        public WorkCenterMastersController(DBContext context,CustomContext ccontext, IConfiguration con,SqlADO sql)
        {
            _context = context;
            _ccontext = ccontext;
            _con = con;
            _sql = sql;
        }

        //// GET: api/WorkCenterMasters
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblWorkCenterMaster>>> GetTblWorkCenterMasters()
        //{
        //    return await _context.TblWorkCenterMasters.Where(w=>w.DelFlag==0).ToListAsync();
        //}

        // GET: api/WorkCenterMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblWorkCenterMaster>> GetTblWorkCenterMaster(Guid id)
        {
            var tblWorkCenterMaster = await _context.TblWorkCenterMasters.FindAsync(id);

            if (tblWorkCenterMaster == null)
            {
                return NotFound();
            }

            return tblWorkCenterMaster;
        }

        [HttpGet]
        public async Task<ActionResult<DataTable>> GetTblLogBookDataTableByIds()
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
                        cmd.CommandText = "SP_WorkCenter";
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

        // POST: api/WorkCenterMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTblWorkcenter(TblWorkCenterMaster tblWorkCenterMaster)
        {
           
            //SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
            List<SqlParameter> @params = new()
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="INS"},
            new SqlParameter {ParameterName="@WrokName",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.WorkCenterName },
            new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.CompanyId },
            new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.PlantId },
            new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=tblWorkCenterMaster.InsertedBy},
            };
            @params = _sql.SqlCall("SP_WorkCenter", @params.ToList());
            return Ok("success");
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateTblWorkcenter(TblWorkCenterMaster tblWorkCenterMaster)
        {

            //SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
            List<SqlParameter> @params = new()
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="UPD"},
            new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.Id },
            new SqlParameter {ParameterName="@WrokName",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.WorkCenterName },
            new SqlParameter {ParameterName="@companyID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.CompanyId },
            new SqlParameter {ParameterName="@plantID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.PlantId },
            new SqlParameter {ParameterName="@by",Direction=ParameterDirection.Input,Value=tblWorkCenterMaster.UpdatedBy},
            };
            @params = _sql.SqlCall("SP_WorkCenter", @params.ToList());
            return Ok("success");
        }

        [HttpPost("delete")]
        public async Task<ActionResult> DeleteTblWorkcenter(TblWorkCenterMaster tblWorkCenterMaster)
        {

            //SqlConnection con = new SqlConnection(_con.GetConnectionString("db").ToString());
            List<SqlParameter> @params = new()
            { 
            // Create parameters    
            new SqlParameter {ParameterName="@type",Direction=ParameterDirection.Input,Value="DEL"},
            new SqlParameter {ParameterName="@ID",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.Id },
            new SqlParameter {ParameterName="@by",Direction =ParameterDirection.Input,Value = tblWorkCenterMaster.UpdatedBy },
            };
            @params = _sql.SqlCall("SP_WorkCenter", @params.ToList());
            return Ok("success");
        }

    }
}
