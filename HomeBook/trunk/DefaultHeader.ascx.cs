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

public partial class DefaultHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        validationStart();
    }

    /// <summary>
    /// Проверка преди стартиране за влязъл потребител
    /// </summary>
    protected void validationStart() {

        if (Session["UserName"] != null)
        {
            txtAutirization.Text = "   Потребител: " + Session["UserName"].ToString();
        }
        else
        {
            txtAutirization.Text = "";
        }

        txtAutirization.Attributes.Add("style", "color:#696969;font-weight:bold;");
    
    }
}
