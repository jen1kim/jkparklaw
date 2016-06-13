using System;
using System.Drawing;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiteFrontend;
using SiteAdmin;

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
                
                string engFName = tbFName.Text.Trim();
                string engLName = tbLName.Text.Trim();
                string phone = tbPhone.Text.Trim();
                string email = tbEmail.Text.Trim();
                string counselingType = tbCounselingType.Text.Trim();
              //  if (ddlCounselingType.SelectedValue == "Other")
              //      counselingType = ;
                string counselingDesc = taCounselingDesc.InnerText;

                int id = 0;
                id = FrontEmail.AddNewEmailCounseling("", engFName, engLName, "", "", "", "", "", "",
                   "", "", "", phone, "", email, "", counselingType, counselingDesc);
                if (id > 0)
                {
                    lblMessage.Text = "성공적으로 입력되었습니다.";
                 //   CounselingTable.Visible = false;
                    //send email to customer, lawyer and admin
                   SendEmail();
   }
                else
                {
                    lblMessage.Text = "에러가 발생하였습니다. 잠시 후 다시 시도해 주십시오";
                }

           

        }

        protected void SendEmail()
        {

            
            string engFName = tbFName.Text.Trim();
            string engLName = tbLName.Text.Trim();
            string phone = tbPhone.Text.Trim();
            string email = tbEmail.Text.Trim() ;
            string counselingType = tbCounselingType.Text.Trim();
            string counselingDesc = taCounselingDesc.InnerText;

            string sDetails, sMailHeader, sMailBody, sMailFooter;
            Boolean bSuccess;
            string adminEmail = ConfigurationSettings.AppSettings["AdminEmail"].ToString();
            //string lawyerEmail = ConfigurationSettings.AppSettings["LawyerEmail"].ToString();
            string sEmail1 = email;

            //email to member
            sMailHeader = "<strong>Title: Email Counseling Request</strong>";
            sMailHeader += "<br><br>";

            //details
            sDetails = "Counseling details <br><br>";
            sDetails += "English Name: " + engFName + " " + engLName + "<br>";
            sDetails += "Phone: " + phone + "<br>";
            sDetails += "Email: " + email + "<br><br>";
            sDetails += "Counseling Type: " + counselingType + "<br><br>";
            sDetails += "Counseling Description:<br> " + counselingDesc + "<br>";

            sMailBody = sDetails;
            sMailBody += "<br>";

            sMailFooter = "This e-mail message was sent from a notification-only address that cannot accept incoming e-mail. Please do not reply to this message. <br><br>";
            sMailFooter += "Thank you for requesting. <br><br>";
            sMailFooter += "<a href='www.jkparklaw.com' targe='_blank'>www.jkparklaw.com</a>";

            if (string.IsNullOrEmpty(sEmail1) == false)
            {
                bSuccess = SendMail.SendMailMessage(adminEmail, sEmail1, "Your email counseling request with JKParkLaw.com", sMailHeader + sMailBody + sMailFooter, "HTML", "");
            }

            //email to admin
            //bSuccess = SendMail.SendMailMessage(adminEmail, lawyerEmail, "Counseling request with JKParkLaw.com", sMailHeader + sMailBody + sMailFooter, "HTML", "");
            bSuccess = SendMail.SendMailMessage(adminEmail, adminEmail, "Counseling request with JKParkLaw.com", sMailHeader + sMailBody + sMailFooter, "HTML", "");

        }
    }
}
