using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Odrys.Areas.Admin.Controllers
{
    //[Authorize(Users = "Jacquo, Steve", Roles = "Admin, SuperUser")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class DashboardController : Controller
    {
        //
        // GET: /Admin/Dashboard/

        public ActionResult Index()
        {
            return View();
        }

    }
}
