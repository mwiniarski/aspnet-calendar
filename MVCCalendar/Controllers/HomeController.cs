using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCalendar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] week = new string[4] {"1", "2", "3", "4"};
            ViewBag.week = week;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}