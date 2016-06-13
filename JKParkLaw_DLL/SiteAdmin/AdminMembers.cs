using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBBase;

namespace SiteAdmin
{
    public class AdminMembers
    {

        public static bool CheckMemberID(string memberID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Members_CheckMemberID";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@MemberID";
            param.Value = memberID;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            int count;
            try
            {
                count = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return count > 0;
        }

        public static void DeleteMember(string memberID)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Members_DeleteMember";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@MemberID";
            param.Value = memberID;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);
            
            try
            {
                BaseDB.ExecuteNonQuery(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            
        }
        public static DataTable GetMembers()
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Members_GetMembers";            

            DataTable members;
            try
            {
                members = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return members;
        }


        public static DataTable GetMemberInfo(string memberId, string password)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Members_GetMemberInfo";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@MemberID";
            param.Value = memberId;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Password";
            param.Value = password;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            DataTable states;
            try
            {
                states = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return states;
        }

        public static DataTable GetMemberInfoByMemberID(string memberId)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Members_GetMemberInfoByMemberID";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@MemberID";
            param.Value = memberId;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            DataTable states;
            try
            {
                states = BaseDB.ExecuteSelect(dbComm);
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return states;
        }


        public static int CreateMemberInfo(string memberID, string password, string email, string fname, string lname,
            string korName, string phone, string address, string address2, string city, 
            string state, string zip, string progressStatus, bool activeStatus, DateTime joined)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Members_CreateMemberInfo";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@MemberID";
            param.Value = memberID;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Password";
            param.Value = password;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Email";
            param.Value = email;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@FName";
            param.Value = fname;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@LName";
            param.Value = lname;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@KorName";
            param.Value = korName;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Phone";
            param.Value = phone;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = address;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Address2";
            param.Value = address2;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@City";
            param.Value = city;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@State";
            param.Value = state;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Zip";
            param.Value = zip;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@ProgressStatus";
            param.Value = progressStatus;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = activeStatus;
            param.DbType = DbType.Boolean;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Joined";
            param.Value = joined;
            param.DbType = DbType.DateTime;
            dbComm.Parameters.Add(param);

            int id;
            try
            {
                id = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return id;
        }

        public static int UpdateMemberInfo(string memberID, string password, string email, string fname, string lname,
            string korName, string phone, string address, string address2, string city,
            string state, string zip, string progressStatus, bool activeStatus, DateTime joined)
        {
            DbCommand dbComm = BaseDB.CreateCommand();
            dbComm.CommandText = "E_Admin_Members_UpdateMemberInfo";

            DbParameter param = dbComm.CreateParameter();
            param.ParameterName = "@MemberID";
            param.Value = memberID;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Password";
            param.Value = password;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Email";
            param.Value = email;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@FName";
            param.Value = fname;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@LName";
            param.Value = lname;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@KorName";
            param.Value = korName;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Phone";
            param.Value = phone;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Address";
            param.Value = address;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Address2";
            param.Value = address2;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@City";
            param.Value = city;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@State";
            param.Value = state;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Zip";
            param.Value = zip;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@ProgressStatus";
            param.Value = progressStatus;
            param.DbType = DbType.String;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@ActiveStatus";
            param.Value = activeStatus;
            param.DbType = DbType.Boolean;
            dbComm.Parameters.Add(param);

            param = dbComm.CreateParameter();
            param.ParameterName = "@Joined";
            param.Value = joined;
            param.DbType = DbType.DateTime;
            dbComm.Parameters.Add(param);

            int id;
            try
            {
                id = int.Parse(BaseDB.ExecuteScalar(dbComm));
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return id;
        }
    }
}
