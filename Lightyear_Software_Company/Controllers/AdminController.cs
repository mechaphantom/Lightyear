using Lightyear_Software_Company.Models;
using Lightyear_Software_Company.Models.DataContext;
using Lightyear_Software_Company.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Lightyear_Software_Company.Controllers
{
    public class AdminController : Controller
    {
        LightyearDBContext db = new LightyearDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.CountBlog = db.Blog.Count();
            ViewBag.CountServices = db.Services.Count();
            ViewBag.CountJobCategories = db.CarrierCategory.Count();
            ViewBag.CountJobs = db.Carrier.Count();
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Mail == admin.Mail).SingleOrDefault();
            //if (login.Mail == admin.Mail && login.Password == Crypto.Hash(admin.Password, "MD5"))
            if (login.Mail == admin.Mail && login.Password == admin.Password)
            {
                Session["AdminID"] = login.AdminID;
                Session["Mail"] = login.Mail;
                Session["Yetki"] = login.Yetki;
                //Session["Yetki"] = login.Yetki;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Warning = "Invalid Mail or Password!";
            return View(admin);
        }

        public ActionResult Logout()
        {
            Session["AdminID"] = null;
            Session["Mail"] = null;
            Session.Abandon();

            return RedirectToAction("Login", "Admin");
        }
    }
}