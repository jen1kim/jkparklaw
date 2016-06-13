using System;
using System.Data;
using System.Data.Common;
using DBBase;

namespace SiteAdmin
{
    public class AdminTools
    {
        public AdminTools()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string GetDirectotyID(int ID)
        {
            int result = 1000;
            double divizion = ID / 1000;
            double resultdbl = Math.Floor(divizion) * 1000 + 1000;
            result = Convert.ToInt32(resultdbl);
            return result.ToString();
        }
    }
}
