using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MVCBog.Models;
using System.Configuration;

namespace MVCBog.Controllers
{
    public class PollController : Controller
    {

        public ActionResult Index()
        {
            string conn = ConfigurationManager.ConnectionStrings["EnglishDBConnectionString"].ToString();
            ApplicationDbContext db = new ApplicationDbContext();
            Poll po = new Poll();
            var votes = from vote in db.Poll select vote;
            int A;
            int B;
            int C;
            int D;
            A = 0;
            B = 0;
            C = 0;
            D = 0;
            foreach (var vote in votes)
            {
                if (vote.votes == "A")
                    A++;
                if (vote.Vote == "B")
                    B++;
                if (vote.Vote == "C")
                    C++;
                if (vote.Vote == "D")
                    D++;
            }


            return View();
        }
    }
}