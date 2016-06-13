using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;

namespace SiteAdmin
{
    public class AdminCategories
    {
        public static int AddNewCategory(string categoryName, string categoryDesc, int sectionID, int parentID)
        {
            int categoryID = 0;

            //Add Section 
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_AddNewCategory";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryName";
            dbParam.Value = categoryName;
            dbParam.Size = 125;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryDesc";
            dbParam.Value = categoryDesc;
            dbParam.Size = 255;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@SectionID";
            dbParam.Value = sectionID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ParentID";
            dbParam.Value = parentID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            try
            {
                categoryID = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {
                throw exc;
            }

            //bool urlUpdated = AdminURL.UpdateID(categoryURL, categoryID);
            return categoryID;
        }

        public static DataTable GetCategories(int sectionID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetCategories";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@SectionID";
            dbParam.Value = sectionID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable categoryData;
            try
            {
                categoryData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return categoryData;
        }

        public static void DeleteCategory(int categoryID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_DeleteCategory";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryID";
            dbParam.Value = categoryID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            try
            {
                BaseDB.ExecuteNonQuery(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public static DataTable GetCategories()
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetAllCategories";

            DataTable categoryData;
            try
            {
                categoryData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return categoryData;
        }

        public static DataTable GetCategory(int categoryID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetCategory";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryID";
            dbParam.Value = categoryID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable categoryData;
            try
            {
                categoryData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return categoryData;
        }

        public static bool UpdateCategoryDetails(int categoryID, string categoryName, bool categoryAvailable, string categoryDesc)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_UpdateCategory";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryName";
            dbParam.Value = categoryName;
            dbParam.Size = 125;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryAvailable";
            dbParam.Value = categoryAvailable;
            dbParam.DbType = DbType.Boolean;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryDesc";
            dbParam.Value = categoryDesc;
            dbParam.Size = 255;
            dbParam.DbType = DbType.String;
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
