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

namespace JKParkLaw.Admin.Case
{
    public partial class Cases : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetLogger("MyClass");

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.SetSectionName("Latest Approved Cases");
            Master.SetSubSectionName("Case List & Update");

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataTable cases = AdminCases.GetCaseList();
            CasesGrid.DataSource = cases;
            CasesGrid.DataBind();
        }


        protected void CasesGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            GridViewRow gvRow = CasesGrid.SelectedRow;
            int caseID = int.Parse(gvRow.Cells[1].Text);
            DataTable caseTable = AdminCases.GetCase(caseID);
            if (caseTable.Rows.Count > 0)
            {
                hdnEditCaseID.Value = caseID.ToString();
                DataRow row = caseTable.Rows[0];
                selectedCase.Text = row["CaseTitle"].ToString();
                tbEditCaseTitle.Text = row["CaseTitle"].ToString();
                lblEditCaseFileName.Text = row["CaseFileName"].ToString();
                btnDeleteCase.Enabled = true;
                CaseEdit.Visible = true;
                EditSmallDesc.InnerText = row["CaseSmallDesc"].ToString();
                cbHidden.Checked = bool.Parse(row["Hidden"].ToString());

                AddNewCaseDiv.Visible = false;
            }
        }


        protected void CasesGrid_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            CasesGrid.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateAddFields())
            {
                string caseTitle = tbNewCaseTitle.Text;
                string smallDesc = NewSmallDesc.InnerText;
                int caseID = 0;
                caseID = AdminCases.AddNewCase(caseTitle, "", smallDesc, false);

                if (caseID > 0)
                {
                    string newFileName;
                    bool uploaded = AdminCases.UploadFile(caseID, ref fuNewCaseFileName, out newFileName);

                    if (uploaded)
                    {
                        AdminCases.UpdateCaseFileName(caseID, newFileName);
                        lblMessage.Text = "Case was successfully added. ";
                    }
                    else
                    {
                        lblMessage.Text = "File was not uploaded.";
                    }
                }
                else
                {
                    lblMessage.Text = "Case was not added.";
                }
                tbNewCaseTitle.Text = "";
                NewSmallDesc.InnerText = "";                

                BindData();
            }
        }

        protected bool ValidateAddFields()
        {
            if (string.IsNullOrEmpty(tbNewCaseTitle.Text) == true)
            {
                lblMessage.Text = "Please insert case title.";
                return false;
            }

            if (string.IsNullOrEmpty(fuNewCaseFileName.FileName) == true)
            {
                lblMessage.Text = "Please select case file.";
                return false;
            }

            return true;
        }

        protected void btnDeleteCase_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hdnEditCaseID.Value) == false)
            {
                int caseID = int.Parse(hdnEditCaseID.Value);
                string caseFileName = lblEditCaseFileName.Text;
                AdminCases.DeleteFile(caseID, caseFileName);
                AdminCases.DeleteCase(caseID);
                BindData();
                CaseEdit.Visible = false;
                lblMessage.Text = "Case was successfully deleted. ";
                btnDeleteCase.Enabled = false;
                AddNewCaseDiv.Visible = true;
            }
            else
            {
                lblMessage.Text = "No case was selected.";
            }
        }


        protected void UpdateDetails_Click(object sender, EventArgs e)
        {
            if (ValidateUpdateFields())
            {
                string caseTitle = tbEditCaseTitle.Text;
                string caseSmallDesc = EditSmallDesc.InnerText;
                string caseFileName = lblEditCaseFileName.Text;

                bool caseHidden = cbHidden.Checked;
                int caseID = int.Parse(hdnEditCaseID.Value);

                logger.Debug("caseID: "+caseID);
                if (caseTitle.Length >= 3 && caseID > 0)
                {
                    if (string.IsNullOrEmpty(fuEditCaseFileName.FileName) == false)
                    {
                        AdminCases.DeleteFile(caseID,caseFileName);
                        string newFileName;
                        AdminCases.UploadFile(caseID, ref fuEditCaseFileName, out newFileName);
                        AdminCases.UpdateCase(caseID, caseTitle, newFileName, caseSmallDesc, caseHidden, DateTime.Now);
                    }
                    else
                    {
                        AdminCases.UpdateCase(caseID, caseTitle, caseFileName, caseSmallDesc, caseHidden, DateTime.Now);
                    }

                    CaseEdit.Visible = false;
                    AddNewCaseDiv.Visible = true;
                    BindData();
                    lblMessage.Text = "Case was successfully updated. ";
                }
                else
                {
                    lblMessage.Text = "Case Update Error: ";
                }
            }
        }

        protected bool ValidateUpdateFields()
        {

            if (string.IsNullOrEmpty(tbEditCaseTitle.Text) == true)
            {
                lblMessage.Text = "Please insert case title.";
                return false;
            }

            if (string.IsNullOrEmpty(lblEditCaseFileName.Text) == true && 
                string.IsNullOrEmpty(fuEditCaseFileName.FileName) == true)
            {
                lblMessage.Text = "Please select case file.";
                return false;
            }

            return true;
        }

    }
}
