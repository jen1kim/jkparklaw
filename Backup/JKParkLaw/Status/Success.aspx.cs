using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace JKParkLaw.Status
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            else
            {
                SetPaging(); 
            }
            Response.Expires = 0;
        
        }

        #region "Custom-Paging Functions"
        protected void gridList_DataBound(object sender, EventArgs e)
        {
            SetPaging();
        }


        private void SetPaging()
        {
            GridViewRow row = gridList.BottomPagerRow;

            for (int i = 1; i <= gridList.PageCount; i++)
            {
                LinkButton btn = new LinkButton();
                btn.CommandName = "Page";
                btn.CommandArgument = i.ToString();

                if (i == gridList.PageIndex + 1)
                {
                    //btn.BackColor = Color.BlanchedAlmond;
                    btn.CssClass = "active";
                }

                btn.Text = i.ToString();

                PlaceHolder place = row.FindControl("PlaceHolder1") as PlaceHolder;
                place.Controls.Add(btn);

                Label lbl = new Label();
                lbl.Text = " ";
                place.Controls.Add(lbl);
            }
        }
        #endregion
    }
}
