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
using DevExpress.Web.ASPxTabControl;
using System.Xml.Linq;
using SiteAdmin;
using NLog;

namespace JKParkLaw.Admin.Member
{
    public partial class ViewMember : System.Web.UI.Page
    {
        protected string _memberID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Status");
            Master.SetSubSectionName("View Progress");

            if (Request.QueryString["MemberID"] != null)
            {
                _memberID = Request.QueryString["MemberID"].ToString();
            }
            else
            {
                Response.End();
            }

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(_memberID) == false)
                {
                    //BindData();
                    AddedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                }
            }
        }

        private void BindData()
        {
            //DataTable progress = AdminProgresses.GetProgressList(_memberID);
            ProgressGV.DataSourceID = "dsProgressView";
            ProgressGV.DataBind();

            //ProgressGrid.DataSource = progress;
            //ProgressGrid.DataBind();
            AddedDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        //protected void ProgressGrid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblMessage.Text = "";
        //    GridViewRow gvRow = ProgressGrid.SelectedRow;
        //    int progressID = int.Parse(gvRow.Cells[1].Text);
        //    DataTable p = AdminProgresses.GetProgress(progressID);
        //    if (p.Rows.Count > 0)
        //    {
        //        hdnEditProgressID.Value = progressID.ToString();
        //        DataRow row = p.Rows[0];
        //        selectedProgress.Text = row["Title"].ToString();
        //        tbEditTitle.Text = row["Title"].ToString();

        //        EditAddedDate.Text = DateTime.Parse(row["Added"].ToString()).ToString("MM/dd/yyyy");
        //        ProgressEdit.Visible = true;
        //        EditSmallDesc.InnerText = row["SmallDesc"].ToString();

        //        AddNewProgressDiv.Visible = false;
        //    }
        //}

        protected void dsProgressView_Modifying(object sender, SqlDataSourceCommandEventArgs e)
        {
            //DemoSettings.AssertNotReadOnly();
        }

        protected string GetMemoText()
        {
            ASPxPageControl pageControl = ProgressGV.FindEditFormTemplateControl("pageControl") as ASPxPageControl;
            ASPxMemo memo = pageControl.FindControl("notesEditor") as ASPxMemo;
            return memo.Text;
        }

        protected void ProgressGV_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            e.NewValues["SmallDesc"] = GetMemoText();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateAddFields())
            {
                string title = tbNewTitle.Text;
                string smallDesc = NewSmallDesc.InnerText;
                DateTime added = DateTime.Parse(AddedDate.Text);
                int progressID = 0;
                progressID = AdminProgresses.AddNewProgress(_memberID, title, smallDesc, added);

                if (progressID > 0)
                {
                    lblMessage.Text = "Progress was successfully added. ";

                }
                else
                {
                    lblMessage.Text = "Progress was not added.";
                }
                tbNewTitle.Text = "";
                NewSmallDesc.InnerText = "";

                BindData();
            }
        }

        protected bool ValidateAddFields()
        {

            if (string.IsNullOrEmpty(_memberID) == true)
            {
                lblMessage.Text = "Member is not selected. ";
                return false;
            }

            if (string.IsNullOrEmpty(tbNewTitle.Text) == true)
            {
                lblMessage.Text = "Please insert title.";
                return false;
            }

            if (string.IsNullOrEmpty(NewSmallDesc.Value) == true)
            {
                lblMessage.Text = "Please insert description.";
                return false;
            }

            DateTime added;
            if (string.IsNullOrEmpty(AddedDate.Text) == true || !DateTime.TryParse(AddedDate.Text, out added))
            {
                lblMessage.Text = "Please select date.";
                return false;
            }
            return true;
        }

        protected void btnDeleteProgress_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hdnEditProgressID.Value) == false)
            {
                int progressID = int.Parse(hdnEditProgressID.Value);
                AdminProgresses.DeleteProgress(progressID);
                BindData();
                ProgressEdit.Visible = false;
                lblMessage.Text = "Progress item was successfully deleted. ";
                AddNewProgressDiv.Visible = true;
            }
            else
            {
                lblMessage.Text = "No progress item was selected.";
            }
        }


        protected void UpdateDetails_Click(object sender, EventArgs e)
        {
            if (ValidateUpdateFields())
            {
                string title = tbEditTitle.Text;
                string smallDesc = EditSmallDesc.InnerText;
                DateTime added = DateTime.Parse(EditAddedDate.Text);
                int progressID = int.Parse(hdnEditProgressID.Value);

                if (title.Length >= 3 && progressID > 0)
                {
                    AdminProgresses.UpdateProgress(progressID, _memberID, title, smallDesc, added);

                    ProgressEdit.Visible = false;
                    AddNewProgressDiv.Visible = true;
                    BindData();
                    lblMessage.Text = "Progress was successfully updated. ";
                }
                else
                {
                    lblMessage.Text = "Progress Update Error: ";
                }
            }
        }

        protected bool ValidateUpdateFields()
        {

            if (string.IsNullOrEmpty(_memberID) == true)
            {
                lblMessage.Text = "Member is not selected. ";
                return false;
            }

            if (string.IsNullOrEmpty(tbEditTitle.Text) == true)
            {
                lblMessage.Text = "Please insert title.";
                return false;
            }

            if (string.IsNullOrEmpty(EditSmallDesc.Value) == true)
            {
                lblMessage.Text = "Please insert description.";
                return false;
            }

            DateTime added;
            if (string.IsNullOrEmpty(EditAddedDate.Text) == true || !DateTime.TryParse(EditAddedDate.Text, out added))
            {
                lblMessage.Text = "Please select date.";
                return false;
            }

            return true;
        }
    }
}
