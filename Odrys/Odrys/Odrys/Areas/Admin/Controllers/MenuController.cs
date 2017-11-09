using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odrys.Areas.Admin.Models;

namespace Odrys.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class MenuController : Controller
    {
        public MenuController()
        {
            ViewBag.PageMenu = "page_settings";
        }

        //
        // GET: /Admin/Menu/

        public ActionResult Index()
        {
            // Списък на менюта
            List<MenuModel> menus = null;
            using (MenuContext context = new MenuContext())
            {
                menus = context.GetMenus(HttpSession.CurrentSiteID);
            }
            return View(menus);
        }

        //
        // GET: /Admin/Menu/Edit

        public ActionResult Edit(int id = 0)
        {
            MenuModel menu = null;
            using (MenuContext context = new MenuContext())
            {
                menu = context.GetMenu(id);
            }
            return View(menu);
        }

        //
        // POST: /Admin/Site/Edit

        [HttpPost]
        public ActionResult Edit(MenuModel menu)
        {
            if (ModelState.IsValid)
            {
                using (MenuContext context = new MenuContext())
                {
                    context.SetMenu(menu);
                }
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        //
        // GET: /Admin/Menu/Items

        public ActionResult Items(int id = 0)
        {
            List<MenuItemModel> menuItems  = null;
            using (MenuContext context = new MenuContext())
            {
                menuItems = context.GetMenuItems(id);
            }
            return View(menuItems);
        }

        //
        // GET: /Admin/Menu/ItemEdit

        public ActionResult ItemEdit(int id = 0)
        {
            MenuItemModel menuItem = null;
            using (MenuContext context = new MenuContext())
            {
                menuItem = context.GetMenuItem(id);

                //ViewBag.MenuItemTypes = context.GetMenuItemTypes(menuItem.TypeID);
            }
            return View(menuItem);
        }

        //
        // POST: /Admin/Site/ItemEdit

        [HttpPost]
        public ActionResult ItemEdit(MenuItemModel menuItem)
        {
            if (ModelState.IsValid)
            {
                using (MenuContext context = new MenuContext())
                {
                    context.SetMenuItem(menuItem);
                }
                return RedirectToAction("Items", new { id = menuItem.MenuID });
            }
            return View(menuItem);
        }

        //
        // GET: /Admin/Menu/Sorting

        public ActionResult Sorting(int id = 0)
        {
            MenuModel menu = null;
            using (MenuContext context = new MenuContext())
            {
                menu = context.GetMenu(id);
            }
            return View(menu);
        }

        //
        // POST: /Admin/Menu/Sorting

        [HttpPost]
        public ActionResult Sorting(int id = 0, string sortlist = "")
        {
            try
            {
                string[] separator = new string[3] { "item[", "&item[", "]=" };
                string[] tempArray = sortlist.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                // Брой на елементите
                int itemCount = tempArray.Length / 2;
                // масива трябва да има четен брой елементи
                if ((((double)tempArray.Length) / 2) > itemCount)
                {
                    return Content("Грешка при запис");
                }
                using (MenuContext context = new MenuContext())
                {
                    for (int i = 0; i < tempArray.Length / 2; i++)
                    {
                        int itemID = Int32.Parse(tempArray[(2 * i)].Replace("null", "-1"));
                        int parentID = Int32.Parse(tempArray[(2 * i + 1)].Replace("null", "-1"));
                        int orderNo = i + 1;
                        context.SetSortItem(id, itemID, parentID, orderNo);
                    }
                }
                return Content("Успешен запис");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
