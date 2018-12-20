using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FormAuthentication.DAL
{
    public class dbContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        public int Admin_Login(string Admin_Id, string Password)
        {
            SqlCommand cmd = new SqlCommand("Sp_Admin_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Admin_Id", Admin_Id);
            cmd.Parameters.AddWithValue("@Password", Password);
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@Isvalid";
            sqlParameter.Direction = ParameterDirection.Output;
            sqlParameter.SqlDbType = SqlDbType.Bit;
            cmd.Parameters.Add(sqlParameter);
            con.Open();
            cmd.ExecuteNonQuery();
            int rest = Convert.ToInt32(sqlParameter.Value);
            con.Close();
            return rest;
          
        }
    }

}
