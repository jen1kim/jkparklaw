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
    public partial class Other : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        protected int _ID = 0;

        string _sHostUrl = HttpContext.Current.Request.ServerVariables["HTTP_HOST"] == null ? "" : "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Other Services");
            Master.SetSubSectionName("Update Item Details");

            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"].ToString(), out _ID);
            }
            else
            {
                Response.End();
            }

            if (!IsPostBack)
            {
                if (_ID > 0)
                {
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

            DataTable items = AdminOthers.GetOther(_ID);
            if (items.Rows.Count > 0)
            {
                DataRow row = items.Rows[0];
                lblID.Text = row["ID"].ToString();
                tbTitle.Text = row["Title"].ToString();
                tbSource.Text = row["Source"].ToString();
                tbAuthor.Text = row["Author"].ToString();
                SmallDesc.InnerText = row["SmallDesc"].ToString();
                BigDesc.Value = row["BigDesc"].ToString();
                cbHidden.Checked = bool.Parse(row["Hidden"].ToString());
                ModifiedDate.Text = DateTime.Parse(row["Modified"].ToString()).ToString("MM/dd/yyyy");
            }
        }

        protected bool ValidateUpdateFields()
        {
            lblMessage.Text = "";

            if (string.IsNullOrEmpty(lblID.Text) == true)
            {
                lblMessage.Text = "There is no ID. Please go to list and click 'Edit' to update item.";
                return false;
            }
            if (string.IsNullOrEmpty(tbTitle.Text) == true)
            {
                lblMessage.Text = "Please insert title.";
                return false;
            }

            DateTime modified;
            if (string.IsNullOrEmpty(ModifiedDate.Text) == true || !DateTime.TryParse(ModifiedDate.Text.Trim(), out modified))
            {
                lblMessage.Text = "Please select modified date.";
                return false;
            }
            if (string.IsNullOrEmpty(BigDesc.Value) == true)
            {
                lblMessage.Text = "Please insert content.";
                return false;
            }

            return true;
        }

        protected void UpdateContent_Click(object sender, EventArgs e)
        {
            if (ValidateUpdateFields())
            {
                int ID = int.Parse(lblID.Text);
                string title = tbTitle.Text;
                string source = tbSource.Text;
                string author = tbAuthor.Text;
                string smallDesc = SmallDesc.InnerText;
                string bigDesc = BigDesc.Value;
                bool hidden = cbHidden.Checked;
                DateTime modified = DateTime.Parse(ModifiedDate.Text);

                AdminOthers.UpdateOther(ID, title, source, author, smallDesc, bigDesc, hidden, modified);

                if (ID > 0)
                {
                    lblMessage.Text = "Item was successfully updated !!!";
                    ClearUpdateFields();
                }
                else
                {
                    lblMessage.Text = "Update item content error.";
                }
            }
        }

        protected void ClearUpdateFields()
        {
            lblID.Text = "";
            tbTitle.Text = "";
            tbSource.Text = "";
            tbAuthor.Text = "";
            SmallDesc.InnerText = "";
            BigDesc.Value = "";
            cbHidden.Checked = false;
            ModifiedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
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
