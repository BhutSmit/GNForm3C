using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Default2 : System.Web.UI.Page
{

    #region variable

    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page

    #endregion variable

    private SqlInt32 HospitalID = SqlInt32.Null;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login 

        #region 11.2 Set Help Text

        //ucHelp.ShowHelp("Help Text will be shown here");

        #endregion 11.2 Set Help Text 

        if (!Page.IsPostBack)
        {

            FillDropDownList();
        }

        //Search();

    }

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {

        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
    }

    #endregion 14.1 Fill DropDownList   

    #endregion 14.0 DropDownList

    #region 15.1 Button Search Click Event

    protected void btnShow_Click(object sender, EventArgs e)
    {
        Search();
    }

    #endregion 15.1 Button Search Click Event

    #region DropDown Change
    protected void displayChange(object sender, EventArgs e)
    {
        if (ddlHospitalID.SelectedIndex <= 0)
        {
            upDashboard.Visible = false;
        }
    }

    #endregion
    private void Search()
    {
        #region Parameters

        SqlInt32 HospitalID = SqlInt32.Null;

        #endregion Parameters

        #region Gather Data

        if (ddlHospitalID.SelectedIndex > 0)
        {
            HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
            upDashboard.Visible = true;
            upCount.Visible = true;
            IncomeExpenseGrid.Visible = true;
        }


        #endregion

        #region 11.3 Total Count
        MST_CountBAL bal_MST_Count = new MST_CountBAL();
        DataTable dt = bal_MST_Count.SelectCount(HospitalID);

        if (dt.Rows.Count > 0)
        {
            lblIncomeCount.Text = dt.Rows[0]["TotalIncomeCount"].ToString();
            lblExpenseCount.Text = dt.Rows[0]["TotalExpenseCount"].ToString();
            lblPatientCount.Text = dt.Rows[0]["PatientCount"].ToString();
        }
        else
        {
            lblIncomeCount
        }

        #endregion

        #region Calender Table

        ACC_IncomeBAL bal_ACC_Income = new ACC_IncomeBAL();
        DataTable dt_ACC_Income = bal_ACC_Income.SelectByHospital(HospitalID);


        if (dt_ACC_Income.Rows.Count > 0)
        {
            IncomeGrid.DataSource = MakeCalenderData(dt_ACC_Income, "IncomeDate");
            IncomeGrid.DataBind();
        }
        else
        {
            lblNoIncomeRecord.Visible = true;
            IncomeGrid.Visible = false;
        }


        ACC_ExpenseBAL bal_ACC_Expense = new ACC_ExpenseBAL();
        DataTable dt_ACC_Expense = bal_ACC_Expense.SelectByHospital(HospitalID);

        if (dt_ACC_Expense.Rows.Count > 0)
        {
            ExpenseGrid.DataSource = MakeCalenderData(dt_ACC_Expense, "ExpenseDate");
            ExpenseGrid.DataBind();
        }
        else
        {
            lblNoExpenseRecord.Visible = true;
            ExpenseGrid.Visible = false;
        }

        #endregion

        #region TreatmentSummary

        MST_TreatmentBAL bal_MST_Treatment = new MST_TreatmentBAL();

        DataTable dt_MST_Treatment = bal_MST_Treatment.SelectTreatmentWiseSummary(HospitalID);
        
        if(dt_MST_Treatment.Rows.Count > 0)
        {
            TreatmentSummaryGrid.DataSource = dt_MST_Treatment;
            TreatmentSummaryGrid.DataBind();
        }
        else
        {
            lblNoTreatmentSummary.Visible = true;
            TreatmentSummaryGrid.Visible = false;
        }
        


        #endregion
    }

    private DataTable MakeCalenderData(DataTable dt, string dateColumn)
    {
        DataTable calendarTable = new DataTable();
        calendarTable.Columns.Add("Date", typeof(object));
        calendarTable.Columns.Add("January", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("February", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("March", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("April", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("May", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("June", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("July", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("August", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("September", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("October", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("November", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("December", typeof(decimal)).DefaultValue = 0;
        calendarTable.Columns.Add("Total", typeof(decimal)).DefaultValue = 0;

        for (int i = 1; i <= 31; i++)
        {
            DataRow row = calendarTable.NewRow();
            row["Date"] = i;
            calendarTable.Rows.Add(row);
        }

        foreach (DataRow row in dt.Rows)
        {
            DateTime Date = (DateTime)row[dateColumn];
            decimal amount = (decimal)row["Amount"];
            int day = Date.Day;
            string month = Date.ToString("MMMM");

            DataRow[] calendarRows = calendarTable.Select(string.Format("Date = {0}", day));
            if (calendarRows.Length > 0)
            {
                if (calendarRows[0][month] != DBNull.Value)
                {
                    calendarRows[0][month] = (decimal)calendarRows[0][month] + amount;
                }
                else
                {
                    calendarRows[0][month] = amount;
                }
            }
        }

        DataRow totalRow = calendarTable.NewRow();
        totalRow["Date"] = "Total";

        foreach (DataColumn column in calendarTable.Columns)
        {
            if (column.DataType == typeof(decimal) && column.ColumnName != "Date")
            {

                totalRow[column.ColumnName] = calendarTable.AsEnumerable()
                    .Sum(row => row.Field<decimal>(column.ColumnName));
            }
        }

        calendarTable.Rows.Add(totalRow);

        return calendarTable;
    }

    private DataTable SummarizeDataByMonth(DataTable dt, string dateColumn, string amountColumn)
    {
        DataTable summaryTable = new DataTable();
        summaryTable.Columns.Add("Month", typeof(string));
        summaryTable.Columns.Add("Total", typeof(decimal));

        for (int month = 1; month <= 12; month++)
        {
            DataRow row = summaryTable.NewRow();
            row["Month"] = new DateTime(2024, month, 1).ToString("MMMM");
            row["Total"] = dt.AsEnumerable()
                             .Where(r => ((DateTime)r[dateColumn]).Month == month)
                             .Sum(r => (decimal)r[amountColumn]);
            summaryTable.Rows.Add(row);
        }

        return summaryTable;
    }
}