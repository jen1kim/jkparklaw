using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKParkLaw.Admin.Controls.Info
{
    public partial class RootMenu : System.Web.UI.UserControl
    {
        private string sectionName;
        private SiteMapNode parentNode = null;
        //private SiteMapNode currentNode = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //SetNavigationMenu();
            //SetRootMenu();
        }

        protected void btLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Admin/Login.aspx");
        }

        public void SetSectionName(string name)
        {
            sectionName = name;
        }


        private bool IsParent(SiteMapNode node)
        {
            foreach (SiteMapNode childNode in node.ChildNodes)
            {
                if (childNode.Title == sectionName)
                {
                    parentNode = node;
                    return true;
                }
            }
            return false;
        }
    }
}