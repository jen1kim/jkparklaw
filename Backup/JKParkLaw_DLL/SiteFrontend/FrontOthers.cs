using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DBBase;
namespace SiteFrontend
{
    public class FrontOthers
    {
        public static DataTable GetOthersIDs(int pageNumber, int numbersPerPage, out int howManyPages)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Other_GetOtherList";


            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@PageNumber";
            dbParam.Value = pageNumber;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@NumbersPerPage";
            dbParam.Value = numbersPerPage;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@HowManyNumbers";
            dbParam.Direction = ParameterDirection.Output;
            dbParam.DbType = DbType.Int32;
            dbComm.Parameters.Add(dbParam);


            DataTable fieldData;
            try
            {
                fieldData = BaseDB.ExecuteSelect(dbComm);
                int howManyNumbers = Int32.Parse(dbComm.Parameters["@HowManyNumbers"].Value.ToString());
                howManyPages = (int)Math.Ceiling((double)howManyNumbers / (double)numbersPerPage);

            }
            catch (Exception exc)
            {

                throw exc;
            }
            return fieldData;
        }


        public static DataTable GetOther(int ID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Other_GetOther";

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

        public static DataTable GetFrontOtherList(int ordersNumber)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Other_GetFrontOtherList";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@OrdersNumber";
            dbParam.Value = ordersNumber;
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
