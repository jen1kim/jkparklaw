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
    public partial class AddContent : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        private int sectionID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Add Content");
            Master.SetSubSectionName("Add New Content");
            DataTable dtSections = AdminSections.GetSections();

            if (dtSections.Rows.Count > 0)
            {
                DataRow r = dtSections.Rows[0];
                sectionID = int.Parse(r["CategoryID"].ToString());
                lblSelectedSection.Text = r["CategoryName"].ToString();
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

        protected void SectionsDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SectionsDD.SelectedIndex != -1 && SectionsDD.SelectedValue != "0")
            {
                //Response.Redirect("Categories.aspx?SectionID=" + SectionsDD.SelectedValue);
                int.TryParse(SectionsDD.SelectedValue,out sectionID);

                DataTable dtSections = AdminSections.GetSection(sectionID);

                if (dtSections.Rows.Count > 0)
                {
                    DataRow r = dtSections.Rows[0];
                    lblSelectedSection.Text = r["CategoryName"].ToString();
                }

                BindData();
            }

            selectedCategory.Text = "";
            hdnCategoryID.Value = "";
            lblSelectedCategory.Text = "";
        }

        private void BindData()
        {
            DataTable categories = AdminCategories.GetCategories(sectionID);
            CategoryGrid.DataSource = categories;
            CategoryGrid.DataBind();
            ModifiedDate.Text = DateTime.Now.ToString();
            CreatedDate.Text = DateTime.Now.ToString();
        }


        protected void CategoryGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            GridViewRow gvRow = CategoryGrid.SelectedRow;
            int categoryID = int.Parse(gvRow.Cells[1].Text);
            DataTable categoryTable = AdminCategories.GetCategory(categoryID);
            if (categoryTable.Rows.Count > 0)
            {
                hdnCategoryID.Value = categoryID.ToString();
                DataRow row = categoryTable.Rows[0];
                selectedCategory.Text = row["CategoryName"].ToString();
                lblSelectedCategory.Text = row["CategoryName"].ToString();
            }
        }


        protected bool ValidateInsertFields()
        {

            if (string.IsNullOrEmpty(hdnCategoryID.Value) == true)
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

        protected void AddNewContent_Click(object sender, EventArgs e)
        {
            if (ValidateInsertFields())
            {
                int categoryID = int.Parse(hdnCategoryID.Value);
                string contentTitle = tbContentTitle.Text;
                string contentSmallDesc = SmallDesc.InnerText;
                string contentDesc = BigDescription.Value;
                bool hidden = cbContentHidden.Checked;
                DateTime modifiedDate = DateTime.Parse(ModifiedDate.Text);
                DateTime createdDate = DateTime.Parse(CreatedDate.Text);

                int contentID = 0;
                contentID = AdminContents.AddNewContent(contentTitle, contentSmallDesc, contentDesc, hidden, createdDate, modifiedDate);

                if (contentID > 0)
                {
                    AdminContents.AddContentToCategory(contentID, categoryID);
                    lblMessage.Text = "Content was successfully added to "+lblSelectedCategory.Text+"!";
                    ClearInsertFields();
                }
                else
                {
                    lblMessage.Text = "Add new content error.";
                }
            }
        }

        protected void ClearInsertFields()
        {
            tbContentTitle.Text = "";
            SmallDesc.InnerText = "";
            BigDescription.Value = "";
            cbContentHidden.Checked = false;
            ModifiedDate.Text = DateTime.Now.ToString();
            CreatedDate.Text = DateTime.Now.ToString();
        }
    }
}
