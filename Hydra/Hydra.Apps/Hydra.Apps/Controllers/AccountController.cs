using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hydra.Apps.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/LogIn
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            // System.Web.Security.FormsAuthentication.SetAuthCookie("TestUser", false);
            return View();
        }

        //
        // GET: /Account/LogOut
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            // return Redirect("~/");
            return View();
        }
    }
}
