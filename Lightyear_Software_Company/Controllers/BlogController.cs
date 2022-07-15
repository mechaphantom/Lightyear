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
    public class BlogController : Controller
    {
        LightyearDBContext db = new LightyearDBContext();
        // GET: Blog
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            //return View(db.Blog.Include("BlogCategory").ToList().OrderByDescending(x => x.BlogID));
            return View(db.Blog.Include("BlogCategory").ToList().OrderByDescending(x => x.BlogID));
        }

        public ActionResult Create()
        {
            ViewBag.BlogCategoryID = new SelectList(db.BlogCategory, "BlogCategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog, HttpPostedFileBase BlogImageURL)
        {
            if (BlogImageURL != null)
            {
                WebImage img = new WebImage(BlogImageURL.InputStream);
                FileInfo imginfo = new FileInfo(BlogImageURL.FileName);

                string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(600, 400);
                img.Save("~/Uploads/Blog/" + blogimgname);

                blog.BlogImageURL = "/Uploads/Blog/" + blogimgname;
            }
            db.Blog.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var b = db.Blog.Where(x => x.BlogID == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogCategoryID = new SelectList(db.BlogCategory, "BlogCategoryID", "CategoryName", b.BlogCategoryID);
            return View(b);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Blog blog, HttpPostedFileBase BlogImageURL)
        {
            if (ModelState.IsValid)
            {
                var b = db.Blog.Where(x => x.BlogID == id).SingleOrDefault();
                if (BlogImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(b.BlogImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(b.BlogImageURL));
                    }

                    WebImage img = new WebImage(BlogImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(BlogImageURL.FileName);

                    string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/Blog/" + blogimgname);
                    b.BlogImageURL = "/Uploads/Blog/" + blogimgname;
                }
                b.BlogTitle = blog.BlogTitle;
                b.BlogContent = blog.BlogContent;
                b.BlogCategoryID = blog.BlogCategoryID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        public ActionResult Delete(int id)
        {
            var b = db.Blog.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            if (System.IO.File.Exists(Server.MapPath(b.BlogImageURL)))
            {
                System.IO.File.Delete(Server.MapPath(b.BlogImageURL));
            }
            db.Blog.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}