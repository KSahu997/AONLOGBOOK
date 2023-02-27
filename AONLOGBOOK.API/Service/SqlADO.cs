using AONLOGBOOK.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AONLOGBOOK.API.Service
{
    public class SqlADO
    {
        private IConfiguration _config;
        public SqlADO(IConfiguration config) 
        { 
            _config = config;
        }
        public List<SqlParameter> SqlCall(string sql,List<SqlParameter> param) 
        {
            using(SqlConnection con = new SqlConnection(_config.GetConnectionString("db").ToString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                param.ForEach(a =>
                {
                    cmd.Parameters.Add(a);
                });
                cmd.ExecuteNonQuery();
            }
            return param;
        }

		internal ActionResult<T> SqlCall<T>(string v)
		{
			throw new NotImplementedException();
		}
	}
}
