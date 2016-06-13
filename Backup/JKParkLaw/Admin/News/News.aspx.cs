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
    public partial class News : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        protected int _newsID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("News");
            Master.SetSubSectionName("Update News Details");

            if (Request.QueryString["NewsID"] != null)
            {
                int.TryParse(Request.QueryString["NewsID"].ToString(), out _newsID);
            }
            else
            {
                Response.End();
            }

            if (!IsPostBack)
            {
                if (_newsID > 0)
                {
                    BindData();
                }
            }

        }

        protected void BindData()
        {

            DataTable news = AdminNews.GetNews(_newsID);
            if (news.Rows.Count > 0)
            {
                DataRow row = news.Rows[0];
                lblNewsID.Text = row["NewsID"].ToString();
                tbNewsTitle.Text = row["NewsTitle"].ToString();
                tbSource.Text = row["Source"].ToString();
                tbAuthor.Text = row["Author"].ToString();
                SmallDesc.InnerText = row["NewsSmallDesc"].ToString();
                BigDescription.Value = row["NewsDesc"].ToString();
                cbNewsHidden.Checked = bool.Parse(row["Hidden"].ToString());
                ModifiedDate.Text = DateTime.Parse(row["Modified"].ToString()).ToString("MM/dd/yyyy");
            }
        }

        protected bool ValidateUpdateFields()
        {
            lblMessage.Text = "";

            if (string.IsNullOrEmpty(lblNewsID.Text) == true)
            {
                lblMessage.Text = "There is no news ID. Please go to news list and click 'Edit' to update news item.";
                return false;
            }
            if (string.IsNullOrEmpty(tbNewsTitle.Text) == true)
            {
                lblMessage.Text = "Please insert news title.";
                return false;
            }

            DateTime modified;
            if (string.IsNullOrEmpty(ModifiedDate.Text) == true || !DateTime.TryParse(ModifiedDate.Text.Trim(), out modified))
            {
                lblMessage.Text = "Please select modified date.";
                return false;
            }
            if (string.IsNullOrEmpty(BigDescription.Value) == true)
            {
                lblMessage.Text = "Please insert news content.";
                return false;
            }

            return true;
        }

        protected void UpdateNewsContent_Click(object sender, EventArgs e)
        {
            if (ValidateUpdateFields())
            {
                int newsID = int.Parse(lblNewsID.Text);
                string newsTitle = tbNewsTitle.Text;
                string source = tbSource.Text;
                string author = tbAuthor.Text;
                string newsSmallDesc = SmallDesc.InnerText;
                string newsDesc = BigDescription.Value;
                bool hidden = cbNewsHidden.Checked;
                DateTime modified = DateTime.Parse(ModifiedDate.Text);

                AdminNews.UpdateNews(newsID, newsTitle, source, author, newsSmallDesc, newsDesc, hidden, modified);

                if (newsID > 0)
                {
                    lblMessage.Text = "News was successfully updated !!!";
                    ClearUpdateFields();
                    //BindData();
                }
                else
                {
                    lblMessage.Text = "Update news content error.";
                }
            }
        }

        protected void ClearUpdateFields()
        {
            lblNewsID.Text = "";
            tbNewsTitle.Text = "";
            tbSource.Text = "";
            tbAuthor.Text = "";
            SmallDesc.InnerText = "";
            BigDescription.Value = "";
            cbNewsHidden.Checked = false;
            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}
