using MVCCalendar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCalendar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Database.SetInitializer<StorageContext>(null);  // to wyłącza sprawdzanie migracji
            Storage s = new Storage();
            s.logInPerson("baby");

            if(Session["week"] == null)
            {
                var dfi = DateTimeFormatInfo.CurrentInfo;
                Session["week"] = dfi.Calendar.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek); ;
            }
            int week = (int)Session["week"];
            List<Appointment> appointments = s.getAppointments(week);
            ViewBag.apts = appointments;

            List<Day> calendar = new List<Day>();
            for (int i = 0; i < 28; i++)
            {
                calendar.Add(new Day());
            }

            int offset = (week - 1) * 7 + 1;
            foreach (Appointment ap in appointments)
            {
                calendar[ap.AppointmentDate.DayOfYear - offset].Events.Add(ap);
            }
            
            string[] days = new string[7] {"12345678", "234", "345", "456", "567", "678", "789"};
            ViewBag.cal = calendar;
            for (int i = 0; i < 28; i++)
            {
                Console.Write(calendar[i].Events);
            }
            ViewBag.days = days;
            ViewBag.week = Session["week"];
            return View();
        }

        public ActionResult Next()
        {
            var week = (int)Session["week"];
            if (week != 48)
                Session["week"] = week + 1;
            return Redirect("/");
        }

        public ActionResult Prev()
        {
            var week = (int)Session["week"];
            if(week != 1)
                Session["week"] = week - 1;
            return Redirect("/");
        }

    }
}