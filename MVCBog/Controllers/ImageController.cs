//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using MVCBog.Models;

//namespace MVCBog.Controllers
//{
//    public class ImageContoller : Controller
//    {
//        public ActionResult Create(Image img, HttpPostedFileBase file)
//        {
//            if (ModelState.IsValid)
//            {
//                if (file != null)
//                {
//                    file.SaveAs(HttpContext.Server.MapPath("~/Images/")
//                                                          + file.FileName);
//                    img.ImagePath = file.FileName;
//                }
//                db.Image.Add(img);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(img);

//        }
//    }
//}