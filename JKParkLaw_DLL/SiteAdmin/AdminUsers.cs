using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.UI.WebControls;
using DBBase;

namespace SiteAdmin
{
    public class AdminUsers
    {
        public static DataTable SearchAdminUser(string userID, string password)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_SearchAdminUser";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@UserID";
            dbParam.Value = userID;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Password";
            dbParam.Value = password;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable usertable;
            try
            {
                usertable = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return usertable;
        }

    }
}
