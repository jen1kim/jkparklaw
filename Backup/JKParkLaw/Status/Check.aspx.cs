using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKParkLaw.Controls.News;
using SiteFrontend;


namespace JKParkLaw.Status
{
    public partial class Check : System.Web.UI.Page
    {
        protected string _memberID;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                string memberID = tbMemberID.Text.Trim();
                string password = tbPassword.Text.Trim();
                DataTable member = FrontMembers.GetMemberInfo(memberID, password);
                if (member.Rows.Count > 0)
                {
                    _memberID = memberID;
                    BindData();
                    loginDiv.Visible = false;
                    progresslistDiv.Visible = true;
                }
            }
        }

        protected void BindData()
        {
            DataTable progresses = FrontProgresses.GetProgressList(_memberID);
            ProgressRepeater.DataSource = progresses;
            ProgressRepeater.DataBind();
        }

        protected bool ValidateFields()
        {
            if (string.IsNullOrEmpty(tbMemberID.Text) == true)
            {
                lblMessage.Text = "Please insert memberid.";
                return false;
            }
            if (string.IsNullOrEmpty(tbPassword.Text) == true)
            {
                lblMessage.Text = "Please insert password.";
                return false;
            }
            return true;
        }
    }
}
