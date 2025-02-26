using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile

        RestaurantlyContext Db = new RestaurantlyContext();
       
        [HttpGet]
        public ActionResult Index()
        {
            if(Session["id"]==null)
            {
                return RedirectToAction("Index", "Profile");

            }

            var value = Db.Admins.Find(Session["id"]);
            return View(value);
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {

            var value = Db.Admins.Find(p.AdminId);
            if(value.Password!=p.Password)
            {
                ModelState.AddModelError(string.Empty, "Girdiğiniz sifre yanlış");
                return View(value);
            }
            if(p.ImageFile!=null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var filename = Path.Combine(saveLocation, p.ImageFile.FileName);
                p.ImageFile.SaveAs(filename);
                value.ImageUrl = "/images/" + p.ImageFile.FileName;
            }
            value.UserName = p.UserName;
            value.Name = p.Name;
            value.SurName = p.SurName;
            value.Password = p.Password;
            value.Email = p.Email;
            Db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }


        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Profile");

            }

          
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Admin p)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Index", "Profile");

            }

            var value = Db.Admins.Find(Session["id"]);
            if(p.CurrentPassword!=value.Password)
            {
                ModelState.AddModelError("", "Mevcut şifre hatalı");
                return View(p);
            }

            if(p.NewPassword!=p.ConfirmPassword)
            {
                ModelState.AddModelError("", "Yeni Şifreler Eşleşmiyor");
                return View(p);
            }
            value.Password = p.NewPassword;
            Db.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }
    }
}