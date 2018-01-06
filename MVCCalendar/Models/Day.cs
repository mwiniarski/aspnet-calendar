using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCalendar.Models
{
    public class Day
    {
        public Day(int dayOfTheYear)
        {
            DateTime dt = new DateTime(2018, 1, 1);
            Date = dt.AddDays(dayOfTheYear);
        }

        private List<Appointment> events_ = new List<Appointment>();
        public List<Appointment> Events
        {
            get { return events_; }
            set { events_ = value; }
        }

        public DateTime Date { get; set; }

        public String DateString
        {
            get { return String.Format("{0:MMM d}", Date); }
        }
    }
}