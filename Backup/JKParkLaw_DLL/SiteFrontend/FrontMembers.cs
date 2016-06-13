using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;

namespace SiteFrontend
{
    public class FrontMembers
    {
        public static DataTable GetMemberInfo(string memberId, string password)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Members_GetMemberInfo";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@MemberID";
            param.Value = memberId;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Password";
            param.Value = password;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            DataTable states;
            try
            {
                states = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return states;
        }
    }
}
