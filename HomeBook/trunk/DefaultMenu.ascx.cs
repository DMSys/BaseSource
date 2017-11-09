using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Menu : System.Web.UI.UserControl
{
    protected string InputValue { get; set; } 

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Session["UserName"] != null)
        {
            this.InputValue = "Изход";

        }
        else
        { this.InputValue = "Вход"; }
    }

    /// <summary>
    /// Бутон Рефреш
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        startWithDemo();
    }

    protected void startWithDemo()
    {
        if (Session["UserName"] != null || Session["UserID"] != null)
        {
          
            Session["UserName"] = null;
            Session["UserID"] = null;
        }
      
        Session["UserName"] = "Demo";
        Session["UserID"] = 1;
        Response.Redirect("Default.aspx", true);
    }
}
