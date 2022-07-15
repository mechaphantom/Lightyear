using Lightyear_Software_Company.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Lightyear_Software_Company.Models.Model;

namespace Lightyear_Software_Company.Controllers
{
    public class HomeController : Controller
    {
        private LightyearDBContext db = new LightyearDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x => x.SliderID));
        }

        public ActionResult About()
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.About.SingleOrDefault());
        }

        public ActionResult Services()
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Services.ToList().OrderByDescending(x => x.ServiceID));
        }

        public ActionResult Team()
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Contact.SingleOrDefault());
        }


        [HttpPost]
        public ActionResult Contact(string name = null, string email = null, string subject = null, string message = null)
        {
            //ViewBag.Kimlik = db.Contact.SingleOrDefault();
            if (name != null && email != null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "spikecowboy123@gmail.com";
                WebMail.Password = "kerem1907";
                WebMail.SmtpPort = 587;
                WebMail.Send("spikecowboy123@gmail.com", subject, email + " - " + message);
                ViewBag.Message = "Your message successfully delivered!";
            }
            else
            {
                ViewBag.Message = "Something went wrong! Try again later!";
            }

            return View(db.Contact.SingleOrDefault());
        }

        public ActionResult Blog(int Page = 1)
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Blog.Include("BlogCategory").OrderByDescending(x => x.BlogID).ToPagedList(Page, 5)); 
        }

        public ActionResult BlogDetail(int id)
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            var b = db.Blog.Include("BlogCategory").Where(x => x.BlogID == id).SingleOrDefault();
            return View(b);
        }

        public ActionResult CategoryBlog(int id, int Page = 1)
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            var b = db.Blog.Include("BlogCategory").OrderByDescending(x => x.BlogID).Where(x => x.BlogCategory.BlogCategoryID == id).ToPagedList(Page, 5);
            return View(b);
        }


        public JsonResult CreateComment(string name, string mail, string content, int BlogID)
        {
            if (content == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.Comment.Add(new Comment { Name = name, Mail = mail, CommentContent = content, BlogID = BlogID, Approval = false });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BlogCategoryPartial()
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            //db.Configuration.LazyLoadingEnabled = false;
            return PartialView(db.BlogCategory.Include("Blogs").ToList().OrderBy(x => x.CategoryName));
        }

        public ActionResult Carrier()
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Carrier.Include("CarrierCategory").OrderByDescending(x => x.CarrierID));
        }

        public ActionResult CarrierCategoryPartial()
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            //db.Configuration.LazyLoadingEnabled = false;
            return PartialView(db.CarrierCategory.Include("Carriers").ToList().OrderBy(x => x.CarrierCategoryName));
        }

        public ActionResult CategoryCarrier(int id)
        {
            //ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            var c = db.Carrier.Include("CarrierCategory").OrderByDescending(x => x.CarrierID).Where(x => x.CarrierCategory.CarrierCategoryID == id);
            return View(c);
        }
    }
}