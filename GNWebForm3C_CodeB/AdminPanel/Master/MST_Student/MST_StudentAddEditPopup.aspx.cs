using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;

public partial class AdminPanel_Master_MST_Student_MST_StudentAddEditPopup : System.Web.UI.Page
{
    #region 10.0 Local Variables 

    String FormName = "MST_StudentAddEdit";

    #endregion 10.0 Variables 

    #region 11.0 Page Load Event 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login 

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login 

        if (!Page.IsPostBack)
        {
            #region 11.2 Fill Labels 

            FillLabels(FormName);

            #endregion 11.2 Fill Labels 

            #region 11.3 DropDown List Fill Section 

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section 

            #region 11.4 Set Control Default Value 

            lblFormHeader.Text = CV.PageHeaderAdd + " Student";
            txtStudentName.Focus();

            #endregion 11.4 Set Control Default Value 

            #region 11.5 Fill Controls 

            FillControls();

            #endregion 11.5 Fill Controls 



        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels 

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels 

    #region 13.0 Fill DropDownList 

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCurrentSem(ddlCurrentSem);
        CommonFillMethods.FillDropDownListGender(ddlGender);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK  

    private void FillControls()
    {
        if (Request.QueryString["StudentID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Student";
            MST_StudentBAL balMST_Student = new MST_StudentBAL();
            MST_StudentENT entMST_Student = new MST_StudentENT();
            entMST_Student = balMST_Student.SelectByPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]));

            if (!entMST_Student.StudentName.IsNull)
                txtStudentName.Text = entMST_Student.StudentName.Value.Trim().ToString();

            if (!entMST_Student.Enrollment.IsNull)
                txtEnrollmentNo.Text = entMST_Student.Enrollment.Value.ToString();

            if (!entMST_Student.CurrentSem.IsNull)
                ddlCurrentSem.SelectedValue = entMST_Student.CurrentSem.Value.ToString();

            if (!entMST_Student.EmailInstitude.IsNull)
                txtEmailInstitute.Text = entMST_Student.EmailInstitude.Value.ToString();

            if (!entMST_Student.EmailPersonal.IsNull)
                txtEmailPersonal.Text = entMST_Student.EmailPersonal.Value.ToString();

            if (!entMST_Student.Gender.IsNull)
                ddlGender.SelectedValue = entMST_Student.Gender.Value.ToString();

            if (!entMST_Student.RollNo.IsNull)
                txtRollNo.Text = entMST_Student.RollNo.Value.ToString();

            if (!entMST_Student.Birthdate.IsNull)
                dtpBirthDate.Text = entMST_Student.Birthdate.Value.ToString(CV.DefaultDateFormat);

            if (!entMST_Student.ContactNo.IsNull)
                txtContactNo.Text = entMST_Student.ContactNo.Value.ToString();
        }
    }

    #endregion 14.0 FillControls By PK 

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Trigger validation
        Page.Validate();

        // Check if the page is valid
        if (Page.IsValid)
        {
            try
            {
                MST_StudentBAL balMST_Student = new MST_StudentBAL();
                MST_StudentENT entMST_Student = new MST_StudentENT();

                #region 15.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (string.IsNullOrWhiteSpace(txtStudentName.Text))
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Student Name");
                if (string.IsNullOrWhiteSpace(txtEnrollmentNo.Text))
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Enrollment No");
                if (ddlCurrentSem.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Current Sem");
                if (string.IsNullOrWhiteSpace(txtEmailPersonal.Text))
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Email Personal");
                if (ddlGender.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Gender");
                if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Contact No");
                if (string.IsNullOrWhiteSpace(dtpBirthDate.Text))
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Birth Date");

                if (!string.IsNullOrEmpty(ErrorMsg))
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);

                    // Use JavaScript to show the modal again
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#view').modal('show');", true);

                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data 

                entMST_Student.StudentName = txtStudentName.Text.Trim();
                entMST_Student.Enrollment = txtEnrollmentNo.Text.Trim();
                entMST_Student.CurrentSem = Convert.ToInt32(ddlCurrentSem.SelectedValue);
                entMST_Student.EmailInstitude = txtEmailInstitute.Text.Trim();
                entMST_Student.EmailPersonal = txtEmailPersonal.Text.Trim();
                entMST_Student.Gender = ddlGender.SelectedValue.Trim();
                entMST_Student.Birthdate = Convert.ToDateTime(dtpBirthDate.Text.Trim());
                entMST_Student.RollNo = Convert.ToInt32(txtRollNo.Text.Trim());
                entMST_Student.ContactNo = txtContactNo.Text.Trim();
                entMST_Student.UserID = Convert.ToInt32(Session["UserID"]);
                entMST_Student.Created = DateTime.Now;
                entMST_Student.Modified = DateTime.Now;

                #endregion 15.2 Gather Data 

                #region 15.3 Insert,Update,Copy 

                if (Request.QueryString["StudentID"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_Student.StudentID = CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]);
                    if (balMST_Student.Update(entMST_Student))
                    {
                        Response.Redirect("MST_StudentList.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        ucMessage.ShowError(balMST_Student.Message);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#view').modal('show');", true);
                    }
                }
                else
                {
                    if (balMST_Student.Insert(entMST_Student))
                    {
                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                        ClearControls();
                        Response.Redirect("MST_StudentList.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        ucMessage.ShowError(balMST_Student.Message);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#view').modal('show');", true);
                    }
                }

                #endregion 15.3 Insert,Update,Copy

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#view').modal('show');", true);
            }
        }
        else
        {
            // Handle the case where the page is not valid
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#view').modal('show');", true);
        }

    }


    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 

    private void ClearControls()
    {
        txtStudentName.Text = String.Empty;
        txtEnrollmentNo.Text = String.Empty;
        ddlCurrentSem.SelectedIndex = 0;
        txtEmailInstitute.Text = String.Empty;
        txtEmailPersonal.Text = String.Empty;
        ddlGender.SelectedIndex = 0;
        txtRollNo.Text = String.Empty;
        txtContactNo.Text = String.Empty;
        dtpBirthDate.Text = String.Empty;
        txtStudentName.Focus();
    }

    #endregion 16.0 Clear Controls 
}