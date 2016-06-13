using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using DBBase;


namespace SiteAdmin
{
    public class AdminCases
    {
        public static int AddNewCase(string caseTitle, string caseFileName, string caseSmallDesc, bool hidden)
        {
            return UpdateCase(0, caseTitle, caseFileName, caseSmallDesc, hidden, DateTime.Now);
        }
        public static int UpdateCase(int caseID, string caseTitle, string caseFileName, string caseSmallDesc, bool hidden, DateTime modified)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            DbParameter dbParam;
            if (caseID == 0)
            {
                dbComm.CommandText = "E_AddNewCase";
            }
            else
            {
                dbComm.CommandText = "E_UpdateCase";

                dbParam = dbComm.CreateParameter();
                dbParam.ParameterName = "@CaseID";
                dbParam.Value = caseID;
                dbParam.DbType = DbType.Int32;
                dbParam.Direction = ParameterDirection.Input;
                dbComm.Parameters.Add(dbParam);

                dbParam = dbComm.CreateParameter();
                dbParam.ParameterName = "@Modified";
                dbParam.Value = modified;
                dbParam.DbType = DbType.DateTime;
                dbParam.Direction = ParameterDirection.Input;
                dbComm.Parameters.Add(dbParam);
            }

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CaseTitle";
            dbParam.Value = caseTitle;
            dbParam.Size = 125;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CaseFileName";
            dbParam.Value = caseFileName;
            dbParam.Size = 125;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CaseSmallDesc";
            dbParam.Value = caseSmallDesc;
            dbParam.DbType = DbType.String;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@Hidden";
            dbParam.Value = hidden;
            dbParam.DbType = DbType.Boolean;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);


            try
            {
                caseID = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return caseID;
        }

        public static bool DeleteCase(int caseID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_DeleteCase";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CaseID";
            dbParam.Value = caseID;
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

        public static bool UpdateCaseFileName(int caseID, string caseFileName)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_UpdateCaseFileName";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CaseID";
            dbParam.Value = caseID;
            dbParam.DbType = DbType.Int32;
            dbParam.Direction = ParameterDirection.Input;
            dbComm.Parameters.Add(dbParam);

            dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CaseFileName";
            dbParam.Value = caseFileName;
            dbParam.DbType = DbType.String;
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

        public static DataTable GetCaseList()
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetCaseList";


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

        public static DataTable GetCase(int caseID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_GetCase";

            DbParameter dbParam = dbComm.CreateParameter();
            dbParam.ParameterName = "@CaseID";
            dbParam.Value = caseID;
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

        public static bool UploadFile(int caseID, ref  FileUpload CaseFile, out string newFileName)
        {

            if (CaseFile.HasFile)
            {
                // First Move to temp
                string destinationTempPath = Configuration.GetKey("SiteDir") + "/Files/case/temp/" + caseID.ToString() + "_" + CaseFile.FileName;
                if (File.Exists(destinationTempPath)) File.Delete(destinationTempPath);
                CaseFile.SaveAs(destinationTempPath);
                FileInfo fileInfo = new FileInfo(destinationTempPath);
                string extension = fileInfo.Extension;
                string destinationDir = Configuration.GetKey("SiteDir") + "/Files/case/" + AdminTools.GetDirectotyID(caseID);
                if (!Directory.Exists(destinationDir))
                    Directory.CreateDirectory(destinationDir);

                string destinationPath;

                newFileName = caseID.ToString() + extension;
                destinationPath = destinationDir + "/" + newFileName;

                if (File.Exists(destinationPath)) File.Delete(destinationPath);
                CaseFile.SaveAs(destinationPath);
                

                try
                {
                    File.Delete(destinationTempPath);
                }
                catch (Exception)
                {

                }
                return true;
            }
            else
            {                
                newFileName = "";
                return false;
            }
        }

        public static bool DeleteFile(int caseID, string fileName)
        {
            string fileDirectory = Configuration.GetKey("SiteDir") + "/Files/case/" + AdminTools.GetDirectotyID(caseID);
            string newfileName = fileDirectory + "/" + fileName;
            try
            {
                File.Delete(newfileName);
                return true;
            }
            catch (Exception) 
            {
            }

            return false;
        }

    }
}
