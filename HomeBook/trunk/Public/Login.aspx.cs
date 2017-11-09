using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Public_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login_Click(object sender, EventArgs e)
    {
        if (UserAuthentication(logInHBook.UserName, logInHBook.Password))
        {
            FormsAuthentication.SetAuthCookie(logInHBook.UserName, logInHBook.RememberMeSet);
            Response.Redirect("~/Default.aspx", true);
        }
        else
        {
            FormsAuthentication.SignOut();
        }
    }

    private bool UserAuthentication(string userName, string password)
    {
        return true;
    }
}