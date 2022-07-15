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
    public class WebsiteIdentityController : Controller
    {
        LightyearDBContext db = new LightyearDBContext();

        // GET: WebsiteIdentity
        public ActionResult Index()
        {
            return View(db.WebsiteIdentity.ToList());
        }

        // GET: WebsiteIdentity/Edit/5
        public ActionResult Edit(int id)
        {
            var identity = db.WebsiteIdentity.Where(i => i.WebsiteID == id).SingleOrDefault();
            return View(identity);
        }

        // POST: WebsiteIdentity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, WebsiteIdentity identity, HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                var i = db.WebsiteIdentity.Where(x => x.WebsiteID == id).SingleOrDefault();

                if (LogoURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(i.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(i.LogoURL));
                    }

                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);

                    //string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    string logoname = LogoURL.FileName + imginfo.Extension;
                    img.Resize(300, 150);
                    img.Save("~/Uploads/WebsiteIdentity/" + logoname);
                    i.LogoURL = "/Uploads/WebsiteIdentity/" + logoname;
                }
                
                i.Title = identity.Title;
                i.Keywords = identity.Keywords;
                i.Description = identity.Description;
                i.Rank = identity.Rank;
                db.SaveChanges();
                return RedirectToAction("Index");
;            }
            return View();
        }
    }
}
