using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using SiteFrontend;

namespace JKParkLaw
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetMasterHeaderStyle();
                SetLatestNews();
            }
        }

        public void SetMasterHeaderStyle()
        {
            Master.HeaderStyle = "home";
        }

        protected void SetLatestNews()
        {
            DataTable newlist = FrontNews.GetFrontNewsList(5);
            LiteralControl literalControl;

            foreach (DataRow child in newlist.Rows)
            {
                DateTime modified = DateTime.Parse(child["Modified"].ToString());
                string newsid = child["NewsID"].ToString();
                string newstitle = child["NewsTitle"].ToString();

                //<li><span>2009.09.18</span><a href="#">Lorem Ipsum Dolor sit amet sjtpua cons...</a></li>
                literalControl = new LiteralControl(String.Format("<li><span>{0}</span><a href='{1}'>{2}</a></li>\n",
                    modified.ToString("yyyy'.'MM'.'dd"),
                    "/News/NewsList.aspx?NewsID="+newsid,
                    newstitle));

                ContentsPlaceHolder.Controls.Add(literalControl);

            }            
        }
    }
}
