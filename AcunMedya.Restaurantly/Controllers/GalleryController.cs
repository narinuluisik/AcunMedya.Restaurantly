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
    public class GalleryController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Gallery

       
        public ActionResult GalleryList()
        {

            var value = Db.Galleries.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult GalleryCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult GalleryCreate(Gallery model)
        {
            Db.Galleries.Add(model);
            Db.SaveChanges();
            return RedirectToAction("GalleryList");
        }
        [HttpGet]
        public ActionResult GalleryEdit(int id)
        {
            var value = Db.Galleries.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult GalleryEdit(Gallery model)
        {
            var value = Db.Galleries.Find(model.GalleryId);
            value.Title = model.Title;
            value.ImageUrl = model.ImageUrl;
            value.Time = model.Time;
            Db.SaveChanges();
            return RedirectToAction("GalleryList");
        }
        public ActionResult GalleryDelete(int id)
        {
            var value = Db.Galleries.Find(id);
            Db.Galleries.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("GalleryList");
        }

    }
}