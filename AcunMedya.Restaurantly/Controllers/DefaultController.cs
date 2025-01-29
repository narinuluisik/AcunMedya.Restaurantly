using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class DefaultController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialTop()
        {
            ViewBag.Call = Db.Adresss.Select(x => x.Call).FirstOrDefault();
            ViewBag.OpenHours= Db.Adresss.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.SubTitle = Db.Features.Select(x => x.SubTitle).FirstOrDefault();
            ViewBag.Title = Db.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.VideoUrl = Db.Features.Select(x => x.VideoUrl).FirstOrDefault();
           // ViewBag.OpenHours = Db.Adresss.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.Title = Db.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = Db.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.ImageUrl = Db.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            var values = Db.Services.ToList();
            return PartialView(values);
        }

    
        public PartialViewResult PartialMenu()
        {
            var value = Db.Products.ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult ContactAdd(Contact model)
        {
            model.SendDate = DateTime.Now;
            model.IsRead = false;
            Db.Contacts.Add(model);
            Db.SaveChanges();
            ViewBag.Message = "Mesaj Başarılı";
            return View("Index");

        }

        public PartialViewResult PartialSpecial()
        {
            var values = Db.Specials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialBookaTable()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddBookaTable(Reservation model)
        {
            model.ReservationDate = DateTime.Now;
            model.ReservationStatus = "Beklemede";
            Db.Reservations.Add(model);
            Db.SaveChanges();
            ViewBag.Message = "Rezervasyon Başarılı";
            return View("Index");

        }

        public PartialViewResult PartialTestimonial()
        {
            var values = Db.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialChef()
        {
            var values = Db.Chefs.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAddress()
        {

            ViewBag.Location = Db.Adresss.Select(x => x.Location).FirstOrDefault();
            ViewBag.Email = Db.Adresss.Select(x => x.Email).FirstOrDefault();
            ViewBag.Call = Db.Adresss.Select(x => x.Call).FirstOrDefault();
            ViewBag.OpenHours = Db.Adresss.Select(x => x.OpenHours).FirstOrDefault();
            return PartialView();
        }
    }
}