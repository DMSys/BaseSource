using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Odrys
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // Ако има право на достъп, трябва да има и UserID
            if (HttpSession.IsAuthenticated && (HttpSession.UserID == 0))
            { 
                FormsAuthentication.SignOut();
                string loginUrl = FormsAuthentication.LoginUrl + "?ReturnUrl=" +
                    HttpUtility.UrlEncode(Request.FilePath);
                Response.Redirect(loginUrl, true);
            }
            // Ако няма ID на саита
            if (HttpSession.CurrentSiteID == 0)
            {
                HttpSession.CurrentSiteID = AdminHelpers.GetMainSiteID();
            }
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || authCookie.Value == "")
            { return; }

            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch
            {
                return;
            }

            // retrieve roles from UserData
            string[] roles = authTicket.UserData.Split(';');

            if (Context.User != null)
            { Context.User = new System.Security.Principal.GenericPrincipal(Context.User.Identity, roles); }
        }
    }
}