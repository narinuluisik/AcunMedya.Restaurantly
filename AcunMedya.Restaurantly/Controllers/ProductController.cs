using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class ProductController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Product
        [Authorize]
        public ActionResult Index()
        {
            var value = Db.Products.ToList();
            return View(value);
        }
     
        public ActionResult ProductList()
        {

            var value = Db.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {

            List<SelectListItem> values = (from x in Db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product model)
        {
            Db.Products.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            var value = Db.Products.Find(id);
            List<SelectListItem> values = (from x in Db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;

            return View(value);
        }
        [HttpPost]
        public ActionResult ProductEdit(Product model)
        {
            var value = Db.Products.Find(model.ProductId);
            value.Name = model.Name;
            value.Description = model.Description;
            value.Price = model.Price;
            value.ImageUrl = model.ImageUrl;
            value.CategoryId = model.CategoryId;
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductDelete(int id)
        {
            var value = Db.Products.Find(id);
            Db.Products.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("ProductList");
        }
    }
}