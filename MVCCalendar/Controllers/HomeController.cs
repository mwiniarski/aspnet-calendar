using MVCCalendar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
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
            Person p = s.logInPerson("baby");
            Session["user"] = p;
            Session["storage"] = s;
            if(Session["week"] == null)
            {
                var dfi = DateTimeFormatInfo.CurrentInfo;
                Session["week"] = dfi.Calendar.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek); ;
            }
            int week = (int)Session["week"];
            List<Appointment> appointments = s.getAppointments(week, p);

            List<Day> calendar = new List<Day>();
            int offset = (week - 1) * 7 + 1;
            for (int i = 0; i < 28; i++)
            {
                calendar.Add(new Day(offset + i - 1));
            }

            foreach (Appointment ap in appointments)
            {
                calendar[ap.AppointmentDate.DayOfYear - offset].Events.Add(ap);
            }
            
            ViewBag.cal = calendar;
            ViewBag.week = week;
            return View();
        }

        public RedirectResult Next()
        {
            var week = (int)Session["week"];
            if (week != 48)
                Session["week"] = week + 1;
            return Redirect("/");
        }

        public RedirectResult Prev()
        {
            var week = (int)Session["week"];
            if(week != 1)
                Session["week"] = week - 1;
            return Redirect("/");
        }

        public bool isDateValid(int month, int day)
        {
            return day <= DateTime.DaysInMonth(2018, month);
        }

        public ActionResult Add(int month, int day)
        {
            if(!isDateValid(month, day))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.month = month;
            ViewBag.day = day;
            

            return View();
        }

        [HttpPost]
        public RedirectResult Add([Bind(Include = "Title, Description, AppointmentDate")]Appointment apt, int month, int day)
        {
            if (!isDateValid(month, day))
            {
                Session["message"] = "Wrong url address!";
                Redirect("/");
            }

            System.Diagnostics.Debug.WriteLine(apt.Title);
            System.Diagnostics.Debug.WriteLine(day);
            System.Diagnostics.Debug.WriteLine(month);
            Storage s = new Storage();
            apt.AppointmentDate = new DateTime(2018, month, day);
            s.addAppointment(apt, (Person)Session["user"]);
            return Redirect("/");
        }

    }
}