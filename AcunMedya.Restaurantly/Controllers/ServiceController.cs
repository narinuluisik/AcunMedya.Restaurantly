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
    public class ServiceController : Controller
    {

        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Service

       
        public ActionResult ServiceList()
        {

            var value = Db.Services.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ServiceCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ServiceCreate(Service model)
        {
            Db.Services.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public ActionResult ServiceEdit(int id)
        {
            var value = Db.Services.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult ServiceEdit(Service model)
        {
            var value = Db.Services.Find(model.ServiceId);
            value.Title = model.Title;
            value.Description = model.Description;
            Db.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public ActionResult ServiceDelete(int id)
        {
            var value = Db.Services.Find(id);
            Db.Services.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("ServiceList");
        }

    }
}