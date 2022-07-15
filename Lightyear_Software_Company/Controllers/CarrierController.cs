using Lightyear_Software_Company.Models.DataContext;
using Lightyear_Software_Company.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Lightyear_Software_Company.Controllers
{
    public class CarrierController : Controller
    {
        LightyearDBContext db = new LightyearDBContext();
        // GET: Carrier
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.Carrier.Include("CarrierCategory").ToList().OrderByDescending(x => x.CarrierID));
        }

        public ActionResult Create()
        {
            ViewBag.CarrierCategoryID = new SelectList(db.CarrierCategory, "CarrierCategoryID", "CarrierCategoryName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carrier carrier, HttpPostedFileBase CarrierImageURL)
        {
            if (CarrierImageURL != null)
            {
                WebImage img = new WebImage(CarrierImageURL.InputStream);
                FileInfo imginfo = new FileInfo(CarrierImageURL.FileName);

                string carrierimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(600, 400);
                img.Save("~/Uploads/Carrier/" + carrierimgname);

                carrier.CarrierImageURL = "/Uploads/Carrier/" + carrierimgname;
            }
            db.Carrier.Add(carrier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var c = db.Carrier.Where(x => x.CarrierID == id).SingleOrDefault();
            if (c == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarrierCategoryID = new SelectList(db.CarrierCategory, "CarrierCategoryID", "CarrierCategoryName", c.CarrierCategoryID);
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Carrier carrier, HttpPostedFileBase CarrierImageURL)
        {
            if (ModelState.IsValid)
            {
                var c = db.Carrier.Where(x => x.CarrierID == id).SingleOrDefault();
                if (CarrierImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(c.CarrierImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(c.CarrierImageURL));
                    }

                    WebImage img = new WebImage(CarrierImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(CarrierImageURL.FileName);

                    string carrierimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/Carrier/" + carrierimgname);
                    c.CarrierImageURL = "/Uploads/Carrier/" + carrierimgname;
                }
                c.CarrierTitle = carrier.CarrierTitle;
                c.CarrierContent = carrier.CarrierContent;
                c.CarrierCategoryID = carrier.CarrierCategoryID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrier);
        }

        public ActionResult Delete(int id)
        {
            var c = db.Carrier.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            if (System.IO.File.Exists(Server.MapPath(c.CarrierImageURL)))
            {
                System.IO.File.Delete(Server.MapPath(c.CarrierImageURL));
            }
            db.Carrier.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}