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

namespace JKParkLaw.Email
{
    public partial class Counseling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInsertFields())
            {
                string korName = tbKorName.Text.Trim();
                string engFName = tbFName.Text.Trim();
                string engLName = tbLName.Text.Trim();
                string birthday = tbYear.Text.Trim() + "-" + tbMonth.Text.Trim() + "-" + tbDay.Text.Trim();
                string korZip = tbKorZip1.Text.Trim() + "-" + tbKorZip2.Text.Trim();
                string korAddress = tbKorAddress.Text.Trim();
                string korAddress2 = tbKorAddress2.Text.Trim();

                string address = tbEngAddress.Text.Trim();
                string address2 = tbEngAddress2.Text.Trim();
                string city = tbCity.Text.Trim();
                string state = tbState.Text.Trim();
                string zip = tbZip.Text.Trim();
                string phone1 = tbPhone11.Text.Trim() + "-" + tbPhone12.Text.Trim() + "-" + tbPhone13.Text.Trim();
                string phone2 = "";
                if (string.IsNullOrEmpty( tbPhone21.Text) == false)
                    phone2 = tbPhone21.Text.Trim() + "-" + tbPhone22.Text.Trim() + "-" + tbPhone23.Text.Trim();
                string email = tbEmail1.Text.Trim() + "@" + tbEmail2.Text.Trim();
                string sitePath = ddlSitePath.SelectedValue;
                if (ddlSitePath.SelectedValue == "Other")
                    sitePath = tbSitePath.Text.Trim();
                string counselingType = ddlCounselingType.SelectedValue;
                if (ddlCounselingType.SelectedValue == "Other")
                    counselingType = tbCounselingType.Text.Trim();
                string counselingDesc = taCounselingDesc.InnerText;

                int id = 0;
                id = FrontEmail.AddNewEmailCounseling(korName, engFName, engLName, birthday, korZip, korAddress, korAddress2, address, address2,
                    city, state, zip, phone1, phone2, email, sitePath, counselingType, counselingDesc);
                if (id > 0)
                {
                    lblMessage.Text = "성공적으로 입력되었습니다.";
                    CounselingTable.Visible = false;
                    //send email to customer, lawyer and admin
                    SendEmail();
                }
                else
                {
                    lblMessage.Text = "에러가 발생하였습니다. 잠시 후 다시 시도해 주십시오";
                }

            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInsertFields();
        }

        protected bool ValidateInsertFields()
        {
            if (string.IsNullOrEmpty(tbKorName.Text) == true)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "한글 이름을 입력하세요.";
                return false;
            }

            if (string.IsNullOrEmpty(tbFName.Text) == true || string.IsNullOrEmpty(tbLName.Text) == true)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "영어 이름을 입력하세요.";
                return false;
            }

            if (string.IsNullOrEmpty(tbYear.Text) == true || string.IsNullOrEmpty(tbMonth.Text) == true || string.IsNullOrEmpty(tbDay.Text) == true || CheckBirthDay())
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "생년월일을 정확하게 입력하세요.";
                return false;
            }

            if (!CheckAddress())
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "주소를 정확히 입력하세요.";
                return false;
            }

            if (string.IsNullOrEmpty(tbPhone11.Text) == true || string.IsNullOrEmpty(tbPhone12.Text) == true || string.IsNullOrEmpty(tbPhone13.Text) == true)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "전화번호 1을 입력하세요.";
                return false;
            }

            if (string.IsNullOrEmpty(tbEmail1.Text) == true || string.IsNullOrEmpty(tbEmail2.Text) == true)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "이메일을 입력하세요.";
                return false;
            }

            if (!CheckSitePath())
            {
                return false;
            }

            if (string.IsNullOrEmpty(taCounselingDesc.InnerText) == true)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "상담 신청 내용을 입력하세요.";
                return false;
            }

            return true;
        }

        protected bool CheckSitePath()
        {
            if (ddlSitePath.SelectedValue == "Not Selected" )
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "사이트을 알게 된 경로를 선택하세요.";
                return false;
            }
            if (ddlSitePath.SelectedValue == "Other" && string.IsNullOrEmpty(tbSitePath.Text) == true)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "사이트을 알게 된 기타 경로를 입력하세요.";
                return false;
            }
            if (ddlCounselingType.SelectedValue == "Not Selected" )
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "상담신청 유형을 선택하세요.";
                return false;
            }
            if (ddlCounselingType.SelectedValue == "Other" && string.IsNullOrEmpty(ddlCounselingType.Text) == true)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "기타 상담신청 유형을 입력하세요.";
                return false;
            }
            return true;
        }

        protected bool CheckBirthDay()
        {
            int number;
            if (tbYear.Text.Trim().Length != 4 && int.TryParse(tbYear.Text.Trim(), out number))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "년도를 입력하세요.";
                return false;
            }
            if (int.TryParse(tbMonth.Text.Trim(), out number))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "월을 입력하세요.";
                return false;
            }
            if (int.TryParse(tbDay.Text.Trim(), out number))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "날자를 입력하세요.";
                return false;
            }
            return true;
        }

        protected bool CheckAddress()
        {
            bool korAddress = false;
            if (string.IsNullOrEmpty(tbKorAddress.Text) == true && string.IsNullOrEmpty(tbEngAddress.Text) == true)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "주소를 입력하세요.";
                return false;
            }
            if (string.IsNullOrEmpty(tbKorAddress.Text) == false)
            {
                korAddress = true;
            }

            if (korAddress && (string.IsNullOrEmpty(tbKorZip1.Text) == true || string.IsNullOrEmpty(tbKorZip2.Text) == true))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "한국 주소 우편번호를 입력하세요.";
                return false;
            }

            if (!korAddress && string.IsNullOrEmpty(tbEngAddress.Text) == true )
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "미국 주소를 입력하세요.";
                return false;
            }
            if (!korAddress && (string.IsNullOrEmpty(tbCity.Text) == true || string.IsNullOrEmpty(tbState.Text) == true || string.IsNullOrEmpty(tbState.Text) == true))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "미국 주소 도시, 주, 우편번호를 정확히 입력하세요.";
                return false;
            }

            return true;
        }


        protected void ClearInsertFields()
        {
            tbKorName.Text = "";
            tbFName.Text = "";
            tbLName.Text = "";

            tbYear.Text = "";
            tbMonth.Text = "";
            tbDay.Text = "";

            tbKorAddress.Text = "";
            tbKorAddress2.Text = "";
            tbKorZip1.Text = "";
            tbKorZip2.Text = "";

            tbEngAddress.Text = "";
            tbEngAddress2.Text = "";
            tbCity.Text = "";
            tbState.Text = "";
            tbZip.Text = "";

            tbPhone11.Text = "";
            tbPhone12.Text = "";
            tbPhone13.Text = "";
            tbPhone21.Text = "";
            tbPhone22.Text = "";
            tbPhone23.Text = "";

            tbEmail1.Text = "";
            tbEmail2.Text = "";

            ddlSitePath.Items.FindByValue("Not Selected").Selected = true;
            tbSitePath.Text = "";
            ddlCounselingType.Items.FindByValue("Not Selected").Selected = true;
            tbCounselingType.Text = "";

            taCounselingDesc.InnerText = "";            

        }

        protected void SendEmail()
        {

            string korName = tbKorName.Text.Trim();
            string engFName = tbFName.Text.Trim();
            string engLName = tbLName.Text.Trim();
            string birthday = tbYear.Text.Trim() + "-" + tbMonth.Text.Trim() + "-" + tbDay.Text.Trim();
            string korZip = tbKorZip1.Text.Trim() + "-" + tbKorZip2.Text.Trim();
            string korAddress = tbKorAddress.Text.Trim();
            string korAddress2 = tbKorAddress2.Text.Trim();

            string address = tbEngAddress.Text.Trim();
            string address2 = tbEngAddress2.Text.Trim();
            string city = tbCity.Text.Trim();
            string state = tbState.Text.Trim();
            string zip = tbZip.Text.Trim();
            string phone1 = tbPhone11.Text.Trim() + "-" + tbPhone12.Text.Trim() + "-" + tbPhone13.Text.Trim();
            string phone2 = "";
            if (string.IsNullOrEmpty(tbPhone21.Text) == false)
                phone2 = tbPhone21.Text.Trim() + "-" + tbPhone22.Text.Trim() + "-" + tbPhone23.Text.Trim();
            string email = tbEmail1.Text.Trim() + "@" + tbEmail2.Text.Trim();
            string sitePath = ddlSitePath.SelectedValue;
            if (ddlSitePath.SelectedValue == "Other")
                sitePath = tbSitePath.Text.Trim();
            string counselingType = ddlCounselingType.SelectedValue;
            if (ddlCounselingType.SelectedValue == "Other")
                counselingType = tbCounselingType.Text.Trim();
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
            sDetails += "Korean Name: " + korName + "<br>";
            sDetails += "English Name: " + engFName+" " + engLName+"<br>";
            sDetails += "Birthday: " + birthday + "<br>";
            sDetails += "Korean address: " + korAddress+" "+ korAddress2 + "<br>";
            sDetails += "Korean Zip: " + korZip + "<br><br>";

            sDetails += "Address: " + address + " " + address2 + "<br>";
            sDetails += "City: " + city + "<br>";
            sDetails += "State: " + state + "<br>";
            sDetails += "Zip: " + zip + "<br>";
            sDetails += "Phone: " + phone1+" " +phone2 + "<br>";
            sDetails += "Email: " + email + "<br><br>";

            sDetails += "Path to know this site: " + sitePath + "<br>";
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
