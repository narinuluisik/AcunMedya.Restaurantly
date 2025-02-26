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
    public class SpecialController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Category

       
        public ActionResult SpecialList()
        {

            var value = Db.Specials.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult SpecialCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SpecialCreate(Special model)
        {
            Db.Specials.Add(model);
            Db.SaveChanges();
            return RedirectToAction("SpecialList");
        }
        [HttpGet]
        public ActionResult SpecialEdit(int id)
        {
            var value = Db.Specials.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult SpecialEdit(Special model)
        {
            var value = Db.Specials.Find(model.SpecialId);
            value.Title = model.Title;
            value.ShortDescription = model.ShortDescription;
            value.FullDescription = model.FullDescription;
            value.ImageUrl = model.ImageUrl;
            Db.SaveChanges();
            return RedirectToAction("SpecialList");
        }
        public ActionResult SpecialDelete(int id)
        {
            var value = Db.Specials.Find(id);
            Db.Specials.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("SpecialList");
        }

    }
}