using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
namespace DBBase
{
    public class BaseDB
    {
        public enum TransactionOption
        {
            Started,
            Stop
        }
        public static SqlTransaction connTransaction = null;

        static BaseDB()
        {
        }

        public static DbCommand CreateCommand()
        {
            DbCommand dbComm = null;
            try
            {
                string siteDBConnection = Configuration.SiteDBConnection;
                DbConnection dbConn = SqlClientFactory.Instance.CreateConnection();
                dbConn.ConnectionString = siteDBConnection;

                dbComm = dbConn.CreateCommand();
                dbComm.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception exc)
            {
                DBConnectionException dbe = new DBConnectionException();
                dbe.CustomMessage = "DB Connection Configuration Error! " + exc.Message.ToString();
                //throw exc;
                throw dbe;
            }

            return dbComm;
        }

        /// <summary>
        /// Executes a command and returns the number of rows affected
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(DbCommand dbCommand)
        {
            int affectedRows = -1;
            try
            {
                dbCommand.Connection.Open();
                affectedRows = dbCommand.ExecuteNonQuery();
            }
            catch (Exception exc)
            {

                throw exc;
            }
            finally
            {
                dbCommand.Connection.Close();
            }

            return affectedRows;

        }

        /// <summary>
        /// executes a command and returns a string value
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>

        public static string ExecuteScalar(DbCommand dbCommand)
        {
            string returnValue = "";
            try
            {
                dbCommand.Connection.Open();
                returnValue = dbCommand.ExecuteScalar().ToString();

            }
            catch (Exception exc)
            {

                throw exc;
            }
            finally
            {
                dbCommand.Connection.Close();
            }

            return returnValue;

        }
        /// <summary>
        /// Executes a command and return a datatable
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <returns></returns>
        public static DataTable ExecuteSelect(DbCommand dbCommand)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dbCommand.Connection.Open();
                DbDataReader dbReader = dbCommand.ExecuteReader();
                dataTable.Load(dbReader);
                dbReader.Close();
            }
            catch (Exception exc)
            {

                DBSelectionException dbe = new DBSelectionException();
                dbe.CustomMessage = "DB Selection Error! " + exc.Message.ToString();
                //throw exc;
                throw dbe;
            }
            finally
            {
                dbCommand.Connection.Close();
            }

            return dataTable;
        }
    }

    public class DBSelectionException : Exception
    {
        private string customMessage;
        public string CustomMessage
        {
            get { return this.customMessage; }
            set { this.customMessage = value; }
        }

        public DBSelectionException()
        { }
    }

    public class DBConnectionException : Exception
    {
        private string customMessage;
        public string CustomMessage
        {
            get { return this.customMessage; }
            set { this.customMessage = value; }
        }

        public DBConnectionException()
        { }
    }
}
