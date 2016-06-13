using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;

namespace SiteFrontend
{
    public class FrontProgresses
    {
        public static DataTable GetProgressList(string memberID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Progress_GetProgressList";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@MemberID";
            param.Value = memberID;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            DataTable p;
            try
            {
                p = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return p;
        }
    }
}
