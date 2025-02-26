using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class İstatistikController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: İstatistik
        public ActionResult Index()
        {
            ViewBag.Rezervasioncount = Db.Reservations.Count();
            ViewBag.Eventcount = Db.Events.Count();
            ViewBag.Servicecount = Db.Services.Count();
            ViewBag.Testimonialcount = Db.Testimonials.Count();
            ViewBag.Contactcount = Db.Contacts.Count();
            ViewBag.Galericount = Db.Galleries.Count();
            ViewBag.Notificationcount = Db.Notifications.Count();
            ViewBag.MaxPrice = Db.Products.Max(x => x.Price);
            ViewBag.MinPrice = Db.Products.Min(x => x.Price); 
            ViewBag.AvgPrice = Db.Products.Average(x => x.Price);

            //// **En Pahalı Etkinlik**
            //var expensiveEvent = Db.Events.OrderByDescending(x => x.Price)
            //                              .Select(x => new { x.Title, x.Price })
            //                              .FirstOrDefault();

            var expensiveEvent = Db.Events.OrderByDescending(x => x.Price).FirstOrDefault();
            ViewBag.MostExpensiveEventTitle = expensiveEvent.Title;
            ViewBag.MostExpensiveEventPrice = expensiveEvent.Price + " ₺";


            ViewBag.MostProductCategory = Db.Products.GroupBy(p => p.CategoryId)
                                             .OrderByDescending(g => g.Count())
                                             .Select(g => Db.Categories.Where(c => c.CategoryId == g.Key)
                                                                       .Select(c => c.CategoryName)
                                                                       .FirstOrDefault())
                                             .FirstOrDefault();


            return View();
        }
    }
}