using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using DBBase;


namespace SiteFrontend
{
    public class FrontCases
    {
        public static DataTable GetCaseList(int pageNumber, int casesPerPage, out int howManyPages)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Front_Case_GetFrontCaseList";


            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@PageNumber";
            dbParam.Value = pageNumber;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CasesPerPage";
            dbParam.Value = casesPerPage;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@HowManyCases";
            dbParam.Direction = ParameterDirection.Output;
            dbParam.DbType = DbType.Int32;
            dbComm.Parameters.Add(dbParam);


            DataTable fieldData;
            try
            {
                fieldData = BaseDB.ExecuteSelect(dbComm);
                int howManyCases = Int32.Parse(dbComm.Parameters["@HowManyCases"].Value.ToString());
                howManyPages = (int)Math.Ceiling((double)howManyCases / (double)casesPerPage);

            }
            catch (Exception exc)
            {

                throw exc;
            }
            return fieldData;
        }

    }
}
