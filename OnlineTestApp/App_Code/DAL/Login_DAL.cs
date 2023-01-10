using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineTestApp.App_Code.DAL
{
    public class Login_DAL
    {
        #region Login

        public DataSet Login(String Role, String UserName, String Password)
        {
            String msg;

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Role", Role);
            param[1] = new SqlParameter("@UserName", UserName);
            param[2] = new SqlParameter("@Password", Password);
           

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnectionString(), CommandType.StoredProcedure, "Proc_Login", param);
           
            return ds;

        }
        #endregion
    }
}