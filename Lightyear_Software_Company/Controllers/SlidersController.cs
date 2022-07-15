using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Lightyear_Software_Company.Models.DataContext;
using Lightyear_Software_Company.Models.Model;

namespace Lightyear_Software_Company.Controllers
{
    public class SlidersController : Controller
    {
        private LightyearDBContext db = new LightyearDBContext();

        // GET: Sliders
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderID,SliderTitle,SliderDescription,SliderImageURL")] Slider slider, HttpPostedFileBase SliderImageURL)
        {
            if (ModelState.IsValid)
            {
                if (SliderImageURL != null)
                {
                    WebImage img = new WebImage(SliderImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(SliderImageURL.FileName);

                    string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + sliderimgname);

                    slider.SliderImageURL = "/Uploads/Slider/" + sliderimgname;
                }

                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderID,SliderTitle,SliderDescription,SliderImageURL")] Slider slider, HttpPostedFileBase SliderImageURL, int id)
        {
            if (ModelState.IsValid)
            {
                var s = db.Slider.Where(x => x.SliderID == id).SingleOrDefault();
                if (SliderImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.SliderImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.SliderImageURL));
                    }

                    WebImage img = new WebImage(SliderImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(SliderImageURL.FileName);

                    string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + sliderimgname);
                    s.SliderImageURL = "/Uploads/Slider/" + sliderimgname;
                }
                s.SliderTitle = slider.SliderTitle;
                s.SliderDescription = slider.SliderDescription;
                //db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Slider.Find(id);
            if (System.IO.File.Exists(Server.MapPath(slider.SliderImageURL)))
            {
                System.IO.File.Delete(Server.MapPath(slider.SliderImageURL));
            }
            db.Slider.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
