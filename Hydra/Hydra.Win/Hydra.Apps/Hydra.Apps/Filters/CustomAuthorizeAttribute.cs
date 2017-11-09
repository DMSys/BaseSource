using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace System.Web.Mvc
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            SetAuthCookie(httpContext, "TestUser", new string[] { "admin" });
            System.Web.Security.FormsAuthentication.SetAuthCookie("TestUser", false);
            /*
            if (!httpContext.Request.IsAuthenticated)
            {
                SetAuthCookie(httpContext,"TestUser", new string[] {"admin"} );
                // FormsAuthentication.SetAuthCookie(httpContext.User.Identity.Name, false);
            }*/
            return true;
            /*
            bool isLogin = false;
            if (xSession.UAccount == null)
            {
                string idAccount = "";
                object id = httpContext.Request.RequestContext.RouteData.Values["id"];
                if (id != null)
                {
                    idAccount = id.ToString().Trim();
                    // object deviceId = httpContext.Request.RequestContext.RouteData.Values["deviceId"];
                }
                else if ((httpContext.User != null)
                  && (httpContext.User.Identity != null)
                  && (httpContext.User.Identity.Name != null)
                  && (httpContext.User.Identity.Name != "")
                  && (httpContext.User.Identity.IsAuthenticated))
                {
                    idAccount = httpContext.User.Identity.Name.Trim();
                }
                else
                { return false; }

                xMobile.Models.UserAccount uAccount = null;
                using (xMobile.Models.AccountModel account = new xMobile.Models.AccountModel())
                {
                    uAccount = account.GetUserAccount(idAccount);
                }
                if (uAccount == null)
                { return false; }
                else
                {
                    xSession.UAccount = uAccount;
                    System.Web.Security.FormsAuthentication.SetAuthCookie(uAccount.IdAccount, true);
                    isLogin = true;
                }
            }
            else
            { isLogin = true; }

            if (isLogin && this.Roles != "")
            {
                return (this.Roles.IndexOf(xSession.UAccount.Role) > -1);
            }
            else
            { return isLogin; }
            */
        }

        private void SetAuthCookie(HttpContextBase httpContext, string userName, string[] roles)
        {
            var userData = string.Join(",", roles); //could JsonConvert.SerializeObject(obj)
            var authTicket = new FormsAuthenticationTicket(
                  1, //version
                  userName,
                  DateTime.Now, //issue date
                  DateTime.Now.AddMinutes(30), //expiration
                  false,  //isPersistent
                  userData,
                  FormsAuthentication.FormsCookiePath); //cookie path
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                        FormsAuthentication.Encrypt(authTicket));
            httpContext.Response.Cookies.Add(cookie);
        }
    }
}