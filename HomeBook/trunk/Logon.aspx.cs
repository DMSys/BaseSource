using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Login_Logon : System.Web.UI.Page
{
  
    xData sql = new xData();

    protected void Page_Load(object sender, EventArgs e)
        
    {
        if (Session["UserName"] != null)
        {
            logOut();
            Response.AppendHeader("Refresh", "2");
            return;
        }

        this.cmdLogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);
    }

    /// <summary>
    /// Валидиране на потребителските данни
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="passWord"></param>
    /// <returns></returns>
    private bool ValidateUser(string userName, string passWord)
    {
         
        string lookupPassword = null;
        string lookupID       = null;

        // Чеква за грешен userName.
        // userName не трябва да бъде null и трябва да бъде между 1 и 15 символа.

        if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
        {
            lblMsg.Text = "Въведените данни за Име са грешни.";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            pnlLogon.Visible = true;
            return false;
        }

        // Чеква за грешна парола.
        // Паролата не трябва да бъде null и трябва да бъде между 1 и 25 символа.

        if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
        {
            lblMsg.Text      = "Въведените данни за парола са грешни.";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            pnlLogon.Visible = true;
            return false;
        }

        try
        {

            DataTable dataT    = new DataTable();
            string CommandText = "Select * from USERS where UserName='" + userName.ToString().Trim() + "'";
            dataT              = sql.ExecuteToDataTable(CommandText);
            lookupPassword     = (string)dataT.Rows[0]["Password"].ToString();
            lookupID           = dataT.Rows[0]["ID"].ToString();

        }
        catch (Exception ex)
        {
             new Exception("Неуспешен вход. Моля опитайте отново! Грешка: " + ex.Message) ;
                  
        }

        // Ако не е намерена парола връща false
        if (null == lookupPassword || passWord != lookupPassword)
        {
            lblMsg.Text = "Неуспешен вход. Моля опитайте отново!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
           
            pnlLogon.Visible = true;
            return false;
        }

        //ако влвзе тук значи успешно сме се логнали

        lblMsg.Text = "Вие влязохте успешно!";
        lblMsg.ForeColor = System.Drawing.Color.Green;
        lblMsg.Font.Bold = true;
        lblMsg.Font.Size = 12;
       
        Session["UserName"] = userName;
        Session["UserID"]   = lookupID;

        pnlLogon.Visible = false;

        // сравнение на lookupPassword и въведената passWord, с помощта на малки и главни букви.
        return (0 == string.Compare(lookupPassword, passWord, false));

    }
    /// <summary>
    /// Логване в системата
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cmdLogin_ServerClick(object sender, System.EventArgs e)
    {
        if (ValidateUser(txtUserName.Value, txtUserPass.Value))
        {
            FormsAuthenticationTicket FAutenTicket;
            string cookiestr;
            HttpCookie Cookies;

            FAutenTicket = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now,
            DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
            cookiestr = FormsAuthentication.Encrypt(FAutenTicket);

            Cookies = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
            if (chkPersistCookie.Checked)
                Cookies.Expires = FAutenTicket.Expiration;

            Cookies.Path = FormsAuthentication.FormsCookiePath;
            Response.Cookies.Add(Cookies);

            
            //string strRedirect;
            //strRedirect = Request["ReturnUrl"];
            //if (strRedirect == null)
               // strRedirect = "default.aspx";
            //Response.Redirect(strRedirect, true);
            
        }
       // else
          // Response.Redirect("logon.aspx", true);
    }

    /// <summary>
    /// Изход от системата 
    /// </summary>
    private void logOut() {

        Session.Clear();
        Session.Abandon();

        FormsAuthentication.SignOut();
        
        Session["UserName"] = null;
        Session["UserID"] = null;

        lblMsg.Text = "Вие излязохте успешно!!!";
        lblMsg.ForeColor = System.Drawing.Color.Green;
        lblMsg.Font.Bold = true;
        lblMsg.Font.Size = 12;
        pnlLogon.Visible = false;

    }
}