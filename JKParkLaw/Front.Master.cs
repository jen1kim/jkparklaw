using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;

namespace JKParkLaw
{
    public partial class Front : System.Web.UI.MasterPage
    {
        static Logger logger = LogManager.GetLogger("MyClass");//LogManager.GetLogger("MyClass");

        private int _categoryID = 0;
        protected string _AppPath;
        protected string _StylePath;
        protected string _HeaderStyle="sub";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Set variables
            _AppPath = Request.ApplicationPath;
            _StylePath = _AppPath + "App_Themes/" + Page.Theme + "/";
        }

        public int CategoryID
        {
            set
            {
                _categoryID = value;
            }
        }

        public string AppPath
        {
            get { return _AppPath; }
        }

        public string HeaderStyle
        {
            set
            {
                _HeaderStyle = value;
            }
            get { return _HeaderStyle; }
        }

        public string StylePath
        {
            get { return _StylePath; }
        }

        public void SetTitle(string str)
        {
            //MainPageTitle.Text = str;
            //PageTitlelbl.Text = str;
        }

    }
}
