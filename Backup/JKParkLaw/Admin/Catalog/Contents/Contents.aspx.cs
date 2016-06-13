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
    public partial class Contents : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        private int sectionID;
        private int _categoryID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Contents");
            Master.SetSubSectionName("Contents List");

            if (Request.QueryString["SectionID"] != null)
            {
                int.TryParse(Request.QueryString["SectionID"].ToString(), out sectionID);
            }

            if (sectionID > 0)
            {
                DataTable dtSections = AdminSections.GetSection(sectionID);
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
                int.TryParse(SectionsDD.SelectedValue, out sectionID);
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
        }

        private void BindData()
        {
            DataTable categories = AdminCategories.GetCategories(sectionID);
            CategoryGrid.DataSource = categories;
            CategoryGrid.DataBind();

            BindContents(0);
        }


        protected void CategoryGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            GridViewRow gvRow = CategoryGrid.SelectedRow;
            _categoryID = int.Parse(gvRow.Cells[1].Text);
            DataTable categoryTable = AdminCategories.GetCategory(_categoryID);
            if (categoryTable.Rows.Count > 0)
            {
                hdnCategoryID.Value = _categoryID.ToString();
                DataRow row = categoryTable.Rows[0];
                selectedCategory.Text = row["CategoryName"].ToString();
                //lblSelectedCategory.Text = row["CategoryName"].ToString();
            }
            //logger.Debug("categoryID - "+categoryID.ToString());
            BindContents(_categoryID);
        }

        protected void ContentGrid_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            ContentGrid.PageIndex = e.NewPageIndex;
            if(hdnCategoryID.Value != null)
            _categoryID = int.Parse(hdnCategoryID.Value);

            BindContents(_categoryID);
        }

        private void BindContents(int categoryID)
        {
            try
            {
                DataTable contents = AdminContents.GetContents(categoryID);
                ContentGrid.DataSource = contents;
                ContentGrid.DataBind();
                //logger.Debug("contents - " + contents.Rows.Count);
            }
            catch (Exception ex)
            {
                logger.Error("BindContents Exception - " + ex.Message);
            }
        }


        protected void ContentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int contentID = int.Parse(ContentGrid.Rows[e.RowIndex].Cells[1].Text);

            logger.Debug("deleting contents - " + contentID);

            AdminContents.DeleteContent(contentID);

            logger.Debug("binding contents - " + _categoryID + " " + hdnCategoryID.Value);
            int.TryParse(hdnCategoryID.Value, out _categoryID);
            BindContents(_categoryID);
        }

        protected void ContentGrid_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //logger.Debug("content deleted redirecting - ");
            //Response.Redirect("Contents.aspx?SectionID="+sectionID);
        }

    }
}
