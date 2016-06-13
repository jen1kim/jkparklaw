using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKParkLaw.About
{
    public partial class Directions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string StylePath
        {
            get { return ((JKParkLaw.Front)Page.Master).StylePath; }
        }

        public string AppPath
        {
            get { return ((JKParkLaw.Front)Page.Master).AppPath; }
        }
    }
}
