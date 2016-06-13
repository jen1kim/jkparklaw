using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKParkLaw.Admin.Controls.Info
{
    public partial class LeftMenu : System.Web.UI.UserControl
    {
        private string sectionName;
        private TreeNode currentNode;
        private TreeNode parentNode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ADMIN_USERID"] == null || Session["ADMIN_USERLEVEL"] == null || !CheckAdminLevel())
                {
                    Response.Redirect("~/Admin/Login.aspx");
                }
            }
        }

        public void SetSectionName(string name)
        {
            sectionName = name;
        }

        private void CheckSelectedNodes(TreeNodeCollection nodes, string selected)
        {
            foreach (TreeNode node in nodes)
            {

                if (node.Text == selected)
                {
                    currentNode = node;
                    if (node.Parent != null)
                    {
                        parentNode = node.Parent;
                    }
                    return;
                }
                node.Expand();
                CheckSelectedNodes(node.ChildNodes, selected);
                node.Collapse();
            }
        }

        public JKParkLaw.Admin.Master MasterPage
        {
            get { return (JKParkLaw.Admin.Master)Page.Master; }
        }

        protected void LeftSiteMap_DataBound(object sender, EventArgs e)
        {

            CheckSelectedNodes(LeftSiteMap.Nodes, sectionName);
            LeftSiteMap.Nodes[0].Expand();
            if (currentNode != null)
            {
                currentNode.Selected = true;
                currentNode.ExpandAll();
            }
            if (parentNode != null) parentNode.Expand();

        }

        protected bool CheckAdminLevel()
        {
            string userlevel = Session["ADMIN_USERLEVEL"].ToString();
            if (userlevel == "1")
            {
                return true;
            }
            return false;
        }
    }
}