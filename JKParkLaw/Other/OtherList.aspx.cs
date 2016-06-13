using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JKParkLaw.Controls.Other;
using SiteFrontend;

namespace JKParkLaw.Other
{
    public partial class OtherList : System.Web.UI.Page
    {
        private string _page = "1";
        private int _otherID = 0;
        private int _othersPerPage = DBBase.Configuration.GetKeyInt("NewsPerPage");
        protected void Page_Load(object sender, EventArgs e)
        {
            _page = Request.QueryString["Page"];
            if (_page == null) _page = "1";


            if (Request.QueryString["ID"] != null)
            {
                bool parsed = int.TryParse(Request.QueryString["ID"].ToString(), out _otherID);
                if (!parsed) _otherID = 0;
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }

        public string PageID
        {
            get { return _page; }
        }


        protected void BindData()
        {
            int howManyPages = 1;

            DataTable others = SiteFrontend.FrontOthers.GetOthersIDs(int.Parse(_page), _othersPerPage, out howManyPages);
            OthersRepeater.DataSource = others;
            OthersRepeater.DataBind();

            if (_otherID == 0)
            {
                if (others.Rows.Count > 0)
                {
                    DataRow row = others.Rows[0];
                    _otherID = int.Parse(row["ID"].ToString());
                }
            }

            if (_otherID > 0)
            {
                DataTable n = FrontOthers.GetOther(_otherID);
                if (n.Rows.Count > 0)
                {
                    DataRow r = n.Rows[0];
                    lblTitle.Text = r["Title"].ToString();
                    lblDate.Text = String.Format("{0:M/d/yyyy}", DateTime.Parse(r["Modified"].ToString()));
                    ContentDiv.InnerHtml = r["BigDesc"].ToString();
                }
            }

            if (howManyPages > 1)
            {
                int currentPage = Int32.Parse(_page);
                pagingLabel.Visible = true;
                previousLink.Visible = true;
                nextLink.Visible = true;
                firstLink.Visible = true;
                lastLink.Visible = true;

                pagingLabel.Text = _page + " / " + howManyPages.ToString();

                // create previous link
                if (currentPage == 1)
                {
                    previousLink.Enabled = false;
                    firstLink.Enabled = false;
                }
                else
                {
                    NameValueCollection query = Request.QueryString;
                    string paramName, newQueryString = "?";
                    for (int i = 0; i < query.Count; i++)
                    {
                        if (query.AllKeys[i] != null)
                            if ((paramName = query.AllKeys[i].ToString()).ToUpper() != "PAGE")
                                newQueryString += paramName + "=" + query[i] + "&";
                    }
                    previousLink.NavigateUrl = Request.Url.AbsolutePath + newQueryString + "Page=" + (currentPage - 1).ToString();
                    firstLink.NavigateUrl = Request.Url.AbsolutePath + newQueryString + "Page=1";
                }


                //create next link
                if (currentPage == howManyPages)
                {
                    nextLink.Enabled = false;
                    lastLink.Enabled = false;
                }
                else
                {
                    NameValueCollection query = Request.QueryString;
                    string paramName, newQueryString = "?";
                    for (int i = 0; i < query.Count; i++)
                    {
                        if (query.AllKeys[i] != null)
                            if ((paramName = query.AllKeys[i].ToString()).ToUpper() != "PAGE")
                                newQueryString += paramName + "=" + query[i] + "&";
                    }
                    nextLink.NavigateUrl = Request.Url.AbsolutePath + newQueryString + "Page=" + (currentPage + 1).ToString();
                    lastLink.NavigateUrl = Request.Url.AbsolutePath + newQueryString + "Page=" + howManyPages.ToString();
                }
            }
        }


    }
}
