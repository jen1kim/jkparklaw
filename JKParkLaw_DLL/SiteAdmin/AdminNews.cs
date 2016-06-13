using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;

namespace SiteAdmin
{
    public class AdminNews
    {
        public static int AddNews(string newsTitle, string source, string author, string newsSmallDesc, string newsDesc, bool hidden, DateTime modified)
        {
            return UpdateNews(0, newsTitle, source, author, newsSmallDesc, newsDesc, hidden, modified);
        }
        public static int UpdateNews(int newsID, string newsTitle, string source, string author, string newsSmallDesc, string newsDesc, bool hidden, DateTime modified)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            DbParameter dbParam;
            if (newsID == 0)
            {
                dbComm.CommandText = "E_AddNewNews";
            }
            else
            {
                dbComm.CommandText = "E_UpdateNews";

                dbParam = dbComm.CreateParameter();
                dbParam.ParameterName = "@NewsID";
                dbParam.Value = newsID;
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
            dbParam.ParameterName = "@NewsTitle";
            dbParam.Value = newsTitle;
            dbParam.Size = 125;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@NewsSmallDesc";
            dbParam.Value = newsSmallDesc;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@NewsDesc";
            dbParam.Value = newsDesc;
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
                newsID = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return newsID;
        }

        public static bool DeleteNews(int newsID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_DeleteNews";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@NewsID";
            dbParam.Value = newsID;
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

        public static DataTable GetNewsList()
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetNewsList";


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

        public static DataTable GetNews(int newsID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetNews";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@NewsID";
            dbParam.Value = newsID;
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
