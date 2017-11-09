using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hydra.Apps.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            // ViewBag.TestIsAuthenticated = Request.IsAuthenticated;
            // System.Web.Security.FormsAuthentication.SetAuthCookie("TestUser", true);

            return View();
        }

        //
        // GET: /Home/About

        public ActionResult About()
        {
            return View();
        }
    }
}
