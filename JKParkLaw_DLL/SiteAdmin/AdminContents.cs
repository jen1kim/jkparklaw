using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;


namespace SiteAdmin
{
    public class AdminContents
    {
        public static int AddNewContent(string contentTitle, string contentSmallDesc, string contentDesc, bool hidden, DateTime created, DateTime modified)
        {
            return UpdateContent(0, contentTitle, contentSmallDesc, contentDesc, hidden, created, modified);
        }
        public static int UpdateContent(int contentID, string contentTitle, string contentSmallDesc, string contentDesc, bool hidden, DateTime created, DateTime modified)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            DbParameter dbParam;
            if (contentID == 0)
            {
                dbComm.CommandText = "E_AddNewContent";
            }
            else
            {
                dbComm.CommandText = "E_UpdateContent";

                dbParam = dbComm.CreateParameter();
                dbParam.ParameterName = "@ContentID";
                dbParam.Value = contentID;
                dbParam.DbType = DbType.Int32;
                dbParam.Direction = ParameterDirection.Input;
                dbComm.Parameters.Add(dbParam);
            }

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ContentTitle";
            dbParam.Value = contentTitle;
            dbParam.Size = 255;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ContentSmallDesc";
            dbParam.Value = contentSmallDesc;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ContentDesc";
            dbParam.Value = contentDesc;
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
            dbParam.ParameterName = "@Created";
            dbParam.Value = created;
            dbParam.DbType = DbType.DateTime;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Modified";
            dbParam.Value = modified;
            dbParam.DbType = DbType.DateTime;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            
            try
            {
                contentID = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return contentID;
        }

        public static bool DeleteContentsCategories(int contentID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_DeleteContentsCategories";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ContentID";
            dbParam.Value = contentID;
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

        public static bool DeleteContent(int contentID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_DeleteContent";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ContentID";
            dbParam.Value = contentID;
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

        public static DataTable GetContents(int categoryID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetContents";

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
            dbComm.CommandText = "E_GetContent";

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

        public static bool AddContentToCategory(int contentID, int categoryID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_AddContentToCategory";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ContentID";
            dbParam.Value = contentID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryID";
            dbParam.Value = categoryID;
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
