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
    public partial class Counselings : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");
        protected void Page_Load(object sender, EventArgs e)
        {

            Master.SetSectionName("Email Counselings");
            Master.SetSubSectionName("Counselings List");

            if (!IsPostBack)
            {
                BindCounselings();
            }
        }

        private void BindCounselings()
        {
            try
            {
                DataTable counselings = AdminEmail.GetCounselings();
                CounselingsGrid.DataSource = counselings;
                CounselingsGrid.DataBind();
                //logger.Debug("contents - " + contents.Rows.Count);
            }
            catch (Exception ex)
            {
                logger.Error("BindContents Exception - " + ex.Message);
            }
        }

        protected void CounselingsGrid_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            CounselingsGrid.PageIndex = e.NewPageIndex;
            DataTable counselings = AdminEmail.GetCounselings();
            CounselingsGrid.DataSource = counselings;
            CounselingsGrid.DataBind();
        }

        protected void CounselingsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int counselingID = int.Parse(CounselingsGrid.Rows[e.RowIndex].Cells[1].Text);

            bool deleted = AdminEmail.DeleteCounseling(counselingID);

            if (deleted) lblMessage.Text = "Sucessfully deleted";
            else lblMessage.Text = "Deletion error. Please try again.";

            BindCounselings();
        }

    }
}
