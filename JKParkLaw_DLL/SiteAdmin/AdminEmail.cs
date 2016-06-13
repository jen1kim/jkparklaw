using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;


namespace SiteAdmin
{
    public class AdminEmail
    {

        public static bool DeleteCounseling(int counselingID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_DeleteCounseling";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CounselingID";
            dbParam.Value = counselingID;
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

        public static DataTable GetCounselings()
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetCounselings";


            DataTable result;
            try
            {
                result = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return result;
        }

        public static DataTable GetCounseling(int counselingID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetCounseling";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CounselingID";
            dbParam.Value = counselingID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable result;
            try
            {
                result = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return result;
        }

        public static bool UpdateCounselingStatus(int counselingID, bool processed)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_UpdateCounselingStatus";


            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CounselingID";
            dbParam.Value = counselingID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Processed";
            dbParam.Value = processed;
            dbParam.DbType = DbType.Boolean;
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
