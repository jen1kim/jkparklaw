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
    public partial class Categories : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        private int sectionID;
        //private int categoryID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Categories");
            Master.SetSubSectionName("Categories List");
            if (String.IsNullOrEmpty(Request.QueryString["SectionID"]) == true)
            {
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
            }
            else
            {
                sectionID = int.Parse(Request.QueryString["SectionID"]);
                DataTable dtSections = AdminSections.GetSection(sectionID);

                if (dtSections.Rows.Count > 0)
                {
                    DataRow r = dtSections.Rows[0];
                    lblSelectedSection.Text = r["CategoryName"].ToString();
                }
                else
                {
                    Response.End();
                }
            }

            if (!IsPostBack)
            {
                BindData();
            }

        }

        protected void CategoryGrid_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            CategoryGrid.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void SectionsDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SectionsDD.SelectedIndex != -1 && SectionsDD.SelectedValue != "0")
            {
                Response.Redirect("Categories.aspx?SectionID=" + SectionsDD.SelectedValue);
            }
        }

        private void BindData()
        {
            DataTable categories = AdminCategories.GetCategories(sectionID);
            CategoryGrid.DataSource = categories;
            CategoryGrid.DataBind();
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
                btnDeleteCategory.Enabled = true;
                CategoryEdit.Visible = true;
                tbCategoryName.Text = row["CategoryName"].ToString();
                tbCategoryDesc.Text = row["CategoryDesc"].ToString();
                cbCategoryAvailable.Checked = bool.Parse(row["CategoryAvailable"].ToString());

                AddNewCategoryDiv.Visible = false;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateAddFields())
            {
                string categoryName = CategoryName.Text;
                string categoryDesc = CategoryDesc.Text;
                int parentCategoryID = sectionID;
                int categoryID = 0;
                categoryID = AdminCategories.AddNewCategory(categoryName, categoryDesc, sectionID, parentCategoryID);
                CategoryName.Text = "";
                CategoryDesc.Text = "";

                BindData();                
            }
            
        }

        protected bool ValidateAddFields()
        {
            if (sectionID <= 0)
            {
                lblMessage.Text = "Please select the master section first.";
                return false;
            }

            if (string.IsNullOrEmpty(CategoryName.Text) == true)
            {
                lblMessage.Text = "Please insert category name.";
                return false;
            }

            if (string.IsNullOrEmpty(CategoryDesc.Text) == true)
            {
                lblMessage.Text = "Please insert category desc.";
                return false;
            }
            return true;
        }

        protected void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hdnCategoryID.Value) == false)
            {
                int categoryID = int.Parse(hdnCategoryID.Value);
                AdminCategories.DeleteCategory(categoryID);
                BindData();
                CategoryEdit.Visible = false;
                lblMessage.Text = "Category was successfully deleted. ";
            }
            else
            {
                lblMessage.Text = "Node is not selected.";
            }
        }


        protected void UpdateDetails_Click(object sender, EventArgs e)
        {
            string categoryName = tbCategoryName.Text;
            string categoryDesc = tbCategoryDesc.Text;
            bool categoryAvailable = cbCategoryAvailable.Checked;
            int categoryID = int.Parse(hdnCategoryID.Value);
            if (categoryName.Length >= 3 && categoryID > 0)
            {
                AdminCategories.UpdateCategoryDetails(categoryID, categoryName, categoryAvailable, categoryDesc);
                CategoryEdit.Visible = false;
                AddNewCategoryDiv.Visible = true;
                BindData();
                lblMessage.Text = "Category was successfully updated. ";
            }
            else
            {
                lblMessage.Text = "Category Update Error: ";
            }
        }
    }
}
