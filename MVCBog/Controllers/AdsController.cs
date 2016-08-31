using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBog.Extensions;
using MVCBog.Models;

namespace MVCBog.Controllers
{
    public class AdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            //var ads = db.Ads.Include(p => p.Author).ToList();
            //var item = (from d in db.Ads
            //            select d).ToList();
            //return View(db.Ads.Include(p=>p.Author).ToList());
            var posts = db.Ads
               .OrderByDescending(p => p.Date);
            return View(posts.ToList());
        }

        public ActionResult Search(string searchString)
        {
            var ads = from m in db.Ads
                      select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                ads = ads.Where(s => s.Title.Contains(searchString)).OrderByDescending(p => p.Date); 
            }

            return View(ads.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ads ads = db.Ads.Find(id);
            if (ads == null)
            {
                return HttpNotFound();
            }
            return View(ads);
        }

        // GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            Ads b1 = new Ads();
            return View(b1);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,Price,Contacts")] Ads ads,  HttpPostedFileBase image1)
        {


            if (ModelState.IsValid)
            {
                
                ads.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
       
                this.AddNotification("Обявата е публикувана успешно", NotificationType.SUCCESS);
                //return RedirectToAction("Index");
            }

            if (image1 != null)
            {
                ads.UplImage = new byte[image1.ContentLength];
                image1.InputStream.Read(ads.UplImage, 0, image1.ContentLength);


            }
            db.Ads.Add(ads);
            db.SaveChanges();

            return View(ads);

      
           
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Administrators")]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ads ads = db.Ads.Find(id);
            if (ads == null)
            {
                return HttpNotFound();
            }
            //var authors = db.Users.ToList();
            //ViewBag.Authors = authors;
            return View(ads);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,Price,Contacts")] Ads ads, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ads).State = EntityState.Modified;
               
                this.AddNotification("Обявата е редактирана", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            if (image1 != null)
            {
                ads.UplImage = new byte[image1.ContentLength];
                image1.InputStream.Read(ads.UplImage, 0, image1.ContentLength);


            }
            db.SaveChanges();
            return View(ads);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ads ads = db.Ads.Find(id);
            if (ads == null)
            {
                return HttpNotFound();
            }
            return View(ads);
        }

        // POST: Posts/Delete/5
        [Authorize(Roles="Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ads ads = db.Ads.Find(id);
            db.Ads.Remove(ads);
            db.SaveChanges();
            this.AddNotification("Обявата беше изтрита", NotificationType.SUCCESS);
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
