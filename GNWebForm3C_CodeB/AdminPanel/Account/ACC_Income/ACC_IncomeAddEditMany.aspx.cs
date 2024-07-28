﻿using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Account_ACC_Income_ACC_IncomeAddEditMany : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "ACC_IncomeAddEdit";

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
            if (Request.QueryString["FinYearID"] != null && Request.QueryString["HospitalID"] != null && Request.QueryString["IncomeTypeID"] != null)
            {
                btnShow_Click(sender, e);
            }
            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            lblFormHeader.Text = CV.PageHeaderMany + " Expense Type";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;


            #endregion 11.4 Set Control Default Value
        }
    }
    #endregion Pageload

    #region 12.0 FillLabels
    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListFinYearID(ddlFinYearID);
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
        CommonFillMethods.FillSingleDropDownListIncomeTypeID(ddlIncomeTypeID);
    }

    #endregion 13.0 Fill DropDownList


    #region 14.0 Show Button Event
    protected void btnShow_Click(object sender, EventArgs e)
    {
        SqlInt32 FinYearID = SqlInt32.Null;
        SqlInt32 HospitalID = SqlInt32.Null;
        SqlInt32 IncomeTypeID = SqlInt32.Null;

        #region NavigateLogic
        if (Request.QueryString["FinYearID"] != null && Request.QueryString["HospitalID"] != null && Request.QueryString["IncomeTypeID"] != null)
        {
            if (!Page.IsPostBack)
            {
                FinYearID = CommonFunctions.DecryptBase64Int32(Request.QueryString["FinYearID"]);
                HospitalID = CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]);
                IncomeTypeID = CommonFunctions.DecryptBase64Int32(Request.QueryString["IncomeTypeID"]);
            }
            else
            {
                if (ddlHospitalID.SelectedIndex > 0)
                {
                    FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                    IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
                }
            }
        }
        else
        {
            if (ddlHospitalID.SelectedIndex > 0)
            {
                FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
            }

        }
        #endregion NavigateLogic

        ACC_IncomeBAL bal_ACC_Income = new ACC_IncomeBAL();

        DataTable dt = bal_ACC_Income.SelectShow(FinYearID, HospitalID, IncomeTypeID);

        if (Request.QueryString["FinYearID"] != null && Request.QueryString["HospitalID"] != null && Request.QueryString["InconeTypeID"] != null)
        {
            ddlFinYearID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["FinYearID"]);
            ddlHospitalID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["HospitalID"]);
            ddlIncomeTypeID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["IncomeTypeID"]);
        }

        foreach (DataColumn dtc in dt.Columns)
        {
            dtc.AutoIncrement = false;
            dtc.AllowDBNull = true;
        }
        dt.AcceptChanges();

        int count = 10 - dt.Rows.Count;
        for (int i = 1; i <= count; i++)
        {
            dt.Rows.Add();
        }

        rpData.DataSource = dt;
        rpData.DataBind();
        Div_ShowResult.Visible = true;

    }

    #endregion 14.0 Show Button Event

    #region 15.0 Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            SqlInt32 FinYearID = SqlInt32.Null;
            SqlInt32 HospitalID = SqlInt32.Null;
            SqlInt32 IncomeTypeID = SqlInt32.Null;

            if (ddlHospitalID.SelectedIndex > 0)
            {
                FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
            }

            ACC_IncomeBAL bal_ACC_Income = new ACC_IncomeBAL();
            ACC_IncomeENT ent_ACC_Income = new ACC_IncomeENT();

            foreach (RepeaterItem items in rpData.Items)
            {
                try
                {
                    #region FindControl

                    TextBox txtAmount = (TextBox)items.FindControl("txtAmount");
                    TextBox txtIncomeDate = (TextBox)items.FindControl("txtIncomeDate");
                    HiddenField Hdfiled = (HiddenField)items.FindControl("hdIncomeID");
                    TextBox txtNote = (TextBox)items.FindControl("txtNote");
                    CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");


                    #endregion FindControl

                    #region 15.1.1 Gather Data
                    if (txtAmount.Text.ToString() != string.Empty)
                    {
                        ent_ACC_Income.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                        ent_ACC_Income.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                        ent_ACC_Income.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
                        ent_ACC_Income.Amount = Convert.ToDecimal(txtAmount.Text.ToString());
                        ent_ACC_Income.IncomeDate = Convert.ToDateTime(txtIncomeDate.Text.Trim());
                        ent_ACC_Income.Note = txtNote.Text.Trim();
                        ent_ACC_Income.UserID = Convert.ToInt32(Session["UserID"]);
                        ent_ACC_Income.Created = DateTime.Now;
                        ent_ACC_Income.Modified = DateTime.Now;
                    }
                    else
                    {
                        break;
                    }

                    #endregion 15.1.1 Gather Data

                    if (Hdfiled.Value != string.Empty)
                    {
                        if (chkIsSelected.Checked)
                        {
                            #region 15.1.2 Update Data
                            if (txtAmount.Text.Trim() == string.Empty)
                            {
                                txtAmount.Focus();
                                ucMessage.ShowError("Enter Amount");
                                break;
                            }
                            else
                            {
                                ent_ACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                if (bal_ACC_Income.Update(ent_ACC_Income))
                                {
                                    ucMessage.ShowSuccess(CommonMessage.RecordUpdated());
                                }
                            }

                            #endregion 15.1.2 Update Data
                        }
                        else
                        {
                            #region 15.1.3 Delete Data
                            if (txtAmount.Text.Trim() == string.Empty)
                            {
                                txtAmount.Focus();
                                ucMessage.ShowError("Enter Amount");
                                break;
                            }
                            else
                            {
                                ent_ACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                if (bal_ACC_Income.Delete(ent_ACC_Income.IncomeID))
                                {
                                    ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
                                }
                            }

                            #endregion 15.1.3 Delete Data
                        }
                    }
                    else
                    {
                        if (chkIsSelected.Checked)
                        {
                            #region 15.1.4 Insert Data
                            if (txtAmount.Text.Trim() == string.Empty && txtIncomeDate.Text.Trim() != string.Empty && txtNote.Text.Trim() != string.Empty)
                            {
                                txtAmount.Focus();
                                ucMessage.ShowError("Enter Amount");
                            }
                            else
                            {
                                if (txtAmount.Text.Trim() != string.Empty)
                                {
                                    if (bal_ACC_Income.Insert(ent_ACC_Income))
                                    {
                                        Div_ShowResult.Visible = false;
                                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                                    }
                                }
                            }
                            #endregion  15.1.4 Insert Data
                        }
                    }
                    Div_ShowResult.Visible = false;
                }
                catch (Exception ex)
                {
                    ucMessage.ShowError(ex.Message);
                }
            }
            ClearControls();
        }
    }

    #endregion 15.0 Save Button Event

    #region 16.0 Clear Controls
    private void ClearControls()
    {
        ddlFinYearID.SelectedIndex = 0;
        ddlHospitalID.SelectedIndex = 0;
        ddlIncomeTypeID.SelectedIndex = 0;
    }

    #endregion 16.0 Clear Controls

    #region 17.0 Add Row Button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Amount");
        dt.Columns.Add("Note");
        dt.Columns.Add("IncomeDate");
        dt.Columns.Add("IncomeID");

        foreach (RepeaterItem rp in rpData.Items)
        {
            TextBox txtAmount = (TextBox)rp.FindControl("txtAmount");
            TextBox txtNote = (TextBox)rp.FindControl("txtNote");
            TextBox txtIncomeDate = (TextBox)rp.FindControl("txtIncomeDate");
            HiddenField hdIncomeID = (HiddenField)rp.FindControl("hdIncomeID");

            DataRow dr = dt.NewRow();
            dr["Amount"] = txtAmount.Text.Trim();
            dr["Note"] = txtNote.Text.Trim();
            dr["IncomeDate"] = txtIncomeDate.Text.ToString();
            dr["IncomeID"] = hdIncomeID.ID;

            dt.Rows.Add(dr);
        }
        int count = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["Amount"].ToString() != String.Empty)
                count++;
        }
        if (count == dt.Rows.Count)
            dt.Rows.Add();

        rpData.DataSource = dt;
        rpData.DataBind();
    }
    #endregion 17.0 Add Row Button
}