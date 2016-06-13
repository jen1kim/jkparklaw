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

namespace JKParkLaw.Case
{
    public partial class Cases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetCaseList();
            }
        }

        protected void SetCaseList()
        {
            int howManyPages = 1;
            DataTable caselist = FrontCases.GetCaseList(1,30, out howManyPages);
            LiteralControl literalControl;

            foreach (DataRow child in caselist.Rows)
            {
                DateTime modified = DateTime.Parse(child["Modified"].ToString());
                string caseid = child["CaseID"].ToString();
                string casetitle = child["CaseTitle"].ToString();
                string fileUrl = String.Format("/Files/case/{0}/{1}", SiteFrontend.FrontTools.GetDirectotyID(int.Parse(caseid)), child["CaseFileName"]);

                //<li><div><a href="#" target="_blank">Casestudy 3 (Link to PDF)</a></div></li>
                literalControl = new LiteralControl(String.Format("<li><div><a href='{0}' target='_blank'>{1}</a></div></li>\n",
                    fileUrl, casetitle));

                ContentsPlaceHolder.Controls.Add(literalControl);

            }
        }
    }
}
