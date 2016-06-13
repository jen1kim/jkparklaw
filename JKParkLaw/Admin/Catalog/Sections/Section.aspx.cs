using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SiteAdmin;

namespace JKParkLaw.Admin.Catalog.Sections
{
    public partial class Section : System.Web.UI.Page
    {
        private int sectionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Master.CheckLogedIn();
            Master.SetSectionName("Sections - Master");
            Master.SetSubSectionName("Edit Section");
            if (String.IsNullOrEmpty(Request.QueryString["SectionID"]) == true)
            {
                Response.End();
            }
            else
            {
                sectionID = int.Parse(Request.QueryString["SectionID"]);
            }

            if (!IsPostBack) PopulateDetails();

        }

        private void PopulateDetails()
        {
            DataTable sectionTable = AdminSections.GetSection(sectionID);
            DataRow sectionRow = sectionTable.Rows[0];
            SectionName.Text = sectionRow["CategoryName"].ToString();
            SectionDesc.Text = sectionRow["CategoryDesc"].ToString();
            txtorder.Text = sectionRow["CategoryOrder"].ToString();
            SectionAvailable.Checked = (bool)sectionRow["CategoryAvailable"];

        }

        protected void UpdateDetails_Click(object sender, EventArgs e)
        {
            string sectionName = SectionName.Text;
            string sectionDesc = SectionDesc.Text;
            string sectionorder = txtorder.Text;
            bool sectionAvailable = SectionAvailable.Checked;
            if (sectionName.Length >= 3 && sectionDesc.Length >= 3)
            {
                AdminSections.UpdateSectionDetails(sectionID, sectionName, sectionAvailable, sectionDesc, Convert.ToInt32(sectionorder));
            }

            Response.Redirect("Sections.aspx");
        }

    }
}
