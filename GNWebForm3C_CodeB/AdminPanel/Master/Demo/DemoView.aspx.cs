using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_Demo_DemoView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserID"] == null)
        {
            Response.Redirect(CV.LoginPageURL);
        }

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                FillControl();
            }
        }
    }

    public void FillControl()
    {
        if (Request.QueryString["Id"] != null)
        {
            Demo_BAL bal_Demo = new Demo_BAL();
            DataTable dt = bal_Demo.SelectByPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["Id"]));

            foreach (DataRow dr in dt.Rows)
            {
                if (!dr["Id"].Equals(DBNull.Value))
                {
                    lblId.Text = dr["Id"].ToString();
                }

                if (!dr["Name"].Equals(DBNull.Value))
                {
                    lblName.Text = dr["Name"].ToString();
                }
            }
        }
    }

}
