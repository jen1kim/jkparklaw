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


namespace JKParkLaw.Admin.News
{
    public partial class NewsList : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("News");
            Master.SetSubSectionName("News List");
            if (!IsPostBack)
            {
                BindData();
            }

        }

        protected void BindData()
        {
            
            DataTable newslist = AdminNews.GetNewsList();
            NewsGrid.DataSource = newslist;
            NewsGrid.DataBind();

            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        protected bool ValidateInsertFields()
        {
            lblMessage.Text = "";
            if (string.IsNullOrEmpty(tbNewsTitle.Text) == true)
            {
                lblMessage.Text = "Please insert news title.";
                return false;
            }

            if (string.IsNullOrEmpty(BigDescription.Value) == true)
            {
                lblMessage.Text = "Please insert news content.";
                return false;
            }
            DateTime modified;
            if (string.IsNullOrEmpty(ModifiedDate.Text) == true || !DateTime.TryParse(ModifiedDate.Text.Trim(), out modified))
            {
                lblMessage.Text = "Please select modified date.";
                return false;
            }

            return true;
        }

        protected void AddNewContent_Click(object sender, EventArgs e)
        {
            if (ValidateInsertFields())
            {
                string newsTitle = tbNewsTitle.Text;
                string source = tbSource.Text;
                string author = tbAuthor.Text;
                string newsSmallDesc = SmallDesc.InnerText;
                string newsDesc = BigDescription.Value;
                bool hidden = cbNewsHidden.Checked;
                DateTime modified = DateTime.Parse(ModifiedDate.Text);

                int newsID = 0;
                newsID = AdminNews.AddNews(newsTitle, source, author, newsSmallDesc, newsDesc, hidden, modified);

                if (newsID > 0)
                {
                    lblMessage.Text = "News was successfully added !!!";
                    ClearInsertFields();
                    BindData();
                }
                else
                {
                    lblMessage.Text = "Add new content error.";
                }
            }
        }

        protected void NewsGrid_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            NewsGrid.PageIndex = e.NewPageIndex;
            DataTable newslist = AdminNews.GetNewsList();
            NewsGrid.DataSource = newslist;
            NewsGrid.DataBind(); 
        }

        protected void ClearInsertFields()
        {
            tbNewsTitle.Text = "";
            tbSource.Text = "";
            tbAuthor.Text = "";
            SmallDesc.InnerText = "";
            BigDescription.Value = "";
            cbNewsHidden.Checked = false;
            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        protected void NewsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMessage.Text = "";
            int newsID = int.Parse(NewsGrid.Rows[e.RowIndex].Cells[1].Text);

            logger.Debug("deleting news - " + newsID);

            AdminNews.DeleteNews(newsID);

            //logger.Debug("binding news ");
            BindData();
        }

        protected void NewsGrid_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //logger.Debug("content deleted redirecting - ");
            //Response.Redirect("Contents.aspx?SectionID="+sectionID);
        }
    }
}
