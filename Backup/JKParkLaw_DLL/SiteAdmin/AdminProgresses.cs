using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;

namespace SiteAdmin
{
    public class AdminProgresses
    {
        public static DataTable GetProgressList(string memberID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Progress_GetProgressList";

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

        public static DataTable GetProgress(int progressID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Progress_GetProgress";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@ProgressID";
            param.Value = progressID;
            param.DbType = DbType.Int32;
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

        public static int AddNewProgress(string memberID, string title, string smallDesc, DateTime added)
        {
            return UpdateProgress(0, memberID, title, smallDesc, added);
        }
        public static int UpdateProgress(int progressID, string memberID, string title, string smallDesc, DateTime added)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            DbParameter dbParam;
            if (progressID == 0)
            {
                dbComm.CommandText = "E_Admin_Progress_AddNewProgress";

                dbParam = dbComm.CreateParameter();
                dbParam.ParameterName = "@MemberID";
                dbParam.Value = memberID;
                dbParam.DbType = DbType.String;
                dbParam.Direction = ParameterDirection.Input;
                dbComm.Parameters.Add(dbParam);

            }
            else
            {
                dbComm.CommandText = "E_Admin_Progress_UpdateProgress";

                dbParam = dbComm.CreateParameter();
                dbParam.ParameterName = "@ProgressID";
                dbParam.Value = progressID;
                dbParam.DbType = DbType.Int32;
                dbParam.Direction = ParameterDirection.Input;
                dbComm.Parameters.Add(dbParam);

            }

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Title";
            dbParam.Value = title;
            dbParam.Size = 125;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@SmallDesc";
            dbParam.Value = smallDesc;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Added";
            dbParam.Value = added;
            dbParam.DbType = DbType.DateTime;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);


            try
            {
                progressID = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return progressID;
        }

        public static bool DeleteProgress(int progressID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Progress_DeleteProgress";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Progress";
            dbParam.Value = progressID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);


            int result = -1;
            try
            {
                result = BaseDB.ExecuteNonQuery(dbComm);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return (result != -1);
        }

    }
}
