using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Student_MST_StudentView : System.Web.UI.Page
{

    #region Page load
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 10.1 Check User Login 

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 10.1 Check User Login 

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["StudentID"] != null)
            {
                FillControls();
            }
        }
    }

        #region FillControls
        private void FillControls()
        {
            if (Request.QueryString["StudentID"] != null)
            {
                MST_StudentBAL bal_MST_Student = new MST_StudentBAL();
                DataTable dt_MST_Student = bal_MST_Student.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["STudentID"]));
                if (dt_MST_Student != null)
                {
                    foreach (DataRow dr in dt_MST_Student.Rows)
                    {

                        if (!dr["StudentName"].Equals(DBNull.Value))
                            lblStudentName.Text = Convert.ToString(dr["StudentName"]);

                        if (!dr["Enrollment"].Equals(DBNull.Value))
                            lblEnrollmentNo.Text = Convert.ToString(dr["Enrollment"]);

                        if (!dr["RollNo"].Equals(DBNull.Value))
                            lblRollNo.Text = Convert.ToString(dr["RollNo"]);

                        if (!dr["CurrentSem"].Equals(DBNull.Value))
                            lblCurrentSem.Text = Convert.ToString(dr["CurrentSem"]);

                        if (!dr["EmailInstitude"].Equals(DBNull.Value))
                            lblEmailInstitude.Text = Convert.ToString(dr["EmailInstitude"]);

                        if (!dr["EmailPersonal"].Equals(DBNull.Value))
                            lblEmailPersonal.Text = Convert.ToString(dr["EmailPersonal"]);

                        if (!dr["BirthDate"].Equals(DBNull.Value))
                            lblBirthDate.Text = Convert.ToString(dr["BirthDate"]);

                        if (!dr["ContactNo"].Equals(DBNull.Value))
                            lblContactNo.Text = Convert.ToString(dr["ContactNo"]);

                    if (!dr["Gender"].Equals(DBNull.Value))
                        lblGender.Text = Convert.ToString(dr["Gender"]);

                    }
                }
            }
        }
        #endregion FillControls
    

    #endregion
}