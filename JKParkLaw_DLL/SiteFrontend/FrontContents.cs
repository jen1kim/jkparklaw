using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DBBase;

namespace SiteFrontend
{
    public class FrontContents
    {
        public static DataTable GetContents(int categoryID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Contents_GetContents";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryID";
            dbParam.Value = categoryID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable contents;
            try
            {
                contents = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return contents;
        }

        public static DataTable GetContent(int contentID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Contents_GetContent";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ContentID";
            dbParam.Value = contentID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable content;
            try
            {
                content = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return content;
        }

    }
}
