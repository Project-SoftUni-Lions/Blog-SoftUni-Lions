using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBog.Models;
using System.Data.Entity;

namespace MVCBog.Controllers
{
    public class AboutUsController : Controller
   
        {

        public ActionResult Index()
        {
            
            return View();
        }

       
    }
}