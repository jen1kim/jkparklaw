using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DBBase;

namespace SiteFrontend
{
    public class FrontNews
    {

        public static DataTable GetNewsIDs(int pageNumber, int productsPerPage, out int howManyPages)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_News_GetNewsList";


            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@PageNumber";
            dbParam.Value = pageNumber;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@ProductsPerPage";
            dbParam.Value = productsPerPage;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@HowManyProducts";
            dbParam.Direction = ParameterDirection.Output;
            dbParam.DbType = DbType.Int32;
            dbComm.Parameters.Add(dbParam);


            DataTable fieldData;
            try
            {
                fieldData = BaseDB.ExecuteSelect(dbComm);
                int howManyProducts = Int32.Parse(dbComm.Parameters["@HowManyProducts"].Value.ToString());
                howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)productsPerPage);

            }
            catch (Exception exc)
            {

                throw exc;
            }
            return fieldData;
        }


        public static DataTable GetNews(int newsID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_News_GetNews";

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

        public static DataTable GetFrontNewsList(int newsNumber)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_News_GetFrontNewsList";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@NewsNumber";
            dbParam.Value = newsNumber;
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
