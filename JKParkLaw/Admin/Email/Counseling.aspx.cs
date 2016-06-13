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

namespace JKParkLaw.Admin.Email
{
    public partial class Counseling : System.Web.UI.Page
    {
        protected int _counselingID;
        DataTable counseling;
        protected void Page_Load(object sender, EventArgs e)
        {

            Master.SetSectionName("Email Counselings");
            Master.SetSubSectionName("Counseling Details");

            if (Request.QueryString["CounselingID"] != null)
                int.TryParse(Request.QueryString["CounselingID"].ToString(), out _counselingID);

            if (!IsPostBack)
            {
                if (_counselingID > 0)
                {
                    counseling = AdminEmail.GetCounseling(_counselingID);

                    BindData();
                }
            }
        }

        protected void BindData()
        {
            if (counseling.Rows.Count > 0)
            {
                DataRow row = counseling.Rows[0];
                hdlCounselingID.Value = row["CounselingID"].ToString();
                lblKorName.Text = row["KorName"].ToString();
                lblFName.Text = row["EngFName"].ToString();
                lblLName.Text = row["EngLName"].ToString();
                lblBirthday.Text = row["Birthday"].ToString();
                lblKorZip.Text = row["KorZip"].ToString();
                lblKorAddress.Text = row["KorAddress"].ToString();
                lblKorAddress2.Text = row["KorAddress2"].ToString();
                lblEngAddress.Text = row["Address"].ToString();
                lblEngAddress2.Text = row["Address2"].ToString();
                lblCity.Text = row["City"].ToString();
                lblState.Text = row["State"].ToString();
                lblZip.Text = row["Zip"].ToString();
                lblPhone1.Text = row["Phone1"].ToString();
                lblPhone2.Text = row["Phone2"].ToString();
                lblEmail.Text = row["Email"].ToString();
                lblSitePath.Text = row["SitePath"].ToString();
                lblCounselingType.Text = row["CounselingType"].ToString();
                taCounselingDesc.InnerText = row["CounselingDesc"].ToString();
                bool processed = false;
                bool.TryParse(row["Processed"].ToString(), out processed);
                cbProcessed.Checked = processed;

                if (row["ProcessedDate"] != null)
                {
                    lblProcessedDate.Text = row["ProcessedDate"].ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminEmail.UpdateCounselingStatus(_counselingID,cbProcessed.Checked);

            _counselingID = int.Parse(hdlCounselingID.Value);
            counseling = AdminEmail.GetCounseling(_counselingID);
            BindData();
        }
    }
}
