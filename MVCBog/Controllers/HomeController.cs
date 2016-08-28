using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBog.Models;
using System.Data.Entity;

namespace MVCBog.Controllers
{
    public class HomeController : Controller
   
        {
            private ApplicationDbContext db = new 
            ApplicationDbContext();

        public ActionResult Index()
        {
            var posts = db.Ads.Include(p => p.Author)
                .OrderByDescending(p => p.Date).Take(4);
            return View(posts.ToList());
        }

       
    }
}