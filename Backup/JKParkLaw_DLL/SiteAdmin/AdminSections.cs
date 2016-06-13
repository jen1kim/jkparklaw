using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;

namespace SiteAdmin
{
    public class AdminSections
    {
        public AdminSections()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int AddNewSection(string sectionName, string sectionDesc)
        {
            int sectionID = 0;

            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_AddNewSection";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryName";
            dbParam.Value = sectionName;
            dbParam.Size = 125;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CategoryDesc";
            dbParam.Value = sectionDesc;
            dbParam.Size = 255;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            try
            {
                sectionID = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {
                throw exc;
            }

            //bool urlUpdated = AdminURL.UpdateID(sectionURL, sectionID);
            return sectionID;
        }
        public static bool UpdateSectionDetails(int sectionID, string sectionName, bool sectionAvailable, string sectionDesc)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_UpdateSection";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@SectionName";
            dbParam.Value = sectionName;
            dbParam.Size = 125;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@SectionDesc";
            dbParam.Value = sectionDesc;
            dbParam.Size = 255;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@SectionAvailable";
            dbParam.Value = sectionAvailable;
            dbParam.DbType = DbType.Boolean;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@SectionID";
            dbParam.Value = sectionID;
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
        public static DataTable GetSection(int sectionID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetSection";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@SectionID";
            dbParam.Value = sectionID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            DataTable sectionData;
            try
            {
                sectionData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return sectionData;
        }

        public static DataTable GetSections()
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetSections";

            DataTable sectionData;
            try
            {
                sectionData = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return sectionData;
        }
    }
}
