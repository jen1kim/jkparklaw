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
using SiteFrontend;
using NLog;
using JKParkLaw.Controls.Categories;

namespace JKParkLaw.Categories
{
    public partial class Category : System.Web.UI.Page
    {
        protected int _sectionID = 0;
        protected string _sectionName;
        protected int _categoryID = 0;
        protected int _PcategoryID = 0;
        protected string _categoryName;
        protected int _contentID = 0;
        protected int _subCategoriesCount = 0;
        protected int _pageID = 0;
        protected int _topProductsCount = 0;
        protected DataRow _categoryRow;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(Request.QueryString["CategoryID"]) == false)
            {
                if (int.TryParse(Request.QueryString["CategoryID"], out _categoryID) == false)
                {
                    Response.Redirect("/Errors/Error.aspx");
                }
            }
            else
            {
                Response.Redirect("/Errors/Error.aspx");
            }


            if (String.IsNullOrEmpty(Request.QueryString["ContentID"]) == false)
            {
                bool parsed = int.TryParse(Request.QueryString["ContentID"], out _contentID);
                if (!parsed) _contentID = 0;
            }

            SetCategryRow();

            int.TryParse(Request.QueryString["CategoryID"], out _PcategoryID);

            _subCategoriesCount = FrontSections.CountSubCategoriesInCategory(_categoryID);

            if (_subCategoriesCount > 0)
            {
                DataTable categories = FrontSections.GetSubCategories(_categoryID);
                if (categories.Rows.Count > 0)
                {
                    DataRow row = categories.Rows[0];
                    int.TryParse(row["CategoryID"].ToString(), out _categoryID);

                    if (_categoryID > 0)
                    {
                        SetCategryRow();

                        ContentsListing uc = (ContentsListing)Page.LoadControl("~/Controls/Categories/ContentsListing.ascx");
                        CategoryPlaceHolder.Controls.Add(uc);
                    }
                }
               // CategoryListing uc5 = (CategoryListing)Page.LoadControl("~/Controls/Categories/CategoryListing.ascx");
              // CategoryPlaceHolder.Controls.Add(uc5);
            }
            else
            {
                ContentsListing uc = (ContentsListing)Page.LoadControl("~/Controls/Categories/ContentsListing.ascx");
                CategoryPlaceHolder.Controls.Add(uc);
            }

            Master.CategoryID = _categoryID;
        }

        private void SetCategryRow()
        {
            DataTable dt = SiteFrontend.FrontSections.GetSection(_categoryID); 
            if (dt.Rows.Count > 0)
            {
                _categoryRow = dt.Rows[0];
                _categoryName = _categoryRow["CategoryName"].ToString();

                int sectionID = 0;


               
                int.TryParse(_categoryRow["SectionID"].ToString(), out sectionID);

               

                if (sectionID > 0)
                {
                    DataTable section = SiteFrontend.FrontSections.GetSection(sectionID);
                    if (section.Rows.Count > 0)
                    {
                        _sectionID = sectionID;
                        _sectionName = section.Rows[0]["CategoryName"].ToString();
                    }
                }
                else
                {
                    _sectionID = _categoryID;
                    _sectionName = _categoryName;
                }
            }
        }

        public int CategoryID
        {
            get { return _categoryID; }
        }

        public string CategoryName
        {
            get { return _categoryName; }
        }

        public int SectionID
        {
            get { return _sectionID; }
        }

        public string SectionName
        {
            get { return _sectionName; }
        }

        public int PageID
        {
            get { return _pageID; }
        }

        public int ContentID
        {
            get { return _contentID; }
        }

        public int PCategoryID
        {
            get { return _PcategoryID; }
        }

    }
}
