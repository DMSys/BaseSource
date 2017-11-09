using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odrys.Models;
using System.Web.Security;

namespace Odrys.Controllers
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
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }

        //
        // GET: /Account/
        [HttpPost]
        public ActionResult Login(AccountLoginModel model, string returnUrl)
        {
            // Валидация
            if ((model == null) || (model.LoginID == null))
            {
                ModelState.AddModelError("", "Въведете потребител");
                return View();
            }
            if (model.Password == null)
            {
                ModelState.AddModelError("", "Въведете парола");
                return View();
            }
            AccountModel account = null;
            using (AccountContext context = new AccountContext())
            {
                account = context.GetAccount(model);
            }
            if (account == null)
            {
                ModelState.AddModelError("", "Грешна парола или потребител");
                return View(); 
            }

            HttpSession.UserID = account.ID;
            var authTicket = new FormsAuthenticationTicket(
                1,                             // version
                account.LoginID,               // user name
                DateTime.Now,                  // created
                DateTime.Now.AddMinutes(20),   // expires
                model.RememberMe,              // persistent?
                account.Roles                  // can be used to store roles
                );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

            return RedirectToLocal(returnUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
