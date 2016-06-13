using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKParkLaw.Controls.News
{
    public partial class NewsItem : System.Web.UI.UserControl
    {
        protected string _page;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected string SetLink(object newsID)
        {
            _page = ((JKParkLaw.News.NewsList)this.Page).PageID;

            return "/News/NewsList.aspx?NewsID=" + newsID.ToString() +"&Page=" + _page;
        }
    }
}