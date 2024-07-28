using GNForm3C;
using GNForm3C.BAL;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_Demo_DemoAddEdit : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {



    }

    public void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        Demo_BAL bal_Demo = new Demo_BAL();
        if (Page.IsValid)
        {
            String ErrorMsg = String.Empty;

            if (txtYearName.Text.Trim() == String.Empty)
                ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Print Name");

            if (ErrorMsg != String.Empty)
            {
                ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                ucMessage.ShowError(ErrorMsg);
                return;
            }
        }

        if (txtYearName.Text.Trim() == String.Empty)
        {
            txtYearName.Text = txtYearName.Text.Trim();
        }

        if (Request.QueryString["Id"] == null)
        {
            bal_Demo.Insert(txtYearName.Text);
            //if (bal_Demo.Insert(txtYearName.Text))
            //{
            //    Response.Redirect("Demo_List.aspx");
            //}
        }

    }

}