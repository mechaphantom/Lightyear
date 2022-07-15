using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lightyear_Software_Company.Models.DataContext;
using Lightyear_Software_Company.Models.Model;

namespace Lightyear_Software_Company.Controllers
{
    public class BlogCategorieController : Controller
    {
        private LightyearDBContext db = new LightyearDBContext();

        // GET: BlogCategorie
        public ActionResult Index()
        {
            return View(db.BlogCategory.ToList());
        }

        // GET: BlogCategorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCategory blogCategory = db.BlogCategory.Find(id);
            if (blogCategory == null)
            {
                return HttpNotFound();
            }
            return View(blogCategory);
        }

        // GET: BlogCategorie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogCategorie/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogCategoryID,CategoryName,CategoryDescription")] BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                db.BlogCategory.Add(blogCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogCategory);
        }

        // GET: BlogCategorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCategory blogCategory = db.BlogCategory.Find(id);
            if (blogCategory == null)
            {
                return HttpNotFound();
            }
            return View(blogCategory);
        }

        // POST: BlogCategorie/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogCategoryID,CategoryName,CategoryDescription")] BlogCategory blogCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogCategory);
        }

        // GET: BlogCategorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogCategory blogCategory = db.BlogCategory.Find(id);
            if (blogCategory == null)
            {
                return HttpNotFound();
            }
            return View(blogCategory);
        }

        // POST: BlogCategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogCategory blogCategory = db.BlogCategory.Find(id);
            db.BlogCategory.Remove(blogCategory);
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
