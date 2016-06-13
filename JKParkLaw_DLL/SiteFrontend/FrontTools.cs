using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteFrontend
{
    public class FrontTools
    {
        public static string GetDirectotyID(int ID)
        {
            int resutl = 1000;
            double divizion = ID / 1000;
            double resultdbl = Math.Floor(divizion) * 1000 + 1000;
            resutl = Convert.ToInt32(resultdbl);
            return resutl.ToString();
        }
    }
}
