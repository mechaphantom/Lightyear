using Lightyear_Software_Company.Models.DataContext;
using Lightyear_Software_Company.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lightyear_Software_Company.Controllers
{
    public class AboutController : Controller
    {
        LightyearDBContext db = new LightyearDBContext();
        // GET: About
        public ActionResult Index()
        {
            var about = db.About.ToList();
            return View(about);
        }

        public ActionResult Edit(int id)
        {
            var a = db.About.Where(x => x.AboutID == id).FirstOrDefault();
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, About about) 
        {
            if (ModelState.IsValid)
            {
                var a = db.About.Where(x => x.AboutID == id).SingleOrDefault();
                a.About_Description = about.About_Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(about);
        }
    }
}