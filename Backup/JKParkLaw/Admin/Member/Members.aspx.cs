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
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using System.Xml.Linq;
using SiteAdmin;
using NLog;


namespace JKParkLaw.Admin.Member
{
    public partial class Members : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Status");
            Master.SetSubSectionName("Members List");

            //BindData();

        }

        protected void BindData()
        {
            //DataTable members = AdminMembers.GetMembers();

            //MembersGV.DataSource = members;
            //MembersGV.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (AspxLB.Items.Count > 0)
            {
                foreach (ListEditItem item in AspxLB.Items){
                    string memberID = item.Value.ToString();
                    //logger.Debug("deleting memberid - "+memberID);
                    AdminMembers.DeleteMember(memberID);
                    
                }                
            }
            MembersGV.Selection.IsRowSelected(0);
            MembersGV.GetRow(0);

            MembersGV.DataSourceID = "MembersViewSource";
            //MembersGV.
            MembersGV.DataBind();
        }
    }
}
