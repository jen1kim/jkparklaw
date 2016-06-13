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
    public partial class Board : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        protected int _UID = 0;

        string _sHostUrl = HttpContext.Current.Request.ServerVariables["HTTP_HOST"] == null ? "" : "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];


        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Case Success");
            Master.SetSubSectionName("Update Message");

            if (Request.QueryString["id"] != null)
            {
                int.TryParse(Request.QueryString["id"].ToString(), out _UID);
            }
            else
            {
                Response.End();
            }

            if (!IsPostBack)
            {
                if (_UID > 0)
                {
                    lblUID.Text = _UID.ToString();
                    BindData();
                }
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

            DataView dv = (DataView)DS_Main.Select(DataSourceSelectArguments.Empty);
            if (dv.Table.Rows.Count > 0)
            {
                DataRow row = dv.Table.Rows[0];
                lblUID.Text = row["UID"].ToString();

                ddlBoardCatID.DataBind();
                ddlBoardCatID.SelectedValue = row["BoardCatID"].ToString();

                tbBoardTitle.Text = row["BoardTitle"].ToString();
                txtBoardContent.Value = row["BoardContent"].ToString();
                txtBOrder.Text = row["OrderNoDisplay"].ToString();
                ModifiedDate.Text = DateTime.Parse(row["ControlDate"].ToString()).ToString("MM/dd/yyyy");
            }
        }

        protected bool ValidateUpdateFields()
        {
            lblMessage.Text = "";

            if (string.IsNullOrEmpty(lblUID.Text) == true)
            {
                lblMessage.Text = "There is no message ID. Please go to Message Board list and click 'Edit' to update the record.";
                return false;
            }
            if (string.IsNullOrEmpty(tbBoardTitle.Text) == true)
            {
                lblMessage.Text = "Please insert title.";
                return false;
            }

            DateTime modified;
            if (string.IsNullOrEmpty(ModifiedDate.Text) == true || !DateTime.TryParse(ModifiedDate.Text.Trim(), out modified))
            {
                lblMessage.Text = "Please select a date.";
                return false;
            }
            if (string.IsNullOrEmpty(txtBoardContent.Value) == true)
            {
                lblMessage.Text = "Please insert the content.";
                return false;
            }

            return true;
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            if (ValidateUpdateFields())
            {
                try
                {
                    DS_Main.Update();
                    lblMessage.Text = "Message was successfully updated !!!";
                    ClearUpdateFields();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                }

                
            }
        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("./BoardList.aspx");
        }

        protected void ClearUpdateFields()
        {
            lblUID.Text = "";
            tbBoardTitle.Text = "";
            txtBoardContent.Value = "";
            txtBOrder.Text = "";
            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            ddlBoardCatID.SelectedIndex = 0;
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
