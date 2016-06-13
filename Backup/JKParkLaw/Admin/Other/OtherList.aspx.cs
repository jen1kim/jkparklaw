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

namespace JKParkLaw.Admin.Other
{
    public partial class OtherList : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        string _sHostUrl = HttpContext.Current.Request.ServerVariables["HTTP_HOST"] == null ? "" : "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Press");
            Master.SetSubSectionName("Items List");
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            // Your code
            Setup_ImageUploadEvent();
            base.OnLoad(e);
        }

        protected void BindData()
        {
            DataTable itemslist = AdminOthers.GetOtherList();
            OthersGrid.DataSource = itemslist;
            OthersGrid.DataBind();

            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        protected bool ValidateInsertFields()
        {
            lblMessage.Text = "";
            if (string.IsNullOrEmpty(tbTitle.Text) == true)
            {
                lblMessage.Text = "Please insert title.";
                return false;
            }

            if (string.IsNullOrEmpty(BigDesc.Value) == true)
            {
                lblMessage.Text = "Please insert content.";
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
                string title = tbTitle.Text;
                string source = tbSource.Text;
                string author = tbAuthor.Text;
                string smallDesc = SmallDesc.InnerText;
                string bigDesc = BigDesc.Value;
                bool hidden = cbHidden.Checked;
                DateTime modified = DateTime.Parse(ModifiedDate.Text);

                int ID = 0;
                ID = AdminOthers.AddOther(title, source, author, smallDesc, bigDesc, hidden, modified);

                if (ID > 0)
                {
                    lblMessage.Text = "Item was successfully added !!!";
                    ClearInsertFields();
                    BindData();
                }
                else
                {
                    lblMessage.Text = "Add new content error.";
                }
            }
        }

        protected void OthersGrid_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            OthersGrid.PageIndex = e.NewPageIndex;
            DataTable list = AdminOthers.GetOtherList();
            OthersGrid.DataSource = list;
            OthersGrid.DataBind();
        }

        protected void ClearInsertFields()
        {
            tbTitle.Text = "";
            tbSource.Text = "";
            tbAuthor.Text = "";
            SmallDesc.InnerText = "";
            BigDesc.Value = "";
            cbHidden.Checked = false;
            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        protected void OthersGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMessage.Text = "";
            int ID = int.Parse(OthersGrid.Rows[e.RowIndex].Cells[1].Text);

            logger.Debug("deleting news - " + ID);

            AdminOthers.DeleteOther(ID);

            //logger.Debug("binding news ");
            BindData();
        }

        protected void OthersGrid_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //logger.Debug("content deleted redirecting - ");
            //Response.Redirect("Contents.aspx?SectionID="+sectionID);
        }

        #region "Image Upload Event Handler"
        void Setup_ImageUploadEvent()
        {
            //add event handler
            ((Button)upload1.FindControl("btUpload")).Click += new EventHandler(btUpload_Click);
        }
        protected void btUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //upload the image to the specified folder. image file name is stored in the variable uploaded_image of the control
                bool bUpload = upload1.UploadImage();
                //for additional actions
                if (bUpload)
                {
                    //access upload file name
                    string img_filename = upload1.uploaded_image;
                    // output = /path/file.jpg
                    string image_relative_path = upload1.image_upload_folder + upload1.uploaded_image;
                    //actions go here
                    /* example action: display in text box:
                     * txt.Text = "<img src='./" + image_relative_path + "' />";
                     */

                    BigDesc.Value += "<img src='" + _sHostUrl + image_relative_path + "' style='max-width:600px;' />";
                }
            }
            catch (Exception ex)
            {
                lblMsgUpload1.Text = "Error: " + ex.Message;
            }
        }


        #endregion
    }
}
