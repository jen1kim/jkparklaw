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

namespace JKParkLaw.Admin.Catalog.Sections
{
    public partial class Sections : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Sections - Master");
            Master.SetSubSectionName("Master Sections List");

            if (!IsPostBack)
            {
            }
        }

        protected void SectionsList_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            SectionsList.PageIndex = e.NewPageIndex;
            SectionsList.DataBind();
        }

        protected void btnAddNewSection_Click(object sender, EventArgs e)
        {
            string sectionName = SectionName.Text;
            string sectionDesc = SectionDesc.Text;
            int sectionID = 0;
          //  logger.Debug("Add New Section: " + sectionName.Length + " " + sectionDesc.Length);
            if (sectionName.Length >= 3 && sectionDesc.Length >= 3)
            {
              //  logger.Debug("Add New Section: "+sectionName+" "+sectionDesc);
                try
                {
                    sectionID = AdminSections.AddNewSection(sectionName, sectionDesc);
                }
                catch (Exception ex)
                {
                    logger.Error("Add New Section Error: " + ex.Message);
                }
                SectionName.Text = "";
                SectionDesc.Text = "";
            }
            SectionsList.DataBind();

        }

    }
}
