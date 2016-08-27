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
            var ads = db.Ads.Include(p => p.Author).ToList();
            return View(db.Ads.Include(p=>p.Author).ToList());
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
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] Ads ads)
        {
            if (ModelState.IsValid)
            {
                ads.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                db.Ads.Add(ads);
                db.SaveChanges();
                this.AddNotification("Post created", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

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
        public ActionResult Edit([Bind(Include = "Id,Title,Body,Date")] Ads ads)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ads).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification("Post edited", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
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
            this.AddNotification("Post deleted", NotificationType.SUCCESS);
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
