using Lightyear_Software_Company.Models.DataContext;
using Lightyear_Software_Company.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Lightyear_Software_Company.Controllers
{
    public class ServicesController : Controller
    {
        LightyearDBContext db = new LightyearDBContext();
        // GET: Services
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Services service, HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                if (ImageURL != null)
                {

                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImageURL.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    //string logoname = ImageURL.FileName + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Services/" + logoname);
                    service.ImageURL = "/Uploads/Services/" + logoname;
                }

                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                ViewBag.Warning = "There is no Service with this ID in the Database!";
            }

            var service = db.Services.Find(id);
            if (service==null)
            {
                return HttpNotFound();
            }

            return View(service);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Services service, HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                var s = db.Services.Where(x => x.ServiceID == id).SingleOrDefault();
                if (ImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.ImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.ImageURL));
                    }

                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImageURL.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    //string logoname = ImageURL.FileName + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Services/" + logoname);
                    s.ImageURL = "/Uploads/Services/" + logoname;
                }

                s.ServiceTitle = service.ServiceTitle;
                s.ServiceDescription = service.ServiceDescription;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }

            var s = db.Services.Find(id);
            if (s==null)
            {
                return HttpNotFound();
            }
            db.Services.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}