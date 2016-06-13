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
    public partial class CreateMember : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Add Member");
            Master.SetSubSectionName("Add Member");
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            JoinedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        protected void tbMemberID_TextChanged(object sender, EventArgs e)
        {
            tbCheckResult.Text = "Check Member ID First";
            btnCheckMemberID.ImageUrl = "~/Images/icons/verify.gif";
            MemberIDOK.Value = "0";
            btnCheckMemberID.Focus();
            
        }

        protected void btnCheckMemberID_Click(object sender, EventArgs e)
        {
            CheckMemberID();
            ScriptManager.GetCurrent(this).SetFocus(this.btnCheckMemberID);
        }

        protected void CheckMemberID()
        {
            //logger.Debug("CheckMemberID fired");
            if (tbMemberID.Text.Length >= 3)
            {
                bool exist = SiteAdmin.AdminMembers.CheckMemberID(tbMemberID.Text.Trim());
                //logger.Debug("exist - "+exist);
                if (exist)
                {
                    tbCheckResult.Text = "The member id is already in use.";
                    btnCheckMemberID.ImageUrl = "~/Images/icons/error.gif";
                    MemberIDOK.Value = "0";
                }
                else
                {
                    tbCheckResult.Text = "The member id is available.";
                    btnCheckMemberID.ImageUrl = "~/Images/icons/ok.gif";
                    MemberIDOK.Value = "1";                    
                }
            }
            else
            {
                tbCheckResult.Text = "The member id must be longer than 3.";
                btnCheckMemberID.ImageUrl = "~/Images/icons/error.gif";
                MemberIDOK.Value = "0";
            }
        }

        protected void btnResister_Click(object sender, EventArgs e)
        {
            bool exist = SiteAdmin.AdminMembers.CheckMemberID(tbMemberID.Text.Trim());
            if (exist)
            {
                tbCheckResult.Text = "The member id is already in use";
                btnCheckMemberID.ImageUrl = "~/Images/icons/error.gif";
                MemberIDOK.Value = "0";
                return;
            }
            if (ValidateRequiredFields())
            {
                try
                {
                    string memberId = tbMemberID.Text.Trim();
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

                    int id = SiteAdmin.AdminMembers.CreateMemberInfo(memberId, password, email, fname, lname,
                        korName, phone, address, address2, city, state, zip, progressStatus, cbActiveStatus.Checked, joined);

                    if (id > 0)
                    {
                        lblMessage.Text = "Member information is successfully added.";
                        registerTable.Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "Member information is not successfully added.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Member information is not successfully added. " + ex.Message;
                }
            }
        }

        protected bool ValidateRequiredFields()
        {
            if (MemberIDOK.Value == "0")
            {
                lblMessage.Text = "Please check the member id.";
                return false;
            }

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
            if (String.IsNullOrEmpty(JoinedDate.Text) == true || !DateTime.TryParse(JoinedDate.Text,out joined))
            {
                lblMessage.Text = "Please enter a valid joined date.";
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
