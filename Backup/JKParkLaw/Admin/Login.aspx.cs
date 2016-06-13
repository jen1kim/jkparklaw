using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiteAdmin;

namespace JKParkLaw.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ADMIN_USERID"] = null;
            Session["ADMIN_USERLEVEL"] = null;
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {
            string sUserID = txtMid.Text;
            string sPwd = txtMpwd.Text;

            if (string.IsNullOrEmpty(sUserID) == false && string.IsNullOrEmpty(sPwd) == false)
            {
                DataTable users = AdminUsers.SearchAdminUser(sUserID, sPwd);

                if (users.Rows.Count > 0)
                {
                    Session["ADMIN_USERID"] = users.Rows[0]["UserID"].ToString();
                    Session["ADMIN_USERLEVEL"] = users.Rows[0]["UserLevel"].ToString();


                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //RegisterStartupScript("", "<script>alert(' Incorrect password or ID ')</script>");
                    ClientScript.RegisterStartupScript(GetType(), "", "<script>alert(' Incorrect password or ID ')</script>");

                }
            }
            else
            {
                //RegisterStartupScript("", "<script>alert(' Incorrect password or ID ')</script>");
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert(' Incorrect password or ID ')</script>");

            }
        }
    }
}
