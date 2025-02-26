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
    public class ReservationController : Controller
    {
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Reservation

        public ActionResult ReservationList()
        {

            var value = Db.Reservations.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ReservationCreate()
        { 
       List<SelectListItem> statusList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Beklemede", Value = "Beklemede" },
        new SelectListItem { Text = "Onaylandı", Value = "Onaylandı" },
        new SelectListItem { Text = "İptal Edildi", Value = "İptal Edildi" }
    };

        ViewBag.StatusList = statusList;
        
            return View();
          
        }
        [HttpPost]
        public ActionResult ReservationCreate(Reservation model)
        {
            Db.Reservations.Add(model);
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public ActionResult ReservationEdit(int id)
        {

            List<SelectListItem> statusList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Beklemede", Value = "Beklemede" },
        new SelectListItem { Text = "Onaylandı", Value = "Onaylandı" },
        new SelectListItem { Text = "İptal Edildi", Value = "İptal Edildi" }
    };

            ViewBag.StatusList = statusList;
            var value = Db.Reservations.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult ReservationEdit(Reservation model)
        {


            var value = Db.Reservations.Find(model.ReservationId);
            value.Name = model.Name;
            value.Email = model.Email;
            value.Phone = model.Phone;
            value.Description = model.Description;
            value.ReservationDate = model.ReservationDate;
            value.Time = model.Time;
            value.GuestCount = model.GuestCount;
            value.ReservationStatus = model.ReservationStatus;
         
            Db.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ReservationDelete(int id)
        {
            var value = Db.Reservations.Find(id);
            Db.Reservations.Remove(value);
            Db.SaveChanges();


            return RedirectToAction("ReservationList");
        }

    }
}