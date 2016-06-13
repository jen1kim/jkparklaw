using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;
using NLog;

namespace SiteFrontend
{
    public class FrontSections
    {

        public static DataTable GetSection(int categoryID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Sections_GetSection";
            dbComm.CommandType = CommandType.StoredProcedure;

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryID";
            dbParam.Value = categoryID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable fieldData;
            try
            {
                fieldData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }

            return fieldData;
        }

        public static DataTable GetSubCategories(int categoryID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Sections_GetSubSections";


            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryID";
            dbParam.Value = categoryID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable fieldData;
            try
            {
                fieldData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return fieldData;
        }


        public static DataTable GetAllCategories()
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Sections_GetAllCategories";
            dbComm.CommandType = CommandType.StoredProcedure;


            DataTable fieldData;
            try
            {
                fieldData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return fieldData;
        }


        public static int CountSubCategoriesInCategory(int categoryID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Categories_CountSubCategoriesInCategory";


            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryID";
            dbParam.Value = categoryID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable fieldData;
            try
            {
                fieldData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            if (fieldData.Rows.Count > 0)
            {
                int prodCount = 0;
                int.TryParse(fieldData.Rows[0]["Total"].ToString(), out prodCount);
                if (prodCount > 0)
                {
                    return prodCount;
                }
            }
            return 0;
        }
    }
}
