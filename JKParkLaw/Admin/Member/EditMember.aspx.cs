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
using SiteAdmin;
using NLog;


namespace JKParkLaw.Admin.Member
{
    public partial class EditMember : System.Web.UI.Page
    {
        protected string _memberID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Status");
            Master.SetSubSectionName("Edit Member");

            if (Request.QueryString["MemberID"] != null)
            {
                _memberID = Request.QueryString["MemberID"].ToString();
            }
            else
            {
                Response.End();
            }

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(_memberID) == false)
                {
                    BindData();
                }
            }
        }

        protected void BindData()
        {
            DataTable member = AdminMembers.GetMemberInfoByMemberID( _memberID);
            if (member.Rows.Count > 0)
            {
                DataRow row = member.Rows[0];
                lblMemberID.Text = row["MemberID"].ToString();
                tbPassword.Text = row["Password"].ToString();
                tbPasswordRe.Text = row["Password"].ToString();
                tbFName.Text = row["FName"].ToString();
                tbLName.Text = row["LName"].ToString();
                tbKorName.Text = row["KorName"].ToString();
                tbEmail.Text = row["Email"].ToString();
                tbPhone.Text = row["Phone"].ToString();
                tbAddress.Text = row["Address"].ToString();
                tbAddress2.Text = row["Address2"].ToString();
                tbCity.Text = row["City"].ToString();
                tbState.Text = row["State"].ToString();
                tbZip.Text = row["Zip"].ToString();

                ListItem status = ddlProgressStatus.Items.FindByValue(row["ProgressStatus"].ToString());
                if (status != null) status.Selected = true;

                cbActiveStatus.Checked = bool.Parse(row["ActiveStatus"].ToString());

                JoinedDate.Text = DateTime.Parse(row["Joined"].ToString()).ToString("MM/dd/yyyy");
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            bool exist = SiteAdmin.AdminMembers.CheckMemberID(lblMemberID.Text.Trim());
            if (!exist)
            {
                lblMessage.Text = "The member id does not exist";
                return;
            }
            if (ValidateRequiredFields())
            {
                try
                {
                    string memberId = lblMemberID.Text.Trim();
                    string password = tbPassword.Text.Trim();
                    string fname = tbFName.Text.Trim();
                    string lname = tbLName.Text.Trim();
                    string korName = tbKorName.Text.Trim();
                    string email = tbEmail.Text.Trim();
                    string phone = tbPhone.Text.Trim();
                    string address = tbAddress.Text.Trim();
                    string address2 = tbAddress2.Text.Trim();
                    string city = tbCity.Text.Trim();
                    string state = tbState.Text.Trim();
                    string zip = tbZip.Text.Trim();
                    string progressStatus = ddlProgressStatus.SelectedValue.Trim();
                    DateTime joined = DateTime.Parse(JoinedDate.Text);

                    int id = SiteAdmin.AdminMembers.UpdateMemberInfo(memberId, password, email, fname, lname,
                        korName, phone, address, address2, city, state, zip, progressStatus, cbActiveStatus.Checked, joined);

                    if (id > 0)
                    {
                        lblMessage.Text = "Member information is successfully updated.";
                        registerTable.Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "Member information is not successfully updated.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Member information is not successfully updated. " + ex.Message;
                }
            }
        }

        protected bool ValidateRequiredFields()
        {

            if (!ValidatePassword())
            {
                lblMessage.Text = "Please enter correct password.";
                return false;
            }

            if (String.IsNullOrEmpty(tbFName.Text) == true)
            {
                lblMessage.Text = "Please enter first name.";
                return false;
            }

            if (String.IsNullOrEmpty(tbLName.Text) == true)
            {
                lblMessage.Text = "Please enter last name.";
                return false;
            }
            DateTime joined;
            if (String.IsNullOrEmpty(JoinedDate.Text) == true || !DateTime.TryParse(JoinedDate.Text, out joined))
            {
                lblMessage.Text = "Please enter a valid join date.";
                return false;
            }

            return true;
        }

        protected bool ValidatePassword()
        {
            if (String.IsNullOrEmpty(tbPassword.Text.Trim()) == false &&
                String.Equals(tbPassword.Text.Trim(), tbPasswordRe.Text.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
