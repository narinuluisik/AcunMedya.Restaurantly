using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.Productcount = Db.Products.Count();
            ViewBag.CategoryCount = Db.Categories.Count();
            ViewBag.Chefcount = Db.Chefs.Count();
            ViewBag.SpecialCount = Db.Specials.Count();
            return View();
        }

        public PartialViewResult RezervasionPartial()
        {
            var value = Db.Reservations.ToList();
            return PartialView(value);

        }
    
        public PartialViewResult ChefPartial()
        {
            var value = Db.Chefs.ToList();
            return PartialView(value);
        }
        public ActionResult ChangeReservationStatus(int id, string status)
        {
            var reservation = Db.Reservations.Find(id);
            if (reservation != null)
            {
                reservation.ReservationStatus = status;
                Db.SaveChanges();
            }
            return RedirectToAction("Index"); // Listeyi tekrar yükle
        }

    }
}