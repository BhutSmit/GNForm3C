using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminPanel_Account_ACC_Expense_ACC_ExpInm_LedgerList : System.Web.UI.Page
{
    String FormName = "MST_HospitalList";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);



        if (!Page.IsPostBack)
        {
            #region 12.1 DropDown List Fill Section

            FillDropDownList();

            SetDefaultDateTime();

            #endregion 12.1 DropDown List Fill Section

            Search(1);

            #region 12.2 Set Default Value

            lblSearchHeader.Text = CV.SearchHeaderText;
            lblSearchResultHeader.Text = CV.SearchResultHeaderText;
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 12.2 Set Default Value

            #region 12.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }


    }

    #region 13.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {
        CommonFunctions.GetDropDownPageSize(ddlPageSizeBottom);
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
    }

    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    #region 23.0 SetDefaultDateTime
    private void SetDefaultDateTime()
    {
        DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        dtpFromDate.Text = dateTime.Date.ToString("dd-MM-yyyy");
        dtpToDate.Text = Convert.ToDateTime(dateTime).AddMonths(1).AddDays(-1).Date.ToString("dd-MM-yyyy");
    }
    #endregion SetDefaultDateTime

    #region 15.0 Search

    #region 15.1 Button Search Click Event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function

    private void Search(int PageNo)
    {
        #region Parameters

        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        #endregion Parameters

        #region Gather Data

        if (dtpFromDate.Text.Trim() != String.Empty)
            FromDate = Convert.ToDateTime(dtpFromDate.Text.Trim());

        if (dtpToDate.Text.Trim() != String.Empty)
            ToDate = Convert.ToDateTime(dtpToDate.Text.Trim());

        #endregion Gather Data

        ExpInm_LedgerList_BAL bal_ExpInm_LedgerList = new ExpInm_LedgerList_BAL();

        DataTable dt = bal_ExpInm_LedgerList.SelectPage(Offset, PageRecordSize, out TotalRecords, FromDate, ToDate);

        if (PageRecordSize == 0 && dt.Rows.Count > 0)
        {
            PageRecordSize = dt.Rows.Count;
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));
        }
        else
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));

        if (dt != null && dt.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
            rpData.DataSource = dt;
            rpData.DataBind();

            if (PageNo > TotalPages)
                PageNo = TotalPages;

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;

            CommonFunctions.BindPageList(TotalPages, TotalRecords, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            lblRecordInfoBottom.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);
            lblRecordInfoTop.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);


            if (TotalRecords <= CV.SmallestPageSize)
            {
                Div_Pagination.Visible = false;
                Div_GoToPageNo.Visible = false;
                Div_PageSize.Visible = false;
            }
            else
            {
                Div_Pagination.Visible = true;
                Div_GoToPageNo.Visible = true;
                Div_PageSize.Visible = true;
            }
        }

        else if (TotalPages < PageNo && TotalPages > 0)
            Search(TotalPages);

        else
        {
            Div_SearchResult.Visible = false;

            ViewState["TotalPages"] = 0;
            ViewState["CurrentPage"] = 1;

            rpData.DataSource = null;
            rpData.DataBind();

            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();

            CommonFunctions.BindPageList(0, 0, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events

    #region 17.0 Pagination

    #region 17.1 Pagination Events

    #region ItemDataBound Event

    protected void rpPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lb = (LinkButton)e.Item.FindControl("lbtnPageNo");
            HtmlGenericControl hgc = (HtmlGenericControl)e.Item.FindControl("liPageNo");
            if (Convert.ToInt32(ViewState["CurrentPage"]) == Convert.ToInt32(lb.CommandArgument))
            {
                hgc.Attributes["class"] = CSSClass.PaginationButtonActive;
                lb.Enabled = false;
            }
            else
                hgc.Attributes["class"] = CSSClass.PaginationButton;
        }
    }

    #endregion ItemDataBound Event

    #region PageChange Event

    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        String Name = lbtn.CommandName.ToString();

        if (Name == "PageNo" || Name == "FirstPage")
            Search(Value);

        else if (Name == "PreviousPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) - Value);

        else if (Name == "NextPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) + Value);

        else if (Name == "LastPage")
            Search(Convert.ToInt32(ViewState["TotalPages"]));

        else if (Name == "GoPageNo")
        {
            if (txtPageNo.Text.Trim() == String.Empty)
            {
                ucMessage.ShowError(CommonMessage.ErrorRequiredField("Page No"));
                return;
            }
            else
            {
                Value = Convert.ToInt32(txtPageNo.Text);
                if (Value > Convert.ToInt32(ViewState["TotalPages"]))
                {
                    ucMessage.ShowError(CommonMessage.ErrorInvalidField("Page No"));
                    return;
                }
                Search(Value);
            }
        }
    }

    #endregion PageChange Event

    #endregion 17.1 Pagination Events

    #endregion 17.0 Pagination

    #region 18.0 Button Delete Click Event


    #endregion 18.0 Button Delete Click Event

    #region 19.0 Export Data

    #region 19.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        //LinkButton lbtn = (LinkButton)(sender);
        //String ExportType = lbtn.CommandArgument.ToString();

        //int TotalReceivedRecord = 0;

        //SqlInt32 ExpenseTypeID = SqlInt32.Null;
        //SqlDecimal Amount = SqlDecimal.Null;
        //SqlDateTime ExpenseDate = SqlDateTime.Null;
        //SqlInt32 HospitalID = SqlInt32.Null;
        //SqlInt32 FinYearID = SqlInt32.Null;
        //SqlString TagName = SqlString.Null;

        //if (ddlExpenseTypeID.SelectedIndex > 0)
        //    ExpenseTypeID = Convert.ToInt32(ddlExpenseTypeID.SelectedValue);

        //if (txtAmount.Text.Trim() != String.Empty)
        //    Amount = Convert.ToDecimal(txtAmount.Text.Trim());

        //if (dtpExpenseDate.Text.Trim() != String.Empty)
        //    ExpenseDate = Convert.ToDateTime(dtpExpenseDate.Text.Trim());

        //if (ddlHospitalID.SelectedIndex > 0)
        //    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

        //if (ddlFinYearID.SelectedIndex > 0)
        //    FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

        //if (dtpTagName.Text.Trim() != String.Empty)
        //    TagName = Convert.ToString(dtpTagName.Text.Trim());


        //Int32 Offset = 0;

        //if (ViewState["CurrentPage"] != null)
        //    Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        //ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();
        //DataTable dtACC_Expense = balACC_Expense.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, ExpenseTypeID, Amount, ExpenseDate, HospitalID, FinYearID, TagName);
        //if (dtACC_Expense != null && dtACC_Expense.Rows.Count > 0)
        //{
        //    Session["ExportTable"] = dtACC_Expense;
        //    Response.Redirect("~/Default/Export.aspx?ExportType=" + ExportType);
        //}
    }

    #endregion 19.1 Excel Export Button Click Event

    #endregion 19.0 Export Data

    #region 20.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    #endregion 20.0 Cancel Button Event

    #region 21.0 ddlPageSize Selected Index Changed Event

    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    protected void ddlPageSizeTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    #endregion 21.0 ddlPageSize Selected Index Changed Event

    #region 22.0 ClearControls

    private void ClearControls()
    {
        dtpFromDate.Text = String.Empty;
        dtpToDate.Text = String.Empty;
        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls

    #region 23.0 Fill Finyear Dropdown From Hopital
    protected void ddlHospitalID_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //if (ddlHospitalID.SelectedIndex > 0)
        //{
        //    ddlExpenseTypeID.SelectedIndex = 0;
        //    SqlInt32 HospitalID = SqlInt32.Null;

        //    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
        //    CommonFillMethods.FillDropDownListExpenseFinYearIDByHospitalID(ddlFinYearID, HospitalID);

        //}
        //else
        //{
        //    ddlFinYearID.Items.Clear();
        //    ddlFinYearID.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
        //    ddlExpenseTypeID.Items.Clear();
        //    ddlExpenseTypeID.Items.Insert(0, new ListItem("Select Expense Type", "-99"));

        //}
    }
    #endregion 23.0 Fill Finyear Dropdown From Hopital

    //#region 24.0 Fill ExpenseType Dropdown From Finyear
    protected void ddlFinYearID_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //if (ddlFinYearID.SelectedIndex > 0)
        //{
        //    SqlInt32 FinYearID = SqlInt32.Null;
        //    SqlInt32 HospitalID = SqlInt32.Null;

        //    FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
        //    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
        //    CommonFillMethods.FillDropDownListExpenseTypeIDByFinYearID(ddlExpenseTypeID, FinYearID, HospitalID);

        //}
        //else
        //{
        //    ddlExpenseTypeID.Items.Clear();
        //    ddlExpenseTypeID.Items.Insert(0, new ListItem("Select Income Type", "-99"));
        //}
    }
}