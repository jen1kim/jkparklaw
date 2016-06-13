using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JKParkLaw.Controls.Other
{
    public partial class OtherItem : System.Web.UI.UserControl
    {
        protected string _page;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string SetLink(object otherID)
        {
            _page = ((JKParkLaw.Other.OtherList)this.Page).PageID;

            return "/Other/OtherList.aspx?ID=" + otherID.ToString() + "&Page=" + _page;
        }
    }
}