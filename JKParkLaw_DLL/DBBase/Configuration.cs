using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;

namespace DBBase
{
    public class Configuration
    {
        private readonly static string siteDBConnection;

        static Configuration()
        {
            System.Configuration.ConnectionStringSettingsCollection coll = System.Web.Configuration.WebConfigurationManager.ConnectionStrings;
            siteDBConnection = coll["SiteDBConnection"].ConnectionString;
        }

        public static string GetKey(string key)
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings[key];

        }
        public static int GetKeyInt(string key)
        {
            return int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings[key]);

        }
        public static bool GetKeyBool(string key)
        {
            if (GetKey(key) == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string SiteDBConnection
        {
            get
            {
                return siteDBConnection;
            }
        }

    }
}
