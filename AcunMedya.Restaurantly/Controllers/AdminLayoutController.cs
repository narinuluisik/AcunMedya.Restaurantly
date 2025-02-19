using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class AdminLayoutController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
           ViewBag.notificationIsReadByFalseCount = Db.Notifications.Where(x => x.IsRead == "False").Count();
            var values = Db.Notifications.Where(x=>x.IsRead=="False").ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var value = Db.Notifications.Find(id);
            value.IsRead = "True";
            Db.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }
    }
}