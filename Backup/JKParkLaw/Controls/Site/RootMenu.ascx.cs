using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NLog;

namespace JKParkLaw.Controls.Site
{
    public partial class RootMenu : System.Web.UI.UserControl
    {
        static Logger logger = LogManager.GetLogger("MyClass");
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