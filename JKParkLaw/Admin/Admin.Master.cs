using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKParkLaw.Admin
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected string _AppPath;
        protected string _StylePath;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Cache Control
            Response.CacheControl = "no-cache";
            //Set variables
            _AppPath = Request.ApplicationPath;
            _StylePath = _AppPath + "App_Themes/" + Page.Theme + "/";
        }

        public string AppPath
        {
            get { return _AppPath; }
        }

        public string StylePath
        {
            get { return _StylePath; }
        }

        public void SetSectionName(string name)
        {
            //TitleTag.Text = name;
            SectionNamelbl.Text = name;
            LeftMenuuc.SetSectionName(name);
            //RootMenuUC.SetSectionName(name);
        }

        public void SetSubSectionName(string name)
        {
            //TitleTag.Text = name;
            SubSectionName.Text = name;
        }

        public static string RootUrl
        {
            get
            {
                HttpContext context = HttpContext.Current;
                string executionPath = context.Request.ApplicationPath;
                return string.Format("{0}://{1}{2}", context.Request.Url.Scheme,
                context.Request.Url.Authority,
                executionPath.Length == 1 ? string.Empty : executionPath);
            }
        }
    }
}
