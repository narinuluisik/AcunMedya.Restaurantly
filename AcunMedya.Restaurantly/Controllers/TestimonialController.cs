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
    public class TestimonialController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Testimonial

      
        public ActionResult TestimonialList()
        {

            var value = Db.Testimonials.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult TestimonialCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult TestimonialCreate(Testimonial model)
        {
            Db.Testimonials.Add(model);
            Db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult TestimonialEdit(int id)
        {
            var value = Db.Testimonials.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult TestimonialEdit(Testimonial model)
        {
            var value = Db.Testimonials.Find(model.TestimonialId);
            value.Name = model.Name;
            value.Title = model.Title;
            value.Description = model.Description;
            value.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult TestimonialDelete(int id)
        {
            var value = Db.Testimonials.Find(id);
            Db.Testimonials.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("TestimonialList");
        }

    }
}