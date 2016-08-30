using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBog.Models;

namespace MVCBog.Controllers
{
    public class ImagesController : Controller
    {
       

        
        //public ActionResult Index()
        //{


        //    //return View();

        //}



        [HttpPost]
        public ActionResult AddImage(Image model, HttpPostedFileBase image1)
        {
            var db = new ApplicationDbContext();
            if (image1 != null)
            {
                model.BrandImage = new byte[image1.ContentLength];
                image1.InputStream.Read(model.BrandImage, 0, image1.ContentLength);
            }
            db.Img.Add(model);
            db.SaveChanges();
            return View(model);

        }


    }
}
