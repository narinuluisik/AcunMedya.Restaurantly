using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcunMedya.Restaurantly.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {     
        RestaurantlyContext Db = new RestaurantlyContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = Db.Admins.FirstOrDefault(X => X.UserName == p.UserName && X.Password == p.Password);
            if(values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, true);
                Session["a"] = values.UserName;
                Session["id"] = values.AdminId;
                Session["surname"] = values.SurName;
                Session["name"] = values.Name;
                Session["img"] = values.ImageUrl;
                return RedirectToAction("Index", "Profile");
            }

            return View();
        }
    }
}