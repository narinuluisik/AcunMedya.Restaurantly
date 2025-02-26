using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Category

      
        public ActionResult  EventList()
        {

            var value = Db.Events.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult EventCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EventCreate(Event model)
        {
            Db.Events.Add(model);
            Db.SaveChanges();
            return RedirectToAction("EventList");
        }
        [HttpGet]
        public ActionResult EventEdit(int id)
        {
            var value = Db.Events.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EventEdit(Event model)
        {
            var value = Db.Events.Find(model.EventId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.Price = model.Price;
            value.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("EventList");
        }
        public ActionResult EventDelete(int id)
        {
            var value = Db.Events.Find(id);
            Db.Events.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("EventList");
        }

    }
}