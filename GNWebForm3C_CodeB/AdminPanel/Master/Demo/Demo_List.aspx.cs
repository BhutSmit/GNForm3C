using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_Demo_Demo_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        Demo_BAL bal_Demo = new Demo_BAL();
        DataTable dt = bal_Demo.SelectAll();

        if(dt != null && dt.Rows.Count > 0)
        {
            rpData.DataSource = dt;
            rpData.DataBind();

        }

    }

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "DeleteRecord")
        //{
        //    try
        //    {
        //        //MST_HospitalBAL balMST_Hospital = new MST_HospitalBAL();
        //        //if (e.CommandArgument.ToString().Trim() != "")
        //        //{
        //        //    if (balMST_Hospital.Delete(Convert.ToInt32(e.CommandArgument)))
        //        //    {
        //        //        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());

        //        //        if (ViewState["CurrentPage"] != null)
        //        //        {
        //        //            int Count = rpData.Items.Count;

        //        //            if (Count == 1 && Convert.ToInt32(ViewState["CurrentPage"]) != 1)
        //        //                ViewState["CurrentPage"] = (Convert.ToInt32(ViewState["CurrentPage"]) - 1);
        //        //            Search(Convert.ToInt32(ViewState["CurrentPage"]));
        //        //        }
        //        //    }
        //        //}
        //    }
        //    //catch (Exception ex)
        //    //{
        //    //    ucMessage.ShowError(ex.Message.ToString());
        //    //}
        //}
    }
}