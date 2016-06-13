using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using NLog;
using SiteFrontend;

namespace JKParkLaw.Controls.Categories
{
    public partial class ContentsListing : System.Web.UI.UserControl
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        protected int _categoryID;
        protected string _categoryName;
        protected int _sectionID;
        protected string _sectionName;
        protected int _contentID;


        private DataTable ContentsTable;

        protected void Page_Load(object sender, EventArgs e)
        {

            _categoryID = ((JKParkLaw.Categories.Category)this.Page).CategoryID;
            _categoryName = ((JKParkLaw.Categories.Category)this.Page).CategoryName;
            _sectionID = ((JKParkLaw.Categories.Category)this.Page).SectionID;
            _sectionName = ((JKParkLaw.Categories.Category)this.Page).SectionName;
            _contentID = ((JKParkLaw.Categories.Category)this.Page).ContentID;

            //logger.Debug("_categoryID " + _categoryID);
            //logger.Debug("_categoryName " + _categoryName);
            //logger.Debug("_sectionID " + _sectionID);
            //logger.Debug("_sectionName " + _sectionName);
            //logger.Debug("_contentID " + _contentID);

            if (!IsPostBack)
            {
                ContentsTable = SiteFrontend.FrontContents.GetContents(_categoryID);
                SetContent();
                MakeHTMLTree();                
            }
        }

        private void MakeHTMLTree()
        {
            LiteralControl literalControl;
            //logger.Debug("_contentID == 0 " + (_contentID == 0));

            if (_contentID == 0)
            {
                int count = 0;
                foreach (DataRow child in ContentsTable.Rows)
                {
                    if (count == 0 )
                    {
                        literalControl = new LiteralControl(String.Format("<li class='current'><a href='{0}'>{1}</a></li>\n",
                            "/Categories/Category.aspx?CategoryID=" + _categoryID.ToString() + "&ContentID=" + child["ContentID"].ToString(),
                            child["ContentTitle"].ToString()));
                    }
                    else
                    {
                        literalControl = new LiteralControl(String.Format("<li><a href='{0}'>{1}</a></li>\n",
                            "/Categories/Category.aspx?CategoryID=" + _categoryID.ToString() + "&ContentID=" + child["ContentID"].ToString(),
                            child["ContentTitle"].ToString()));
                    }
                    ContentsPlaceHolder.Controls.Add(literalControl);
                    count++;
                }
            }
            else
            {
                foreach (DataRow child in ContentsTable.Rows)
                {
                    if (child["ContentID"].ToString() == _contentID.ToString())
                    {
                        literalControl = new LiteralControl(String.Format("<li class='current'><a href='{0}'>{1}</a></li>\n",
                            "/Categories/Category.aspx?CategoryID=" + _categoryID.ToString() + "&ContentID=" + child["ContentID"].ToString(),
                            child["ContentTitle"].ToString()));
                    }
                    else
                    {
                        literalControl = new LiteralControl(String.Format("<li><a href='{0}'>{1}</a></li>\n",
                            "/Categories/Category.aspx?CategoryID=" + _categoryID.ToString() + "&ContentID=" + child["ContentID"].ToString(),
                            child["ContentTitle"].ToString()));
                    }
                    ContentsPlaceHolder.Controls.Add(literalControl);
                }
            }
        }

        private void SetContent()
        {
            lblCategoryName.Text = _categoryName;

            //logger.Debug("_contentID == 0 " + (_contentID == 0));

            if (_contentID != 0)
            {
                DataTable content = SiteFrontend.FrontContents.GetContent(_contentID);
                if (content.Rows.Count > 0)
                {
                    DataRow row = content.Rows[0];
                    ContentDiv.InnerHtml = row["ContentDesc"].ToString();

                    lblContentTitle.Text = row["ContentTitle"].ToString();
                }
                else
                {
                    ContentDiv.InnerHtml = "";
                    lblContentTitle.Text = "";
                }
            }
            else
            {
                if (ContentsTable.Rows.Count > 0)
                {
                    DataRow row = ContentsTable.Rows[0];
                    ContentDiv.InnerHtml = row["ContentDesc"].ToString();

                    lblContentTitle.Text = row["ContentTitle"].ToString();
                }
                else
                {
                    ContentDiv.InnerHtml = "";
                    lblContentTitle.Text = "";
                }
            }
        }
    }
}