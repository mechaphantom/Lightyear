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
    public class CarrierCategoriesController : Controller
    {
        private LightyearDBContext db = new LightyearDBContext();

        // GET: CarrierCategories
        public ActionResult Index()
        {
            return View(db.CarrierCategory.ToList());
        }

        // GET: CarrierCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrierCategory carrierCategory = db.CarrierCategory.Find(id);
            if (carrierCategory == null)
            {
                return HttpNotFound();
            }
            return View(carrierCategory);
        }

        // GET: CarrierCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarrierCategories/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarrierCategoryID,CarrierCategoryName,CarrierCategoryDescription")] CarrierCategory carrierCategory)
        {
            if (ModelState.IsValid)
            {
                db.CarrierCategory.Add(carrierCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrierCategory);
        }

        // GET: CarrierCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrierCategory carrierCategory = db.CarrierCategory.Find(id);
            if (carrierCategory == null)
            {
                return HttpNotFound();
            }
            return View(carrierCategory);
        }

        // POST: CarrierCategories/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarrierCategoryID,CarrierCategoryName,CarrierCategoryDescription")] CarrierCategory carrierCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrierCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrierCategory);
        }

        // GET: CarrierCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarrierCategory carrierCategory = db.CarrierCategory.Find(id);
            if (carrierCategory == null)
            {
                return HttpNotFound();
            }
            return View(carrierCategory);
        }

        // POST: CarrierCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarrierCategory carrierCategory = db.CarrierCategory.Find(id);
            db.CarrierCategory.Remove(carrierCategory);
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
