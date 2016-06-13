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
using SiteFrontend;

namespace JKParkLaw.Status
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HasNumericValue(Request.QueryString["cat"]))
                {
                    if (Request.QueryString["cat"].ToString() != "0")
                    {
                       // HyperLink hlList = (HyperLink)fDetail.FindControl("hlList");
                      //  hlList.NavigateUrl = "~/Status/Success.aspx?cat=" + Request.QueryString["cat"].ToString();
                        gridList.SelectedIndex = 0;
                    }

                }
            }
            else
            {
                SetPaging(); 
            }
            Response.Expires = 0;
            BindData();
        
        }

        protected void BindData()
        {
            

            var catid = Request.QueryString["cat"];
            var uid = Request.QueryString["id"];
            if (catid == "0" || catid == null)
            {
                catid = "1";
            }

            if (uid == "0" || uid == null)
            {
                uid = "0";
            }

            DataTable content = SiteFrontend.FrontOthers.GetSucess(int.Parse(uid), int.Parse(catid));
            foreach (DataRow dr in content.Rows)                    
                    {
                        
                        lblTitle.Text = dr.ItemArray[2].ToString();
                        lblDate.Text = String.Format("{0:M/d/yyyy}", DateTime.Parse(dr.ItemArray[1].ToString()));
                        ContentDiv.InnerHtml = dr.ItemArray[3].ToString();
                    }
            

        }

        public bool HasNumericValue(object o)
        {
            if (o == null)
            {
                return false;
            }

            if (o == System.DBNull.Value)
            {
                return false;
            }

            if (o is String)
            {
                if (((String)o).Trim() == String.Empty)
                {
                    return false;
                }

                if (!IsNumeric(((String)o).Trim()))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsNumeric(string sValue)
        {
            double i;
            return double.TryParse(sValue, out i);

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
