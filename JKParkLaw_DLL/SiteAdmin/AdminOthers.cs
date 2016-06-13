using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;

namespace SiteAdmin
{
    public class AdminOthers
    {
        public static int AddOther(string title, string source, string author, string smallDesc, string bigDesc, bool hidden, DateTime modified)
        {
            return UpdateOther(0, title, source, author, smallDesc, bigDesc, hidden, modified);
        }
        public static int UpdateOther(int ID, string title, string source, string author, string smallDesc, string bigDesc, bool hidden, DateTime modified)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            DbParameter dbParam;
            if (ID == 0)
            {
                dbComm.CommandText = "E_AddNewOther";
            }
            else
            {
                dbComm.CommandText = "E_UpdateOther";

                dbParam = dbComm.CreateParameter();
                dbParam.ParameterName = "@ID";
                dbParam.Value = ID;
                dbParam.DbType = DbType.Int32;
                dbParam.Direction = ParameterDirection.Input;
                dbComm.Parameters.Add(dbParam);
            }

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Modified";
            dbParam.Value = modified;
            dbParam.DbType = DbType.DateTime;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Title";
            dbParam.Value = title;
            dbParam.Size = 255;
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
            dbParam.ParameterName = "@BigDesc";
            dbParam.Value = bigDesc;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Hidden";
            dbParam.Value = hidden;
            dbParam.DbType = DbType.Boolean;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Source";
            dbParam.Value = source;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Author";
            dbParam.Value = author;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            try
            {
                ID = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return ID;
        }

        public static bool DeleteOther(int ID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_DeleteOther";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ID";
            dbParam.Value = ID;
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

        public static DataTable GetOtherList()
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetOtherList";


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

        public static DataTable GetOther(int ID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetOther";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ID";
            dbParam.Value = ID;
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
