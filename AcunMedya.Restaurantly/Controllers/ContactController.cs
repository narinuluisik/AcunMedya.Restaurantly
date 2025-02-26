using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        RestaurantlyContext Db = new RestaurantlyContext();
        public ActionResult Index()
        {
            var messages = Db.Contacts
          .Where(c => !c.IsDeleted) // Sadece silinmemiş mesajlar
          .OrderByDescending(c => c.SendDate)
          .ToList();

            var gelenmessagecount = Db.Contacts.Where(x=>x.IsDeleted==false).Count();
            ViewBag.gelenmessagecount = gelenmessagecount;
            return View(messages);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var message = Db.Contacts.Find(id);
            if (message != null)
            {
                message.IsDeleted = true;  // Çöp kutusuna taşındı
                Db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //çöp kutusu için
        public ActionResult Trash()
        {
            var deletedMessages = Db.Contacts
                .Where(c => c.IsDeleted) 
                .OrderByDescending(c => c.SendDate)
                .ToList();

            return View(deletedMessages);
        }

    }
}