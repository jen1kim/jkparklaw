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
using SiteAdmin;
using NLog;


namespace JKParkLaw.Admin.Board
{
    public partial class BoardList : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        string _sHostUrl = HttpContext.Current.Request.ServerVariables["HTTP_HOST"] == null ? "" : "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Case Success");
            Master.SetSubSectionName("Message Board List");
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

        protected void RefreshList(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {

            
            DataView dv = (DataView)DS_Main.Select(DataSourceSelectArguments.Empty);
            gridList.DataSource = dv;
            gridList.DataBind();

            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        protected bool ValidateInsertFields()
        {
            lblMessage.Text = "";
            if (string.IsNullOrEmpty(tbBoardTitle.Text) == true)
            {
                lblMessage.Text = "Please insert a title.";
                return false;
            }

            if (string.IsNullOrEmpty(txtBoardContent.Value) == true)
            {
                lblMessage.Text = "Please insert the content.";
                return false;
            }
            DateTime modified;
            if (string.IsNullOrEmpty(ModifiedDate.Text) == true || !DateTime.TryParse(ModifiedDate.Text.Trim(), out modified))
            {
                lblMessage.Text = "Please select a date.";
                return false;
            }

            return true;
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInsertFields())
            {
                lblMessage.Text = "";
                try
                {
                    DS_Main.Insert();
                    lblMessage.Text = "Message was successfully added !!!";
                   
                    ClearInsertFields();

                    string script = "<script type=\"text/javascript\">alert('Message was successfully added !!!');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);

                    BindData();

                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    string script = "<script type=\"text/javascript\">alert('Error: " + ex.Message + "');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);
                }

                
            }
        }

        protected void gridList_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            gridList.PageIndex = e.NewPageIndex;
            DataView dv = (DataView)DS_Main.Select(DataSourceSelectArguments.Empty);
            gridList.DataSource = dv;
            gridList.DataBind();
        }

        protected void ClearInsertFields()
        {
            tbBoardTitle.Text = "";
            txtBoardContent.Value = "";
            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtBOrder.Text = "";
            ddlBoardCatID.SelectedIndex = 0;
        }

        protected void gridList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblMessage.Text = "";

           

            int UID = int.Parse(gridList.DataKeys[e.RowIndex]["UID"].ToString());

            string script = "<script type=\"text/javascript\">alert('deleting board message - " + UID.ToString() + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script);

            logger.Debug("deleting board message - " + UID.ToString());

            DS_Main.DeleteParameters["UID"].DefaultValue = UID.ToString();
            DS_Main.Delete();

            //logger.Debug("binding news ");
            BindData();
        }

        protected void gridList_RowDeleted(object sender, GridViewDeletedEventArgs e)
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

                    txtBoardContent.Value += "<img src='" + _sHostUrl + image_relative_path + "' style='max-width:600px;' />";
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
