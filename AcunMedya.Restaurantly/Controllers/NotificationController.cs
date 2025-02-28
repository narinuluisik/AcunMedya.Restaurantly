using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        RestaurantlyContext Db = new RestaurantlyContext();
        public ActionResult NotificationList()
        {
            var value = Db.Notifications.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult NotificationCreate()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult NotificationCreate(Notification model)
        {
            Db.Notifications.Add(model);
            Db.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        [HttpGet]
        public ActionResult NotificationEdit(int id)
        {
            var value = Db.Notifications.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult NotificationEdit(Notification model)
        {
            var value = Db.Notifications.Find(model.NotificationId);
            value.Title = model.Title;
            value.Time = model.Time;
            value.Icon = model.Icon;
            value.Iconcolor = model.Iconcolor;
   

            Db.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        public ActionResult NotificationDelete(int id)
        {
            var value = Db.Notifications.Find(id);
            Db.Notifications.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("NotificationList");
        }

    }
}