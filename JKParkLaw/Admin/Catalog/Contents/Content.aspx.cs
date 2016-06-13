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


namespace JKParkLaw.Admin.Catalog.Contents
{
    public partial class Content : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        private int contentID;
        //private int sectionID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Contents");
            Master.SetSubSectionName("Edit");
            DataTable dtSections = AdminSections.GetSections();

            if (dtSections.Rows.Count > 0)
            {
                //DataRow r = dtSections.Rows[0];
                //sectionID = int.Parse(r["CategoryID"].ToString());
                //lblSelectedSection.Text = r["CategoryName"].ToString();
            }

            if (Request.QueryString["ContentID"] != null)
            {
                int.TryParse(Request.QueryString["ContentID"].ToString(), out contentID);
            }
            else
            {
                Response.End();
            }

            if (!IsPostBack)
            {
                BindData();
            }

        }

        private void BindData()
        {
            DataTable contents = AdminContents.GetContent(contentID);
            if (contents.Rows.Count > 0)
            {
                DataRow r = contents.Rows[0];
                hdnContentID.Value = r["ContentID"].ToString();
                tbContentTitle.Text = r["ContentTitle"].ToString();
                SmallDesc.InnerText = r["ContentSmallDesc"].ToString();
                BigDescription.Value = r["ContentDesc"].ToString();
                cbContentHidden.Checked =  r["Hidden"] == null? false : bool.Parse(r["Hidden"].ToString());
                ModifiedDate.Text = r["Modified"].ToString();
                CreatedDate.Text = r["Created"].ToString();
            }
        }


        protected bool ValidateUpdateFields()
        {

            if (string.IsNullOrEmpty(hdnContentID.Value) == true)
            {
                lblMessage.Text = "Please select the category first.";
                return false;
            }

            if (string.IsNullOrEmpty(tbContentTitle.Text) == true)
            {
                lblMessage.Text = "Please insert content title.";
                return false;
            }

            return true;
        }

        protected void UpdateContent_Click(object sender, EventArgs e)
        {
            if (ValidateUpdateFields())
            {
                int contentID = int.Parse(hdnContentID.Value);
                string contentTitle = tbContentTitle.Text;
                string contentSmallDesc = SmallDesc.InnerText;
                string contentDesc = BigDescription.Value;
                bool hidden = cbContentHidden.Checked;
                DateTime modifiedDate = DateTime.Parse(ModifiedDate.Text);
                DateTime createdDate = DateTime.Parse(CreatedDate.Text);

                try
                {
                    contentID = AdminContents.UpdateContent(contentID, contentTitle, contentSmallDesc, contentDesc, hidden, createdDate, modifiedDate);

                    if (contentID > 0)
                    {
                        lblMessage.Text = "Content was successfully updated.";

                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Content Update Error: "+ex.Message);
                    lblMessage.Text = "Content Update Error: " + ex.Message;
                }
            }
        }


    }
}
